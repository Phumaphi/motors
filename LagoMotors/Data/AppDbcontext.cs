using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoMotors.Models;
using Microsoft.EntityFrameworkCore;

namespace LagoMotors.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext>options)
        :base(options)
        { }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

        }

    }
}
