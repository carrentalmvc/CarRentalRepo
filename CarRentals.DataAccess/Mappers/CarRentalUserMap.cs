using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CarRentals.Model.DomainObjects;

namespace CarRentals.DataAccess
{
    /// <summary>
    /// These mappers are used for defineing the DB schema.This should be done in the DataAccess layer
    /// </summary>
  public class CarRentalUserMap : EntityTypeConfiguration<CarRentalUser>
    {
      public CarRentalUserMap()
      {
          HasKey(p => p.UserId);
          HasRequired(p => p.UserRole)
              .WithMany(p => p.Users)
              .HasForeignKey(p => p.RoleId);
          Property(p => p.FirstName).HasMaxLength(250).IsRequired();
          Property(p => p.EmailAddress).HasMaxLength(25).IsRequired();
          Property(p => p.Password).HasMaxLength(10).IsRequired();
      }
    }
}
