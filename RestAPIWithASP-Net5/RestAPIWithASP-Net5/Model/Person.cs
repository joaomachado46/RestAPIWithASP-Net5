using Newtonsoft.Json;
using RestAPIWithASP_Net5.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        [JsonProperty(Order = -1)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [JsonProperty(Order = -1)]
        public string LastName { get; set; }
        [Column("address")]
        [JsonProperty(Order = -1)]
        public string Address { get; set; }
        [Column("gender")]
        [JsonProperty(Order = -1)]
        public string Gender { get; set; }


    }
}
