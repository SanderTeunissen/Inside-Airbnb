using System;
using System.ComponentModel.DataAnnotations;

namespace InsideAirBNB.App.Models.Base
{
    [Serializable]
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
