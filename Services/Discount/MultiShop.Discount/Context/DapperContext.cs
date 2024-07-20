using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
	public class DapperContext : DbContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-HF106PUQ\\SQLEXPRESS; database=MultiShopDiscountDb; trusted_connection=true; TrustServerCertificate=True");
		}

		public DbSet<Coupon> Coupons => Set<Coupon>();
		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
	}
}
