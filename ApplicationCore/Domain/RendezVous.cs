using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class RendezVous
    {
        public string CodeInfirmiere { get; set; }
        public DateTime DateVaccination { get; set; }
        public int NbrDoses { get; set; }
        [ForeignKey("CitoyenId")]
        public virtual Citoyen Citoyen { get; set; }
        [ForeignKey("VaccinId")]
        public virtual Vaccin Vaccin { get; set; }
        public string CitoyenId { get; set; }
        public int VaccinId { get; set; }
        
    }
}
