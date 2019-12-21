using Request.Domain.SeedWork;
using System;

namespace Request.Domain.AggregatesModel.Permission
{
    public class Permission : Entity, IAggregateRoot
    {
        private string _employeeName;
        private string _employeeLastName;
        private int? _permissionTypeId;
        private readonly DateTime? _permissionDate;

        #region Getters & Setters
        public PermissionType PermissionType { get; private set; }

        public string EmployeeName() => _employeeName;

        public string EmployeeLastName() => _employeeLastName;

        public int? PermissionTypeId() => _permissionTypeId;

        public DateTime? PermissionDate() => _permissionDate;

        #endregion Getters & Setters

        protected Permission()
        {
               _permissionDate = DateTime.Now;
        }

        public Permission(int permissionId) : this()
        {
            Id = permissionId;
        }

        public Permission(string employeeName, string employeeLastName, int permissionTypeId) : this()
        {
            _employeeName = employeeName;
            _employeeLastName = employeeLastName;
            _permissionTypeId = permissionTypeId;
        }
    }
}
