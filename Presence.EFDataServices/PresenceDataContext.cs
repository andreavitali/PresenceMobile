using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using Presence.Entities.Models;
using Presence.EFDataServices.Mappings;
using NLog;

namespace Presence.EFDataServices
{
    public partial class PresenceDataContext : DbContext
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public PresenceDataContext(string connectionString)
            : base(connectionString)
        {
            //Database.Log += logInfo => System.Diagnostics.Debug.WriteLine(logInfo);
            Database.Log += logInfo => _logger.Trace(logInfo);
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;            
        }

        public bool IsSqlServer
        {
            get { return this.Database.Connection.GetType() == typeof(System.Data.SqlClient.SqlConnection); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Get schema name
            string schema = IsSqlServer ? "dbo" : "ARTECHUSER";

            // Get mapping classes and register them
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type, schema);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            // Get complex type configuration classes and register them
            modelBuilder.Configurations.Add(new ContractDataMap());

            // Disable cascade on delete
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
