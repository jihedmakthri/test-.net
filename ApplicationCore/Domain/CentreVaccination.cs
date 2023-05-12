using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public enum TypeVaccin {
        PFizer,Moderna,Jhonson
    }
    public class CentreVaccination
    {
        public int Capacite { get; set; }
        public int CentreVaccinationId { get; set; }
        public int NbChaises { get; set; }
        public int NumTelephone { get; set; }
        public string ResponsableCentre { get; set; }
        [ForeignKey("VaccinsFK")]
        public int VaccinFK { get; set; }
        public virtual ICollection<Vaccin> Vaccins { get; set; }
    }
}
