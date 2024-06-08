using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompagnieXYZ
{
    public class Employe
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public decimal SalaireAnnuel { get; set; }
        public bool estManager { get; set; }
        public int DepartementId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Employe employe &&
                   Id == employe.Id 
                   && Prenom.ToLower() == employe.Prenom.ToLower() 
                   && Nom.ToLower() == employe.Nom.ToLower()
                   && SalaireAnnuel == employe.SalaireAnnuel 
                   && estManager == employe.estManager 
                   && DepartementId == employe.DepartementId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
