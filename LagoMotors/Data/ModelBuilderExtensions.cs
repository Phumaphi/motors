using LagoMotors.Models;
using Microsoft.EntityFrameworkCore;

namespace LagoMotors.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>().HasData(
                new Make {Id = 1,Name = "Toyota" },
                new Make {Id = 2, Name = "BMW" },
                new Make {Id = 3,Name = "Audi" },
                new Make {Id = 4,Name = "Mercedese Benz" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model {Id = 1,Name = "Corolla", MakeId = 1 },
                new Model { Id = 2,Name = "Staurt", MakeId = 1 },
                new Model {Id = 3,Name = "Hilux", MakeId = 1 },
                new Model {Id = 4,Name = " BMW_i8", MakeId = 2 },
                new Model {Id = 5,Name = " BMW_x5", MakeId = 2 },
                new Model { Id = 6,Name = "Q8", MakeId = 3 },
                new Model {Id = 7,Name = "C-Class", MakeId = 4 }
            );

            modelBuilder.Entity<Feature>().HasData(
                new Feature {Id = 1,Name = "AirBag"},
                new Feature { Id = 2,Name = "Breaks Lights"},
                new Feature {Id = 3,Name = "Baby Seat"},
                new Feature { Id = 4,Name = "Power Steering"}
            );
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new
            {
                vf.VehicleId, vf.FeatureId

            });

        }
    }
}
