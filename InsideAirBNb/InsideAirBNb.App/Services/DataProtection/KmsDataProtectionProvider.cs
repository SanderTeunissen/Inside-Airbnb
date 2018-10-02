using Google.Apis.Auth.OAuth2;
using Google.Apis.CloudKMS.v1;
using Google.Apis.CloudKMS.v1.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace InsideAirBNB.App.Services.DataProtection
{
    public class KmsDataProtectionProvider : IDataProtectionProvider
    {
        readonly CloudKMSService _kms;
        readonly IOptions<KmsDataProtectionProviderOptions> _options;

        readonly ConcurrentDictionary<string, IDataProtector>
            _dataProtectorCache = new ConcurrentDictionary<string, IDataProtector>();

        public KmsDataProtectionProvider(IOptions<KmsDataProtectionProviderOptions> options)
        {
            _options = options;

            GoogleCredential credential = GoogleCredential.GetApplicationDefaultAsync().Result;

            if (credential.IsCreateScopedRequired)
            {
                credential = credential.CreateScoped(new[] { CloudKMSService.Scope.CloudPlatform });
            }

            _kms = new CloudKMSService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                GZipEnabled = false
            });

            var parent = string.Format("projects/{0}/locations/{1}", options.Value.ProjectId, options.Value.Location);

            KeyRing keyRingToCreate = new KeyRing();

            var request = new ProjectsResource.LocationsResource.KeyRingsResource.CreateRequest(_kms, keyRingToCreate, parent);

            request.KeyRingId = options.Value.KeyRing;

            try
            {
                request.Execute();
            }
            catch (Google.GoogleApiException e)
            when (e.HttpStatusCode == System.Net.HttpStatusCode.Conflict) { /* Already exists.  Ok.*/ }
        }

        IDataProtector IDataProtectionProvider.CreateProtector(string purpose)
        {
            IDataProtector cached;

            if (_dataProtectorCache.TryGetValue(purpose, out cached))
            {
                return cached;
            }

            var keyRingName = string.Format(
                "projects/{0}/locations/{1}/keyRings/{2}",
                _options.Value.ProjectId, _options.Value.Location,
                _options.Value.KeyRing);

            string rotationPeriod = string.Format("{0}s", TimeSpan.FromDays(7).TotalSeconds);

            CryptoKey cryptoKeyToCreate = new CryptoKey()
            {
                Purpose = "ENCRYPT_DECRYPT",
                NextRotationTime = DateTime.UtcNow.AddDays(7),
                RotationPeriod = rotationPeriod
            };

            var request = new ProjectsResource.LocationsResource.KeyRingsResource.CryptoKeysResource.CreateRequest(_kms, cryptoKeyToCreate, keyRingName);

            string keyId = EscapeKeyId(purpose);
            request.CryptoKeyId = keyId;

            string keyName;
            try
            {
                keyName = request.Execute().Name;
            }
            catch (Google.GoogleApiException e)
            when (e.HttpStatusCode == System.Net.HttpStatusCode.Conflict)
            {
                // Already exists.  Ok.
                keyName = string.Format("{0}/cryptoKeys/{1}", keyRingName, keyId);
            }

            var newProtector = new KmsDataProtector(_kms, keyName, (string innerPurpose) => this.CreateProtector($"{purpose}.{innerPurpose}"));
            _dataProtectorCache.TryAdd(purpose, newProtector);

            return newProtector;
        }

        static string EscapeKeyId(string purpose)
        {
            StringBuilder keyIdBuilder = new StringBuilder();
            char prevC = ' ';

            foreach (char c in purpose)
            {
                if (c == '.')
                {
                    keyIdBuilder.Append('-');
                }
                else if (prevC == '0' && c == 'x' || !"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_".Contains(c))
                {
                    keyIdBuilder.AppendFormat("0x{0:X4}", (int)c);
                }
                else
                {
                    keyIdBuilder.Append(c);
                }
                prevC = c;
            }

            string keyId = keyIdBuilder.ToString();

            if (keyId.Length > 63)
            {
                keyId = string.Format("{0}-{1:x8}", keyId.Substring(0, 54), QuickHash(keyId));
            }

            return keyId;
        }

        static int QuickHash(string s)
        {
            int hash = 17;
            foreach (char c in s)
            {
                hash = hash * 31 + c;
            }
            return hash;
        }
    }
}
