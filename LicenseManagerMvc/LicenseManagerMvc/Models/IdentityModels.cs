using Microsoft.AspNet.Identity.EntityFramework;

namespace LicenseManagerMvc.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<LicenseManagerMvc.Models.Hersteller> Herstellers { get; set; }

        public System.Data.Entity.DbSet<LicenseManagerMvc.Models.Programm> Programms { get; set; }

        public System.Data.Entity.DbSet<LicenseManagerMvc.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<LicenseManagerMvc.Models.Computer> Computers { get; set; }

        public System.Data.Entity.DbSet<LicenseManagerMvc.Models.Lizenz> Lizenzs { get; set; }
    }
}