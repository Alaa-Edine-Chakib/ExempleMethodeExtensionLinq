using CompagnieXYZExtensions;
using DataCompagnieXYZ;
using System.Linq;

namespace XYZCompagnieApplication
{
     class Program
    {
        static void Main(string[] args)
        {
            //List<Employe> employesListe = Data.GetEmployes();

            //var employeFiltre = employesListe.Where(e => e.SalaireAnnuel < 50000);

            //foreach (Employe employe in employeFiltre)
            //{
            //    Console.WriteLine($"Prenom: {employe.Prenom}");
            //    Console.WriteLine($"Nom: {employe.Nom}");
            //    Console.WriteLine($"Salaire Annuel: {employe.SalaireAnnuel}");
            //    Console.WriteLine($"Est Manager: {employe.estManager}");
            //    Console.WriteLine($"Departement Id: {employe.DepartementId}");
            //    Console.WriteLine();

            //}

            //List<Departement> departementsListe = Data.GetDepartements();
            //var departementFiltre = departementsListe.Where(d => d.NomCourt == "HR" || d.NomCourt == "TE");

            //foreach (Departement departement in departementFiltre)
            //{
            //    Console.WriteLine($"Id: {departement.Id}");
            //    Console.WriteLine($"Nom Court: {departement.NomCourt}");
            //    Console.WriteLine($"Nom Long: {departement.NomLong}");
            //    Console.WriteLine();
            //}

            List<Employe> employesListe = Data.GetEmployes();
            List<Departement> departementsListe = Data.GetDepartements();

            var resultList = from emp in employesListe
                             join dep in departementsListe
                             on emp.DepartementId equals dep.Id
                             select new
                             {
                                 PrenomEmp = emp.Prenom,
                                 NomEmp = emp.Nom,
                                 SalaireAnnuelEmp = emp.SalaireAnnuel,
                                 EmpEstManager = emp.estManager,
                                 DepNom = dep.NomLong
                             };

            foreach (var item in resultList)
            {
                Console.WriteLine($"Prenom: {item.PrenomEmp}");
                Console.WriteLine($"Nom: {item.NomEmp}");
                Console.WriteLine($"Salaire Annuel: {item.SalaireAnnuelEmp}");
                Console.WriteLine($"Est Manager: {item.EmpEstManager}");
                Console.WriteLine($"Departement Nom {item.DepNom}");
                Console.WriteLine();
            }

            var moyenneSalaire = employesListe.Average(e => e.SalaireAnnuel);
            Console.WriteLine($"La moyenne des salaires annuels est de: {moyenneSalaire}");
            var plusHautSalaire = employesListe.Max(e => e.SalaireAnnuel);
            Console.WriteLine($"Le plus haut salaire annuel est de: {plusHautSalaire}");
            var plusBasSalaire = employesListe.Min(e => e.SalaireAnnuel);
            Console.WriteLine($"Le plus bas salaire annuel est de: {plusBasSalaire}");

            Console.ReadKey();
        }
    }
}
