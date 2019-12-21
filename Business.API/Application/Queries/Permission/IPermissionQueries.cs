using System.Collections.Generic;
using System.Threading.Tasks;

namespace Request.API.Application.Queries.Permission
{
    /// <summary>
    /// Interfaz para definir las queries de consulta para Permisos.
    /// </summary>
    public interface IPermissionQueries
    {
        /// <summary>
        /// Obtener un permiso mediante su Id.
        /// </summary>
        /// <param name="id">Id del objeto permiso para identificarlo.</param>
        /// <returns></returns>
        Task<Permission> GetPermissionAsync(int id);

        /// <summary>
        /// Obtiene todos los permisos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Permission>> GetPermissionsAsync();

        /// <summary>
        /// Obtiene todos los tipos de permisos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PermissionType>> GetPermissionTypesAsync();
    }
}
