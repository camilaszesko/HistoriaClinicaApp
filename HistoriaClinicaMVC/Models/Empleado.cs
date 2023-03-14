using HistoriaClinicaMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinicaMVC.Models
{
    public class Empleado : Persona

    {
        [Required(ErrorMessage = MensajeError.Requerido)]
        public int Legajo { get; set; }

       

    }
}
