using HistoriaClinicaMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinicaMVC.Models
{
    public class MedicoPaciente
    {
        [Key]
        [Required(ErrorMessage = MensajeError.Requerido)]
        public int MedicoId { get; set; }


        [Key]
        [Required(ErrorMessage = MensajeError.Requerido)]
        public int PacienteId { get; set; }


        public Medico Medico { get; internal set; }

        public Paciente Paciente { get; internal set; }

    }
}
