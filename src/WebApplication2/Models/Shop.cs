using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YellowPage.Models
{
    [Table("shop")]
    public class Shop
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public string website { get; set; }
        public int CategoryId { get; set; }  
        public virtual Category Category { get; set; }
    }
    
}
