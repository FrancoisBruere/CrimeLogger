using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<CrimeType> CrimeTypes { get; set; }
        public DbSet<CrimeSuburb> CrimeSuburbs { get; set; }
        public DbSet<CrimeCity> CrimeCities { get; set; }
        public DbSet<CrimeProvince> CrimeProvinces { get; set; }
        public DbSet<CrimeDetail> CrimeDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CrimeNotificationSubscription> NotificationSubscriptions { get; set; }

    }
}
