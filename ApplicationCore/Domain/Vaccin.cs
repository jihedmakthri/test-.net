﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
     public class Vaccin
    {
        [DataType(DataType.DateTime)]
        public DateTime DateValidite { get; set; }
        public string Fournisseur { get; set; }
        public int Quantite { get; set; }
        public TypeVaccin TypeVaccin { get; set; }
        public int VaccinId { get; set; }
        [ForeignKey("CentreVaccination")]
        public int CentreDeVacId { get; set; }
        public virtual CentreVaccination CentreVaccination { get; set; }
        public virtual ICollection<RendezVous> RendezVous { get; set; }
    }
}
