using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model.DomainObjects;

namespace CarRentals.DataAccess
{
   public class MapToCarRentalUserStoredProcedures
    {

       public static void UseStoredProceduresForEntity(DbModelBuilder modelBuilder)
       {
           modelBuilder.Entity<CarRentalUser>().MapToStoredProcedures(s =>
           {
               s.Insert(i => i.HasName("CarRental_InsertUser"));
               s.Update(u => u.HasName("CarRental_UpdateUser"));
               s.Delete(d => d.HasName("CarRental_DeleteUser"));

           });
       }
    }
}
