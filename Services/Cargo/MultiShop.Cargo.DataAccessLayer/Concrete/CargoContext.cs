using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
	public class CargoContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1441; Database=MultiShopCargoDb; User=sa; Password=Password12*; TrustServerCertificate=true");
		}

		public DbSet<CargoCompany> CargoCompanies => Set<CargoCompany>();
		public DbSet<CargoDetail> CargoDetails => Set<CargoDetail>();
		public DbSet<CargoCustomer> CargoCustomers => Set<CargoCustomer>();
		public DbSet<CargoOperation> CargoOperations => Set<CargoOperation>();
	}
}
