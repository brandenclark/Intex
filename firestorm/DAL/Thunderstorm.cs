using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firestorm.Models;
using System.Data.Entity;

namespace firestorm.DAL
{
    public class Thunderstorm : DbContext
    {
        public Thunderstorm() : base("Thunderstorm")
        {

        }

        public DbSet<Assay> Assays { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }

        public System.Data.Entity.DbSet<firestorm.Models.CompoundSample> CompoundSamples { get; set; }

        public System.Data.Entity.DbSet<firestorm.Models.Compound> Compounds { get; set; }

        public System.Data.Entity.DbSet<firestorm.Models.WorkOrder> WorkOrders { get; set; }
    }
}