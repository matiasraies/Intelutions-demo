using Request.Domain.AggregatesModel.Permission;
using Request.Domain.SeedWork;
using System;

namespace Request.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly RequestContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PermissionRepository(RequestContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Permission Create(Permission permission)
        {
            return _context.Permissions.Add(permission).Entity;
        }

        public void Delete(Permission permission)
        {
            var p = _context.Permissions.Find(permission.Id);

            if (p != null)
                _context.Permissions.Remove(p);
        }
    }
}
