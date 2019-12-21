using MediatR;
using System.Runtime.Serialization;

namespace Request.API.Application.Commands
{
    /// <summary>
    /// Comentario de patrones DDD y CQRS: Tenga en cuenta que se recomienda implementar comandos inmutables.
    /// Para ello se tienen los setters de los atributos como privado. Solo se puede actulizar los datos al 
    /// crear el comando por su constructor.
    /// </summary>
    [DataContract]
    public class DeletePermissionCommand : IRequest<bool>
    {
        [DataMember]
        public int PermissionId { get; private set; }

        public DeletePermissionCommand() { }

        public DeletePermissionCommand(int permissionId)
        {
            PermissionId = permissionId;
        }
    }
}
