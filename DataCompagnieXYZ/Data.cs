using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompagnieXYZ
{
    public static class Data
    {
        public static List<Employe> GetEmployes()
        {
            List<Employe> employees = new List<Employe>();

            Employe employee = new Employe
            {
                Id = 1,
                Prenom = "Bob",
                Nom = "Jones",
                SalaireAnnuel = 60000.3m,
                estManager = true,
                DepartementId = 1
            };
            employees.Add(employee);
            employee = new Employe
            {
                Id = 2,
                Prenom = "Sarah",
                Nom = "Jameson",
                SalaireAnnuel = 80000.1m,
                estManager = true,
                DepartementId = 2
            };
            employees.Add(employee);
            employee = new Employe
            {
                Id = 3,
                Prenom = "Douglas",
                Nom = "Roberts",
                SalaireAnnuel = 40000.2m,
                estManager = false,
                DepartementId = 2
            };
            employees.Add(employee);
            employee = new Employe
            {
                Id = 4,
                Prenom = "Jane",
                Nom = "Stevens",
                SalaireAnnuel = 30000.2m,
                estManager = false,
                DepartementId = 3
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Departement> GetDepartements()
        {
            List<Departement> departements = new List<Departement>();

            Departement department = new Departement
            {
                Id = 1,
                NomCourt = "HR",
                NomLong = "Human Resources"
            };
            departements.Add(department);
            department = new Departement
            {
                Id = 2,
                NomCourt = "FN",
                NomLong = "Finance"
            };
            departements.Add(department);
            department = new Departement
            {
                Id = 3,
                NomCourt = "TE",
                NomLong = "Technology"
            };
            departements.Add(department);

            return departements;
        }


    }
}
