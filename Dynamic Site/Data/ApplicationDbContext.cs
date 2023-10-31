using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dynamic_Site.Models;

namespace Dynamic_Site.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		    : base(options)
		{
		}
		public DbSet<Dynamic_Site.Models.ContactViewModel>? ContactViewModel { get; set; }
	}
}