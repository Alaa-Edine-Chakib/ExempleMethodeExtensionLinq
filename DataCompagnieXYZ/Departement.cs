using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompagnieXYZ
{
    public class Departement
    {
        public int Id { get; set; }
        public string NomCourt { get; set; }
        public string NomLong { get; set; }
        public IEnumerable<Employe> Employes { get; set; }
    }
}
