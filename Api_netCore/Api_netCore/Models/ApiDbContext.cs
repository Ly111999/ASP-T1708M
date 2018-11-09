using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api_netCore.Controllers.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<SClass> SClasses { get; set; }
        public DbSet<Student> Students { get; set; }
    }

    //web server :
    // php là apache 
    //java là apache tomcat & internet information services(iis)
}
