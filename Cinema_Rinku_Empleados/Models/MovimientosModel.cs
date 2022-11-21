using Cinema_Rinku_Empleados.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cinema_Rinku_Empleados.Models
{
    public class MovimientosModel: MesesDTO
    {
        public int IdMoviento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Cantidad de entregas")]
        public int CantEntregas { get; set; }

        [Display(Name = "Horas trabajadas")]
        public int Horas { get; set; }

        [Display(Name = "Pago total x entrega")]
        public decimal PagoTotalXEntrega { get; set; }

        [Display(Name = "Pago total x bonos")]
        public decimal PagoTotalXBonos { get; set; }

        [Display(Name = "Retenciones")]
        public decimal Retencion { get; set; }

        [Display(Name = "Vales")]
        public decimal Vale { get; set; }

        [Display(Name = "Sueldo total")]
        public decimal SueldoTotal { get; set; }
    }
}
