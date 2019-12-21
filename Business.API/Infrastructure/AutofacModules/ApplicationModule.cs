using Autofac;
using Request.API.Application.Queries.Permission;
using Request.Domain.AggregatesModel.Permission;
using Request.Infrastructure.Repositories;

namespace Request.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new PermissionQueries(QueriesConnectionString))
                .As<IPermissionQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PermissionRepository>()
                .As<IPermissionRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
