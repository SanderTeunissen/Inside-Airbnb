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
    public class KmsDataProtector : IDataProtector
    {
        readonly CloudKMSService _kms;
        readonly string _keyName;
        readonly Func<string, IDataProtector> _dataProtectorFactory;
        
        internal KmsDataProtector(CloudKMSService kms, string keyName, Func<string, IDataProtector> dataProtectorFactory)
        {
            _kms = kms;
            _keyName = keyName;
            _dataProtectorFactory = dataProtectorFactory;
        }
        IDataProtector IDataProtectionProvider.CreateProtector(string purpose)
        {
            return _dataProtectorFactory(purpose);
        }

        byte[] IDataProtector.Protect(byte[] plaintext)
        {
            var result = _kms.Projects.Locations.KeyRings.CryptoKeys.Encrypt(new EncryptRequest()
            {
                Plaintext = Convert.ToBase64String(plaintext)
            }, _keyName).Execute();
            return Convert.FromBase64String(result.Ciphertext);
        }



        byte[] IDataProtector.Unprotect(byte[] protectedData)
        {
            var result = _kms.Projects.Locations.KeyRings.CryptoKeys.Decrypt(new DecryptRequest()
            {
                Ciphertext = Convert.ToBase64String(protectedData)
            }, _keyName).Execute();
            return Convert.FromBase64String(result.Plaintext);
        }

    }
}
