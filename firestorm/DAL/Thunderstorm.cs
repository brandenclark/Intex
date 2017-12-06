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
    }//Kiersten checking in
}