using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CarRentals.Model.DomainObjects;

namespace CarRentals.DataAccess
{
    /// <summary>
    /// DbC ontext is the gateway to the databse
    /// </summary>
    public class CarRentalDbContext : DbContext
    {
        
        public CarRentalDbContext()
            : base("CarRental_Connection_String")
        {
            //This is a hack to fix one Entity
            /*No Entity Framework provider found for the ADO.NET provider with invariant name 'System.Data.SqlClient'. 
             Make sure the provider is registered in the 'entityFramework' section of the application config file. 
             * See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
             * 
             * http://robsneuron.blogspot.com/2013/11/entity-framework-upgrade-to-6.html(Fix came from this post)
             * */
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<CarRentalDbContext>(null);
            
        }

        //Rennish :Add all the DbSet<T> here for Phase I
        public DbSet<CarRentalUser> Users { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //To Do: write a  generic method to do this ??
            //MapToCarRentalUserStoredProcedures.UseStoredProceduresForEntity(modelBuilder);
            modelBuilder.Configurations.Add(new CarRentalUserMap());
            modelBuilder.Configurations.Add(new CarRentalRoleMap());
        }
    }
}