﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model;

namespace CarRentals.DataAccess
{
    /// <summary>
    /// DbC ontext is the gateway to the databse
    /// </summary>
    public class CarRentalDbContext : DbContext , IDbContext
    {
        static CarRentalDbContext()
        {
            Database.SetInitializer<CarRentalDbContext>(null);
        }

        public CarRentalDbContext()
            : base("Name=CarRental_Connection_String")
       {
         
       }
       public DbSet<CarRentalUser> Users { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
           modelBuilder.Configurations.Add(new CarRentalUserMap());
       }
    }
}
