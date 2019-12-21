using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Application.Queries.Permission
{
    /// <summary>
    /// Implementacion de IPermissionQueries. Se utiliza Dapper como micro ORM para consultas mas livianas
    /// y eficientes.
    /// </summary>
    public class PermissionQueries : IPermissionQueries
    {
        private string _connectionString = string.Empty;

        public PermissionQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        /// <summary>
        /// Obtiene el objeto Permission para el Id dado, si existe.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Permission> GetPermissionAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"SELECT * FROM request.Permission p
                        LEFT JOIN request.PermissionType pt
	                        ON p.PermissionTypeId = pt.Id
                        WHERE p.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    return null;

                return MapPermission(result?.First());
            }
        }

        /// <summary>
        /// Obtiene una lista de objetos Permission.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                    @"SELECT * FROM request.Permission p
                        LEFT JOIN request.PermissionType pt
	                        ON p.PermissionTypeId = pt.Id"
                );

                if (result.AsList().Count == 0)
                    return null;

                return MapPermissions(result);
            }
        }

        /// <summary>
        /// Retorna todos los objetos PermissionType a partir de la base.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PermissionType>> GetPermissionTypesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<PermissionType>("SELECT * FROM request.PermissionType");
            }
        }

        /// <summary>
        /// Mapeo un dynamic como un objeto Permission. 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private Permission MapPermission(dynamic result)
        {
            if (result == null)
                return null;

            var permission = new Permission
            {
                Id = result.Id,
                EmployeeName = result.EmployeeName,
                EmployeeLastName = result.EmployeeLastName,
                PermissionDate = result.PermissionDate,
                PermissionTypeId = result.PermissionTypeId
            };

            permission.PermissionType = new PermissionType { Id = result.Id, Description = result.Description };

            return permission;
        }

        /// <summary>
        /// Mapeo un dynamic como una lista de objetos Permission. 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private IEnumerable<Permission> MapPermissions(dynamic result)
        {
            if (result == null)
                return null;

            List<Permission> lp = new List<Permission>();

            foreach (var p in result)
            {
                lp.Add(MapPermission(p));
            }

            return lp;
        }
    }
}
