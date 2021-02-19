using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Model.Base
{
    public class BaseEntity
    {

        [JsonProperty(Order = -2)]
        public int Id { get; set; }
    }
}
