using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class VaccinService : Service<Vaccin>
    {
        private IUnitOfWork _unitOfWork;
        public VaccinService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public ICollection<Vaccin> Vaccins => GetAll().ToList();
        public string validiter(int vaccinId)
        {
            Vaccin vac = GetById(vaccinId);
            if (vac != null && vac.Quantite > 0 && vac.DateValidite > DateTime.Now) {
                return "valide";
            }
            else
            {
                return "non-valide";
            }
            
                
        }


    }
}
