using RestAPIWithASP_Net5.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Model
{
    [Table("books")]
    public class Book  : BaseEntity
    {
        [Column("title", Order = 2)]
        public string Title { get; set; }

        [Column("author", Order = 2)]
        public string Author { get; set; }

        [Column("price", Order = 2)]
        public decimal Price { get; set; }

        [Column("launch_date", Order = 2)]
        public DateTime LaunchDate { get; set; }
    }
}
