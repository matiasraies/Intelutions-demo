using MediatR;
using Request.Domain.AggregatesModel.Permission;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Request.API.Application.Commands
{
    /// <summary>
    /// Command Handler.
    /// </summary>
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, bool>
    {
        private readonly IPermissionRepository _permissionRepository;

        /// <summary>
        /// Controlador que procesa el comando cuando el cliente ejecuta la orden de eliminacion de permiso.
        /// </summary>
        /// <remarks>
        /// Uso de DI para inyectar repositorios de persistencia de infraestructura.
        /// </remarks>
        /// <param name="permissionRepository">Repositorio de persistencia de Permisos.</param>
        public DeletePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        /// <summary>
        /// Manejador para comando DeletePermissionCommand. Elimina el objeto en DB.
        /// </summary>
        /// <param name="command">Instancia de comando para ser ejecutado.</param>
        /// <param name="cancellationToken">indica o notifica que las operaciones en curso deberían cancelarse.</param>
        /// <returns></returns>
        public async Task<bool> Handle(DeletePermissionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var permission = new Permission(command.PermissionId);

                _permissionRepository.Delete(permission);

                return await _permissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
            catch { return false; }
        }
    }
}
