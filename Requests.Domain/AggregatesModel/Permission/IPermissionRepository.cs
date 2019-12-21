using Request.Domain.SeedWork;

namespace Request.Domain.AggregatesModel.Permission
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Permission Create(Permission permission);

        void Delete(Permission permission);
    }
}
