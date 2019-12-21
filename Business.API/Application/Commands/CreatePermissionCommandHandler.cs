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
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, bool>
    {
        private readonly IPermissionRepository _permissionRepository;

        /// <summary>
        /// Controlador que procesa el comando cuando el cliente ejecuta la orden de creacion de permiso.
        /// </summary>
        /// <remarks>
        /// Uso de DI para inyectar repositorios de persistencia de infraestructura.
        /// </remarks>
        /// <param name="permissionRepository">Repositorio de persistencia de Permisos.</param>
        public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        /// <summary>
        /// Manejador para comando CreatePermissionCommand. Almacena el objeto en DB.
        /// </summary>
        /// <param name="command">Instancia de comando para ser ejecutado.</param>
        /// <param name="cancellationToken">indica o notifica que las operaciones en curso deberían cancelarse.</param>
        /// <returns></returns>
        public async Task<bool> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var permission = new Permission(command.EmployeeName, command.EmployeeLastName, command.PermissionTypeId);

                _permissionRepository.Create(permission);

                return await _permissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
            catch { return false; }
        }
    }
}
