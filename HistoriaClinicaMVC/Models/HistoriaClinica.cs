using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinicaMVC.Models
{
    public class HistoriaClinica
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }


        public List<Episodio> Episodios { get; set; }
    }
}
