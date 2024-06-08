using CompagnieXYZExtensions;
using DataCompagnieXYZ;
using System.Linq;

namespace XYZCompagnieApplication
{
     class Program
    {
        static void Main(string[] args)
        {
            //On recupere les listes d'employes et de departements
            List<Employe> employesListe = Data.GetEmployes();
            List<Departement> departementsListe = Data.GetDepartements(employesListe);

            //On utilise la methode Filtre de l'extension pour filtrer les employes ayant un salaire annuel inferieur a 50000
            var res = employesListe.Filtre(e => e.SalaireAnnuel < 50000);

            // Utilisation de la méthode Where pour filtrer les departements ayant un nom court de HR ou TE
            var res2 = departementsListe.Where(d => d.NomCourt == "HR" || d.NomCourt == "TE");

            //On utilise la methode Join pour joindre les employes et les departements
            var res3 = from emp in employesListe
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


            //Operateur Average, Max et Min avec Method Syntax
            //var moyenneSalaire = employesListe.Average(e => e.SalaireAnnuel);
            //Console.WriteLine($"La moyenne des salaires annuels est de: {moyenneSalaire}");
            //var plusHautSalaire = employesListe.Max(e => e.SalaireAnnuel);
            //Console.WriteLine($"Le plus haut salaire annuel est de: {plusHautSalaire}");
            //var plusBasSalaire = employesListe.Min(e => e.SalaireAnnuel);
            //Console.WriteLine($"Le plus bas salaire annuel est de: {plusBasSalaire}");

            //Operateur Select et Where avec Method Syntax
            var res4 = employesListe.Select(employe => new
            {
                NomComplet = employe.Prenom + " " + employe.Nom,
                SalaireAnnuelEmp = employe.SalaireAnnuel
            }).Where(e => e.SalaireAnnuelEmp >= 50000);

            //Operateur Select et Where avec Query Syntax
            //
            var res5 = from emp in employesListe
                          where emp.SalaireAnnuel >= 50000
                          select new
                          {
                              NomComplet = emp.Prenom + " " + emp.Nom,
                              SalaireAnnuelEmp = emp.SalaireAnnuel
                          };

            //employesListe.Add(new Employe
            //{
            //    Id = 5,
            //    Prenom = "Jane",
            //    Nom = "Stevens",
            //    SalaireAnnuel = 100000.20m,
            //    estManager = false,
            //    DepartementId = 3
            //});


            ///Execution Differe , donc malgre l'ajout de l'employe après la requete, il est pris en compte
            //var res6 = from emp in employesListe.GetEmployesLesMieuxPaye()
            //              select new
            //              {
            //                  NomComplet = emp.Prenom + " " + emp.Nom,
            //                  SalaireAnnuelEmp = emp.SalaireAnnuel
            //              };

            //employesListe.Add(new Employe
            //{
            //    Id = 5,
            //    Prenom = "Johanne",
            //    Nom = "Guillemont",
            //    SalaireAnnuel = 100000.20m,
            //    estManager = false,
            //    DepartementId = 3
            //});

     

            //Execution Immediat , donc malgre l'ajout de l'employe après la requete, il n'est pas pris en compte
            //var res7 = (from emp in employesListe.GetEmployesLesMieuxPaye()
            //               select new
            //               {
            //                   NomComplet = emp.Prenom + " " + emp.Nom,
            //                   SalaireAnnuelEmp = emp.SalaireAnnuel
            //               }).ToList();

            //employesListe.Add(new Employe
            //{
            //    Id = 5,
            //    Prenom = "Johanne",
            //    Nom = "Guillemont",
            //    SalaireAnnuel = 100000.20m,
            //    estManager = false,
            //    DepartementId = 3
            //});


            //On utilise la methode Join pour joindre les employes et les departements synatxe Method
            var res8 = departementsListe.Join(employesListe,
                depart => depart.Id,
                empl => empl.DepartementId,
                (depart, groupeEmpl) => new
                {
                    GroupeEmp = groupeEmpl,
                    NomDepart = depart.NomLong,
                }
                );

            //On utilise la methode GroupJoin pour joindre les employes et les departements Synthaxe Query
            var res9 = from dept in departementsListe
                            join emp in employesListe
                            on dept.Id equals emp.DepartementId
                            into employeGroup
                            select new
                            {
                                Employes = employeGroup,
                                DepartNom = dept.NomLong
                            };


            //foreach (Departement departement in res2)
            //{
            //    Console.WriteLine($"Id: {departement.Id}");
            //    Console.WriteLine($"Nom Court: {departement.NomCourt}");
            //    Console.WriteLine($"Nom Long: {departement.NomLong}");
            //    Console.WriteLine();
            //}

            //foreach (var item in res3)
            //{
            //    Console.WriteLine($"Prenom: {item.PrenomEmp}");
            //    Console.WriteLine($"Nom: {item.NomEmp}");
            //    Console.WriteLine($"Salaire Annuel: {item.SalaireAnnuelEmp}");
            //    Console.WriteLine($"Est Manager: {item.EmpEstManager}");
            //    Console.WriteLine($"Departement Nom {item.DepNom}");
            //    Console.WriteLine();
            //}

            //foreach (var item in res5)
            //{
            //    Console.WriteLine($"Nom Complet: {item.NomComplet,-20}");
            //    Console.WriteLine($"Salaire Annuel: {item.SalaireAnnuelEmp,10}");
            //    Console.WriteLine();
            //}

            //foreach (Employe employe in res)
            //{
            //    Console.WriteLine($"Prenom: {employe.Prenom}");
            //    Console.WriteLine($"Nom: {employe.Nom}");
            //    Console.WriteLine($"Salaire Annuel: {employe.SalaireAnnuel}");
            //    Console.WriteLine($"Est Manager: {employe.estManager}");
            //    Console.WriteLine($"Departement Id: {employe.DepartementId}");
            //    Console.WriteLine();

            //}

            /////Operateurs de tri OrderBy, ThenBy,ThenByDescending avec Method Syntax
            ////Operateurs de de tri avec Method Syntax
            var res10 = employesListe.Join(departementsListe, e => e.DepartementId, d => d.Id,
                (e, d) => new
                {
                    ID = e.Id,
                    empNom = e.Nom,
                    empPrenom = e.Prenom,
                    empSalaire = e.SalaireAnnuel,
                    DepID = d.Id,
                    DepNom = d.NomLong
                }

            ).OrderByDescending(o => o.DepID).ThenByDescending(o => o.empSalaire);

            //Operateurs de de tri avec Query Syntax
            var res11 = from emp in employesListe
                    join dep in departementsListe
                    on emp.DepartementId equals dep.Id
                    orderby dep.Id descending, emp.SalaireAnnuel descending
                    select new
                    {
                        ID = emp.Id,
                        empNom = emp.Nom,
                        empPrenom = emp.Prenom,
                        empSalaire = emp.SalaireAnnuel,
                        DepID = dep.Id,
                        DepNom = dep.NomLong
                    };

            ////Operateur de regroupement GroupBy avec Method Query
            ///

            var res12 = from emp in employesListe
                        orderby emp.DepartementId
                        group emp by emp.estManager;

            ////Operation de regroupement GroupBy avec Method Syntax
            ///
            var res13 = employesListe.ToLookup(e => e.DepartementId);
            //La difference entre GrouPBy et ToLookup est que GroupBy retourne un IGrouping et ToLookup retourne un ILookup
            //Ce qui permet de faire des recherches plus rapides avec ToLookup
            var res14 = employesListe.GroupBy(e => e.DepartementId);

            //foreach (var item in res12)
            //{
            //    Console.WriteLine($"ID: {item.ID}");
            //    Console.WriteLine($"Nom: {item.empNom}");
            //    Console.WriteLine($"Prenom: {item.empPrenom}");
            //    Console.WriteLine($"Salaire: {item.empSalaire}");
            //    Console.WriteLine($"Departement ID: {item.DepID}");
            //    Console.WriteLine($"Departement Nom: {item.DepNom}");
            //    Console.WriteLine();
            //}

            //foreach (var item in res13)
            //{
            //    Console.WriteLine($"Manager: {item.Key}");
            //    foreach (var emp in item)
            //    {
            //        Console.WriteLine($"\tID Employe : {emp.Id} Nom Complet: {emp.Prenom} {emp.Nom} {emp.DepartementId}");

            //    }

            //}

            ////All, Any, Contains Quantifier Operators
            ////All et Any Operateurs
            //var comparaisonSalaireAnnuel = 40000;

            //bool estVraiAll = employesListe.All(e => e.SalaireAnnuel >= comparaisonSalaireAnnuel);
            //if (estVraiAll)
            //{
            //    Console.WriteLine("Tous les employes ont un salaire annuel superieur ou egale a 40000");
            //}
            //else
            //{
            //    Console.WriteLine("Tous les employes n'ont pas un salaire annuel superieur ou egale a 40000");
            //}

            //bool estVraiAny = employesListe.Any(e => e.SalaireAnnuel >= comparaisonSalaireAnnuel);
            //if (estVraiAny)
            //{
            //  Console.WriteLine("Il y a au moins un employe ayant un salaire annuel superieur ou egale a 40000");
            //}
            //else
            //{
            //   Console.WriteLine("Il n'y a pas d'employe ayant un salaire annuel superieur ou egale a 40000");
            //}

            //var empAChercher = new Employe
            //{
            //    Id = 3,
            //    Prenom = "Douglas",
            //    Nom = "Roberts",
            //    SalaireAnnuel = 40000.2m,
            //    estManager = false,
            //    DepartementId = 2
            //};

            //bool estVraiContains = employesListe.Contains(empAChercher);
            //if (estVraiContains)
            //{
            //    Console.WriteLine("L'employe Douglas Roberts est dans la liste des employes");
            //}
            //else
            //{
            //    Console.WriteLine("L'employe Douglas Roberts n'est pas dans la liste des employes");
            //}

            ////First, FirstOrDefault, Last, LastOrDefault Operators
            //List<int> integerList = new List<int> {3,13,23,17,26,87};

            ////int result = integerList.First(i => i % 2 == 0);
            //// int result = integerList.FirstOrDefault(i => i % 2 == 0);
            //int result = integerList.LastOrDefault(i => i % 2 == 0);

            //if (result != 0)
            //{
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("There are no even numbers in the collection");
            //}

            ////Single, SingleOrDefault Operators

            //var emp = employesListe.SingleOrDefault();

            //if (emp != null)
            //{
            //    Console.WriteLine($"{emp.Id,-5} {emp.Prenom,-10} {emp.Nom,-10}");
            //}
            //else
            //{
            //    Console.WriteLine("Employe n'existe pas dans la collection");
            //}

            /////Operateur d'egalite sur type primitif integer
            ///SequenceEqual 
            ///

            //var intList1 = new List<int> { 1, 2, 3, 4, 5 };
            //var intList2 = new List<int> { 1, 2, 3, 4, 5 };
            //var intList3 = new List<int> { 1, 2, 3, 4, 5, 6 };

            //var boolSequenceEqual = intList1.SequenceEqual(intList2);
            //var boolSequenceEqual2 = intList1.SequenceEqual(intList3);

            //if (boolSequenceEqual)
            //{
            //    Console.WriteLine("La liste 1 est identique a la liste 2");
            //}
            //else
            //{
            //    Console.WriteLine("La liste 1 n'est pas identique a la liste 2");
            //}

            //if (boolSequenceEqual2)
            //{
            //    Console.WriteLine("La liste 1 est identique a la liste 3");
            //}
            //else
            //{
            //    Console.WriteLine("La liste 1 n'est pas identique a la liste 3");
            //}

            /////Operateur d'egalite sur type complexe Type Employe
            ///SequenceEqual 
            ///

            //var empList1 = new List<Employe>
            //{
            //    new Employe
            //    {
            //        Id = 1,
            //        Prenom = "John",
            //        Nom = "Doe",
            //        SalaireAnnuel = 50000.2m,
            //        estManager = true,
            //        DepartementId = 1
            //    },
            //    new Employe
            //    {
            //        Id = 2,
            //        Prenom = "Jane",
            //        Nom = "Doe",
            //        SalaireAnnuel = 60000.2m,
            //        estManager = true,
            //        DepartementId = 1
            //    }
            //};

            //var empList2 = new List<Employe>
            //{
            //    new Employe
            //    {
            //        Id = 1,
            //        Prenom = "John",
            //        Nom = "Doe",
            //        SalaireAnnuel = 50000.2m,
            //        estManager = true,
            //        DepartementId = 1
            //    },
            //    new Employe
            //    {
            //        Id = 2,
            //        Prenom = "Jane",
            //        Nom = "Doe",
            //        SalaireAnnuel = 60000.2m,
            //        estManager = true,
            //        DepartementId = 1
            //    }
            //};

            //var empList3 = new List<Employe>
            //{
            //    new Employe
            //    {
            //        Id = 1,
            //        Prenom = "John",
            //        Nom = "Doe",
            //        SalaireAnnuel = 50000.2m,
            //        estManager = true,
            //        DepartementId = 1
            //    },
            //    new Employe
            //    {
            //        Id = 4,
            //        Prenom = "Jane",
            //        Nom = "Doe",
            //        SalaireAnnuel = 60000.2m,
            //        estManager = true,
            //        DepartementId = 1
            //    }
            //};

            //var boolSequenceEqualEmp = empList1.SequenceEqual(empList2);

            //if (boolSequenceEqualEmp)
            //{
            //    Console.WriteLine("La empliste 1 est identique a la liste 2");
            //}
            //else
            //{
            //    Console.WriteLine("La empliste 1 n'est pas identique a la liste 2");
            //}

            //var boolSequenceEqualEmp2 = empList1.SequenceEqual(empList3);

            //if (boolSequenceEqualEmp2)
            //{
            //    Console.WriteLine("La empliste 1 est identique a la liste 3");
            //}
            //else
            //{
            //    Console.WriteLine("La empliste 1 n'est pas identique a la liste 3");
            //}

            ////Operateur de concatenation Concat
            ///Type primitif int

            //List<int> ints = new List<int>();
            //ints.Add(1);
            //ints.Add(2);
            //ints.Add(3);
            //ints.Add(4);
            //ints.Add(5);

            //List<int> ints2 = new List<int>();
            //ints2.Add(6);
            //ints2.Add(7);
            //ints2.Add(8);
            //ints2.Add(9);
            //ints2.Add(10);

            //var intsConcat = ints.Concat(ints2);

            //foreach (var item in intsConcat)
            //{
            //    Console.WriteLine(item);
            //}

            ////Operateur de concatenation Concat
            ///Type complexe Employe
            ///

            List<Employe> employes = new List<Employe>
            {
                new Employe
                {
                    Id = 1,
                    Prenom = "John",
                    Nom = "Doe",
                    SalaireAnnuel = 50000.2m,
                    estManager = true,
                    DepartementId = 1
                },
                new Employe
                {
                    Id = 2,
                    Prenom = "Jane",
                    Nom = "Doe",
                    SalaireAnnuel = 60000.2m,
                    estManager = true,
                    DepartementId = 1
                }
            };

            List<Employe> employes2 = new List<Employe>
            {
                new Employe
                {
                    Id = 3,
                    Prenom = "Joshua",
                    Nom = "Doe",
                    SalaireAnnuel = 50000.2m,
                    estManager = true,
                    DepartementId = 1
                },
                new Employe
                {
                    Id = 4,
                    Prenom = "Janette",
                    Nom = "Doe",
                    SalaireAnnuel = 60000.2m,
                    estManager = true,
                    DepartementId = 1
                }
            };

            //var employesConcat = employes.Concat(employes2);

            //foreach (var item in employesConcat)
            //{
            //    Console.WriteLine($"{item.Id,-5} {item.Prenom,-10} {item.Nom,-10}");
            //}

            //Operateur d'aggregation Aggregate, Average, Count, LongCount, Max, Min, Sum

            //decimal totalSalaireAnnuel = employesListe.Aggregate<Employe, Decimal>(0, (totalSalaireAnnuel, e) =>
            //{
            //    var bonus = e.estManager ? 0.04m : 0.02m;
            //    totalSalaireAnnuel += e.SalaireAnnuel + (e.SalaireAnnuel * bonus) ;
            //    return totalSalaireAnnuel;
            //});

            //Console.WriteLine($"Le total des salaires annuels(Bonus inclus) est de: {totalSalaireAnnuel}");

            ////Operateur d'aggation avec des chaines de caracteres
            //string data = employesListe.Aggregate<Employe, String, String>("Salaires annuels(Bonus inclus):",
            //    (s,e) =>
            //    {
            //        var bonus = e.estManager ? 0.04m : 0.02m;
            //        return s += $"{e.Prenom} {e.Nom} - {e.SalaireAnnuel + (e.SalaireAnnuel * bonus)}, ";
            //    }, s => s.Substring(0, s.Length - 2)
            //    );

            //Console.WriteLine(data);

            //Average
            //decimal moyenneSalaire = employesListe.Where(e => e.DepartementId == 2).Average(e => e.SalaireAnnuel);
            //Console.WriteLine($"La moyenne des salaires annuels pour le departement 2 est de: {moyenneSalaire}");

            ////Operateur de Generation - DefaultIfEmpty, Empty, Range, Repeat
            ///

            //List<int> ints = new List<int>();
            ////Si la liste est vide, va mettre la valeur par defaut du type primitif int qui est Zero
            //var nouvelleListe = ints.DefaultIfEmpty();
            //Console.WriteLine(nouvelleListe.Count() == 1 && nouvelleListe.First() == 0);
            ////Si la liste est vide, va mettre la valeur par defaut du type primitif int qui est 1000 passe dans la methode defaultIfEmpty
            //var nouvelleListeDefault = new List<int>();
            //var nouvelleListeDefaultIfEmpty = nouvelleListeDefault.DefaultIfEmpty(1000);
            //Console.WriteLine(nouvelleListeDefaultIfEmpty.Count() == 1 && nouvelleListeDefaultIfEmpty.First() == 1000);

            //List<Employe> employesDefaultIfEmpty = new List<Employe>();
            ////Si la liste est vide, va mettre la valeur par defaut du type complexe Employe qui est null
            //var nouvelleListeEmploye = employesDefaultIfEmpty.DefaultIfEmpty();
            //Console.WriteLine(nouvelleListeEmploye.Count() == 1 && nouvelleListeEmploye.First() == null);

            ////Empty
            /////Tester le fonctionnement de la methode Empty
            /////
            //List<Employe> emptyEmployeeList = Enumerable.Empty<Employe>().ToList();
            //emptyEmployeeList.Add(new Employe
            //{
            //    Id = 1,
            //    Prenom = "John",
            //    Nom = "Doe",
            //    SalaireAnnuel = 50000.2m,
            //    estManager = true,
            //    DepartementId = 1
            //});

            //Console.WriteLine(emptyEmployeeList.Count() == 1);

            //Range
            // On genere une liste de 10 entiers allant de 1 a 10
            //var range = Enumerable.Range(1, 10);
            //foreach (var item in range)
            //{
            //    Console.WriteLine(item);
            //}

            ////Repeat
            //// On genere une liste de 10 entiers ayant la valeur 5
            //var repeat = Enumerable.Repeat<String>("Text",10 );
            //foreach (var item in repeat)
            //{
            //    Console.WriteLine(item);
            //}

            //// Set Operators - Distinc, Except, Intersect, Union
            ///

            //Distinct
            //IEnumerable<int> collection1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,10,10,10 };
            //var res15 = collection1.Distinct();
            //foreach (var item in res15)
            //{
            //    Console.WriteLine(item);
            //}

            //Except
            // Le Except va retourner les elements de la premiere collection qui ne sont pas dans la deuxieme collection
            IEnumerable<int> collection1 = new List<int> { 1, 2, 3, 4,5,6 };
            IEnumerable<int> collection2 = new List<int> { 1,2};
            // var res16 = collection1.Except(collection2);
            //foreach (var item in res16)
            //{
            //    Console.WriteLine(item);
            //}

            //Intersect
            // Le Intersect va retourner les elements communs aux deux collections
            // var res17 = collection1.Intersect(collection2);
            //foreach (var item in res17)
            //{
            //    Console.WriteLine(item);
            //}

            //Union
            // Le Union va retourner les elements des deux collections sans doublons
            //var res18 = collection1.Union(collection2);

            //foreach (var item in res18)
            //{
            //    Console.WriteLine(item);
            //}

            ///Operateur de partitionnement - Skip, SkipWhile, Take, TakeWhile
            ///

            //Skip
            // On saute les 5 premiers elements de la collection
            // var res19 = collection1.Skip(5);
            //foreach (var item in res19)
            //{
            //    Console.WriteLine(item);
            //}

            //SkipWhile
            // On saute les elements tant que la condition est vraie
            //var res20 = collection1.SkipWhile(i => i < 5);
            //foreach (var item in res20)
            //{
            //    Console.WriteLine(item);
            //}

            //Take
            // On prend les 4 premiers elements de la collection
            //var res21 = collection1.Take(4);
            //foreach (var item in res21)
            //{
            //    Console.WriteLine(item);
            //}

            //TakeWhile
            // On prend les elements tant que la condition est vraie
            //var res22 = collection1.TakeWhile(i => i <= 2);
            //foreach (var item in res22)
            //{
            //    Console.WriteLine(item);
            //}

            //Operateur de Convesion - ToList, ToDictionary, ToArray

            //ToList
            //Va convertir la collection en liste
            //List<Employe> results = (from emp in employesListe
            //                         where emp.SalaireAnnuel >= 50000
            //                         select emp).ToList();
            //foreach (Employe employe in results)
            //{
            //    Console.WriteLine($"Prenom: {employe.Prenom}");
            //    Console.WriteLine($"Nom: {employe.Nom}");
            //    Console.WriteLine($"Salaire Annuel: {employe.SalaireAnnuel}");
            //    Console.WriteLine($"Est Manager: {employe.estManager}");
            //    Console.WriteLine($"Departement Id: {employe.DepartementId}");
            //    Console.WriteLine();
            //}

            //ToDictionary
            //Va convertir la collection en dictionnaire
            //Dictionary<int, Employe> results2 = (from emp in employesListe
            //                                     where emp.SalaireAnnuel >= 50000
            //                                     select emp).ToDictionary(e => e.Id);
            //foreach (KeyValuePair<int, Employe> employe in results2)
            //{
            //    Console.WriteLine($"Key: {employe.Key} Value: {employe.Value.Prenom} {employe.Value.Nom}");
            //}

            //ToArray
            //Va convertir la collection en tableau
            //Employe[] results3 = (from emp in employesListe
            //                      where emp.SalaireAnnuel >= 50000
            //                      select emp).ToArray();
            //foreach (Employe employe in results3)
            //{
            //    Console.WriteLine($"Prenom: {employe.Prenom}");
            //}

            ////Let clause
            /// Va permettre de stocker des valeurs intermediaires dans une requete

            //var res23 = from emp in employesListe
            //            let initials = emp.Prenom.Substring(0, 1).ToUpper() + emp.Nom.Substring(0, 1).ToUpper()
            //            let salaireAnuelPlusBonus = (!emp.estManager) ? emp.SalaireAnnuel + (emp.SalaireAnnuel * 0.02m) : emp.SalaireAnnuel + (emp.SalaireAnnuel * 0.04m)
            //            where initials == "BJ" && salaireAnuelPlusBonus >= 50000
            //            select new
            //            {
            //                Initiales = initials,
            //                NomComplet = emp.Prenom + " " + emp.Nom,
            //                SalaireAnnuelEtBonus = salaireAnuelPlusBonus

            //            };

            //foreach (var item in res23)
            //{
            //    Console.WriteLine($"Initiales: {item.Initiales}");
            //    Console.WriteLine($"Nom Complet: {item.NomComplet}");
            //    Console.WriteLine($"Salaire Annuel et Bonus: {item.SalaireAnnuelEtBonus}");
            //    Console.WriteLine();
            //}

            ////Clause into
            ///
            //Va permettre de stocker les resultats intermediaires dans une requete
            //On va filtrer les employes ayant un salaire annuel superieur a 50000 et avec le mot clé into on va stocker les resultats dans une variable intermediaire
            //On va ensuite filtrer les employes ayant le statut de manager sur la variable intermediaire et ensuite on selectionne la variable intermediaire

            //var res24 = from emp in employesListe
            //            where emp.SalaireAnnuel > 50000
            //            select emp into empSalairePlusHaut
            //            where empSalairePlusHaut.estManager
            //            select empSalairePlusHaut;

            //foreach (var item in res24)
            //{
            //    Console.WriteLine($"Prenom: {item.Prenom}");
            //    Console.WriteLine($"Nom: {item.Nom}");
            //    Console.WriteLine($"Salaire Annuel: {item.SalaireAnnuel}");
            //    Console.WriteLine($"Est Manager: {item.estManager}");
            //    Console.WriteLine($"Departement Id: {item.DepartementId}");
            //    Console.WriteLine();
            //}

            ////Operateur de Projection - Select, SelectMany
            //Select
            //Va permettre de selectionner les elements d'une collection
            //Ici on selectionne tout les employes faisant partie du departement 2
            //var res25 = departementsListe.Where(d => d.Id == 2).Select(d => d.Employes);
            //foreach (var items in res25)
            //    foreach(var item in items)
            //        Console.WriteLine($"Prenom: {item.Prenom} Nom: {item.Nom} Salaire Annuel: {item.SalaireAnnuel} Est Manager: {item.estManager} Departement Id: {item.DepartementId}");

            //SelectMany
            //Va permettre de selectionner les elements d'une collection de collection
            //Ici on selectionne tout les employes faisant partie du departement 2
            //Le selectMany va permettre de retourner une seule liste d'employes au lieu d'une liste d'employe dans une liste de departement
            var res26 = departementsListe.SelectMany(d => d.Employes);
            foreach (var item in res26)
                Console.WriteLine($"Prenom: {item.Prenom} Nom: {item.Nom} Salaire Annuel: {item.SalaireAnnuel} Est Manager: {item.estManager} Departement Id: {item.DepartementId}");
















            Console.ReadKey();
        }

      
    }


    //Extension Method pour obtenir les employes ayant un salaire annuel superieur ou egal a 50000
    public static class EnumerableCollectionExtensionMethods
    {
        public static IEnumerable<Employe> GetEmployesLesMieuxPaye(this IEnumerable<Employe> employes)
        {
            foreach (Employe employe in employes)
            {
                Console.WriteLine("Acces a l'employe: " + employe.Prenom + employe.Nom);
                if (employe.SalaireAnnuel >= 50000)
                {
                    yield return employe;
                }
            }

        }

    }
}
