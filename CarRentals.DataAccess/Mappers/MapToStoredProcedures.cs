using System.Data.Entity;
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
            });
        }
    }
}