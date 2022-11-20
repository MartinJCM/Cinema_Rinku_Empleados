using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cinema_Rinku_Empleados.Models
{
    public class EmpleadosModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Numero Empleado")]
        public int NumeroEmpleado { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Apellido Materno")]
        public string? ApellidoP { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Apellido Paterno")]
        public string? ApellidoM { get; set; }

        //[Display(Name = "Fecha Ingreso")]
        public string? FechaAlta { get; set; }

        [Display(Name = "Roles")]
        public int RolId { get; set; }
        public List<SelectListItem>? ListRoles { get; set; }

        [Display(Name = "Roles")]
        public string? Rol { get; set; }
    }
}
