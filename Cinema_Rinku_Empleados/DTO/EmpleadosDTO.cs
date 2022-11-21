using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cinema_Rinku_Empleados.DTO
{
    public class EmpleadosDTO 
    {
        public int NumeroEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoP { get; set; }
        public string? ApellidoM { get; set; }
        public int RolId { get; set; }
        public string? Rol { get; set; }
    }
}
