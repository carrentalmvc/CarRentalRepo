﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model.DomainObjects;

namespace CarRentals.DataAccess.Mappers
{

    public class RoleMap : EntityTypeConfiguration<CarRentalRole>
    {
        public RoleMap()
        {
            HasKey(p => p.RoleId);
            Property(p => p.RoleName).HasMaxLength(25).IsRequired();
            Property(p => p.IsActive).IsRequired();
            Property(p => p.IsDeleted).IsRequired();
            Property(p => p.IsActive).IsRequired();
            Property(p => p.CreateDtTm).IsOptional();
            Property(p => p.UpdateDtTm).IsOptional();
        }

    }
}
