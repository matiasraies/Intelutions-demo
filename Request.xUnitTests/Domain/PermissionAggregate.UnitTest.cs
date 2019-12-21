using Request.Domain.AggregatesModel.Permission;
using Xunit;

namespace Request.xUnitTests.Domain
{
    public class PermissionAggregate
    {
        [Fact]
        public void CreatePermission()
        {
            var employeeName = "";
            var employeeLastName = "";
            var permissionTypeId = 1;

            var permission = new Permission(employeeName, employeeLastName, permissionTypeId);
            Assert.NotNull(permission);
        }
    }
}
