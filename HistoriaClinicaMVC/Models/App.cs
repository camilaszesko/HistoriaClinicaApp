using HistoriaClinicaMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinicaMVC.Models
{
    public class App
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = MensajeError.Requerido)]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 2, ErrorMessage = MensajeError.MinMaxString)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = MensajeError.Requerido)]
        [StringLength(40, MinimumLength = 2, ErrorMessage = MensajeError.MinMaxString)]
        public String Direccion { get; set; }

        [Required(ErrorMessage = MensajeError.Requerido)]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 7, ErrorMessage = MensajeError.MinMaxString)]
        public String Telefono { get; set; }

        public List<Paciente> Pacientes { get; set; }

        public List<Medico> Medicos { get; set; }

        public List<Empleado> Empleados { get; set; }


    }
}
