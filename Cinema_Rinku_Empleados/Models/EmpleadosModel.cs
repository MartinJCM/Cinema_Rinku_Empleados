using Cinema_Rinku_Empleados.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cinema_Rinku_Empleados.Models
{
    public class EmpleadosModel : MovimientosModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Numero Empleado")]
        public int NumeroEmpleado { get; set; }
        public int NumeroEmpleado2 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Apellido Materno")]
        public string? ApellidoP { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Apellido Paterno")]
        public string? ApellidoM { get; set; }

        public string? FechaAlta { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Roles")]
        public int RolId { get; set; }
        public List<SelectListItem>? ListRoles { get; set; }

        [Display(Name = "Roles")]
        public string? Rol { get; set; }

        public List<SelectListItem>? ListEmpleados { get; set; }
    }
}
