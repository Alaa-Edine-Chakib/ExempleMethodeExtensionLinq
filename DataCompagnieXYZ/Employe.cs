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
    }
}
