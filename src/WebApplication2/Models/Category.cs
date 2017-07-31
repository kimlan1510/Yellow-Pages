using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YellowPage.Models
{
    [Table("category")]
    public class Category
    {
        public Category()
        {
            this.Businesses = new HashSet<Shop>();
        }
       [Key]
       public int CategoryId { get; set; }
       public string description { get; set; }
       public virtual ICollection<Shop> Businesses { get; set; }
    }
}
