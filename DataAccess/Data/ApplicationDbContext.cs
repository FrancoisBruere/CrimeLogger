using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CrimeType> CrimeTypes { get; set; }
        public DbSet<CrimeSuburb> CrimeSuburbs { get; set; }
        public DbSet<CrimeCity> CrimeCities { get; set; }
        public DbSet<CrimeProvince> CrimeProvinces { get; set; }
        public DbSet<CrimeDetail> CrimeDetails { get; set; }

    }
}
