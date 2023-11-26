using HotelWebApplication.Models.Poco_Class;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApplication.EF_Data
{
	public class HotelDbContext : DbContext
	{
		public HotelDbContext(DbContextOptions options) : base(options)
		{ 

		}
		//public DbSet<LoginVM> loginVMs { get; set; }
		public DbSet<Customer> Customers { get; set; }
	}

}
