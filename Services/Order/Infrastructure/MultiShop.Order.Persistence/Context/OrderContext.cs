using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
	public class OrderContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-HF106PUQ\\SQLEXPRESS; database=MultiShopOrderDb; trusted_connection=true; TrustServerCertificate=True");
		}

		public DbSet<Address> Addresses => Set<Address>();
		public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
		public DbSet<Ordering> Orderings => Set<Ordering>();
	}
}
