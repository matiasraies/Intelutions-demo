using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Request.Domain.AggregatesModel.Permission;
using Request.Domain.SeedWork;
using Request.Infrastructure.EntityConfigurations;
using System.Threading;
using System.Threading.Tasks;

namespace Request.Infrastructure
{
    public class RequestContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "request";

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionType> PermissionTypes { get; set; }

        public RequestContext(DbContextOptions<RequestContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

    /// <summary>
    /// Si una clase que implementa esta interfaz se encuentra en el mismo proyecto que el
    /// DbContext derivado o en el proyecto de inicio de la aplicación, las herramientas omiten el otro. 
    /// formas de crear DbContext y usar el generador en tiempo de diseño en su lugar.
    /// https://docs.microsoft.com/es-es/ef/core/miscellaneous/cli/dbcontext-creation
    /// </summary>
    public class OrderingContextDesignFactory : IDesignTimeDbContextFactory<RequestContext>
    {
        public RequestContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RequestContext>()
                .UseSqlServer("Server=.;Initial Catalog=RequestDb;Integrated Security=true");

            return new RequestContext(optionsBuilder.Options);
        }
    }
}
