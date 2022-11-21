using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cinema_Rinku_Empleados.DTO
{
    public class MesesDTO
    {
        public int IdMes { get; set; }

        [Display(Name = "Meses")]
        public string? Mes { get; set; }
        public List<SelectListItem>? ListMeses { get; set; }
    }
}
