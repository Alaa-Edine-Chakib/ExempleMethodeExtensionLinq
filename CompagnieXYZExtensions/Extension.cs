using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompagnieXYZExtensions
{
    public static class Extension
    {
        public static List<T> Filtre<T>(this List<T> valeurs, Func<T, bool> func)
        {
            List<T> listeFiltre = new List<T>();
            foreach (T valeur in valeurs)
            {
                if (func(valeur))
                {
                    listeFiltre.Add(valeur);
                }
            }
            return listeFiltre;
        }
    }
}
