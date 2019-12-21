using System;

namespace Request.API.Application.Queries.Permission
{
    /// <summary>
    /// Objeto para suministrar la vista de datos de la clase Permission.
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeLastName { get; set; }

        public int PermissionTypeId { get; set; }

        public DateTime PermissionDate { get; set; }

        public PermissionType PermissionType { get; set; }
    }

    /// <summary>
    /// Objeto para suministrar la vista de datos de la clase PermissionType.
    /// </summary>
    public class PermissionType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public PermissionType() { }
    }
}
