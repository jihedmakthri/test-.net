using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CitoyenService : Service<Citoyen>
    {
        public CitoyenService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public ICollection<Citoyen> Citoyens => GetAll().ToList();

        public ICollection<Citoyen> getCitoyenRDV()
        {
            return null;
        }

    }
}
