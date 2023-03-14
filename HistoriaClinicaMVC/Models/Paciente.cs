using System.ComponentModel.DataAnnotations.Schema;

namespace HistoriaClinicaMVC.Models
{
    public class Paciente : Persona
    {
       
        public Cobertura ObraSocial { get; set; }


        [ForeignKey("HistoriaClinica")]
        public int? HistoriaClinicaId { get; set; }


        public List<MedicoPaciente> MedicosPaciente { get; set; }

    }
}
