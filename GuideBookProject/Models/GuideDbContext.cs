using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Models
{
    public class GuideDbContext : DbContext
    {
        public GuideDbContext(DbContextOptions<GuideDbContext> opt) : base(opt)
        {

        }


        public DbSet<CommInfo> CommInfos { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}
