using IsraPro.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsraPro.Models
{
    public class Ripository
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "owner")]
         public Owner Avatar { get; set; }
    }
}
