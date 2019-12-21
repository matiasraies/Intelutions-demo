using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AWeb.Models
{
    public class PermissionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public string EmployeeName { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(20)]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Fecha")]
        public DateTime PermissionDate { get; set; }

        public int PermissionTypeId { get; set; }

        [Required]
        [Display(Name = "Permiso")]
        public PermissionType PermissionType { get; set; }

        public IEnumerable<PermissionType> PermissionTypes { get; set; }
    }

    public class PermissionType
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
