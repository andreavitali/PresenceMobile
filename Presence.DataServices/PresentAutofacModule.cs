using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Autofac;
using Presence.EFDataServices;
using Presence.Entities.Interfaces;
using PRP;

namespace Presence.DataServices
{
    public class PresenceAutofacModule : Module
    {
        private string _connectionString;
        private string _iniFilesPath;

        public PresenceAutofacModule(string connectionString, string iniFilesPath)
        {
            this._connectionString = connectionString;
            this._iniFilesPath = iniFilesPath;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // EF DataContext
            Database.SetInitializer<PresenceDataContext>(new PresenceDBInitializer());
            builder.RegisterType<PresenceDataContext>().WithParameter("connectionString", _connectionString).InstancePerLifetimeScope();

            // Services
            builder.RegisterType<EFDataServices.CauseService>().As<ICauseService>().InstancePerLifetimeScope();
            builder.RegisterType<EFDataServices.LookupService>().As<ILookupService>().InstancePerLifetimeScope();
            builder.RegisterType<EFDataServices.PersonService>().As<IPersonService>().InstancePerLifetimeScope();
            builder.RegisterType<EFDataServices.UserManagementService>().As<IUserManagementService>().SingleInstance();
            builder.RegisterType<EFDataServices.SettingsService>().As<ISettingsService>().WithParameter("iniFilesPath", _iniFilesPath).SingleInstance();
        }
    }
}
