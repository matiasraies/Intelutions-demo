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
    public class CreatePermissionCommand : IRequest<bool>
    {
        [DataMember]
        public string EmployeeName { get; private set; }

        [DataMember]
        public string EmployeeLastName { get; private set; }

        [DataMember]
        public int PermissionTypeId { get; private set; }

        public CreatePermissionCommand() { }

        public CreatePermissionCommand(string employeeName, string employeeLastName, int permissionTypeId)
        {
            EmployeeName = employeeName;
            EmployeeLastName = employeeLastName;
            PermissionTypeId = permissionTypeId;
        }
    }
}
