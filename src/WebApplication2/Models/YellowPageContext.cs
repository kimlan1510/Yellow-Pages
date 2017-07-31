using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YellowPage.Models
{
    public class YellowPageContext: DbContext
    {
		public virtual DbSet<Shop> businesses { get; set; }
		public virtual DbSet<Category> types { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
			options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YellowPages;integrated security=True");
        }
    }
}
