using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Model.DomainObjects;
using CarRentals.Model.Enums;

namespace CarRentals.DataAccess.Mappers
{
    public class LocationMap : EntityTypeConfiguration<Location>
    {

        public LocationMap()
        {
            HasKey(l => l.LocationId);
            //Not sure we need to do the rest if we already have the tables defined
        }
    }
}
