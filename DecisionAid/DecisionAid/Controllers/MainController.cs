using DecisionAid.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionAid.Controllers
{
    /// <summary>
    /// Gère les algorithmes principaux.
    /// </summary>
    public class MainController : Controller
    {
        /// <summary>
        /// Un modèle utilisé pour reconstruire les condidatures et leurs préférences.
        /// </summary>
        private static CandidaciesModel TemporaryModel { get; set; }

        private static int Capacity { get; set; }

        /// <summary>
        /// Construit un modèle partiel, étape par étape.
        /// </summary>
        /// <param name="student">Un étudiant.</param>
        /// <param name="establishment">Un établissement.</param>
        [HttpPost]
        public void BuildModel(StudentModel student, EstablishmentModel establishment)
        {
            TemporaryModel.Students.Add(student);
            TemporaryModel.Establishments.Add(establishment);
        }

        /// <summary>
        /// Génère une solution en donnant la priorité aux étudiants.
        /// </summary>
        [HttpPost]
        public ActionResult GenerateSolutionByStudents()
        {
            var model = UpdatePreferencies();

            var result = CalculateMatchesByStudents(model);

            GetStudentSatisfaction(result);
            GetEstablishmentSatisfaction(result);

            return View("Result", result);
        }

        /// <summary>
        /// Génère une solution en donnant la priorité aux établissements.
        /// </summary>
        [HttpPost]
        public ActionResult GenerateSolutionByEstablishments()
        {
            var model = UpdatePreferencies();
            var result = CalculateMatchesByEstablishment(model);

            // Ordonne les étudiants et les établissements
            result.Candidacies.Students = result.Candidacies.Students.OrderBy(e => e.Name).ToList();
            result.Candidacies.Establishments = result.Candidacies.Establishments.OrderBy(e => e.Name).ToList();

            GetStudentSatisfaction(result);
            GetEstablishmentSatisfaction(result);

            return View("Result", result);
        }

        /// <summary>
        /// Génère des candidatures.
        /// </summary>
        /// <param name="count">Le nombre de candidats.</param>
        [HttpPost]
        public ActionResult GenerateCandidacies(int count, int capacity)
        {
            Capacity = capacity;

            // Crée un modèle
            var model = new CandidaciesModel
            {
                Students = new List<StudentModel>(),
                Establishments = new List<EstablishmentModel>()
            };

            // Remplit ce modèle
            for (int i = 1; i <= count; i++)
            {
                AddEstablishment(model, "Etablissement " + i);
                AddStudent(model, "Etudiant " + i);
            }

            AddRandomPreferencies(model);

            return PartialView(model);
        }

        /// <summary>
        /// Ajoute un étudiant au modèle.
        /// </summary>
        /// <param name="model">Le modèle.</param>
        /// <param name="name">L' nom de l'étudiant.</param>
        private static void AddStudent(CandidaciesModel model, string name)
        {
            model.Students.Add(new StudentModel
            {
                Id = System.Guid.NewGuid(),
                Name = name,
                Preferencies = new List<EstablishmentModel>()
            });
        }

        /// <summary>
        /// Ajoute un établissement au modèle.
        /// </summary>
        /// <param name="model">Le modèle.</param>
        /// <param name="name">L' nom de l'établissement.</param>
        private static void AddEstablishment(CandidaciesModel model, string name)
        {
            model.Establishments.Add(new EstablishmentModel
            {
                Id = System.Guid.NewGuid(),
                Name = name,
                Preferencies = new List<StudentModel>()
            });
        }

        /// <summary>
        /// Ajoute des préférences aléatoires entre les étudiants et les établissements.
        /// </summary>
        /// <param name="model">Le modèle.</param>
        private static void AddRandomPreferencies(CandidaciesModel model)
        {
            // Ajoute les préférences aléatoires de chaque étudiant
            foreach (StudentModel student in model.Students)
            {
                var rand = new Random();
                var tempList = new List<EstablishmentModel>(model.Establishments);

                while (student.Preferencies.Count < model.Establishments.Count)
                {
                    var randomValue = rand.Next(0, tempList.Count);
                    var chosenEstablishment = tempList.ElementAt(randomValue);
                    tempList.RemoveAt(randomValue);

                    student.Preferencies.Add(chosenEstablishment);
                }
            }

            // Ajoute les préférences aléatoires de chaque établissement
            foreach (EstablishmentModel establishment in model.Establishments)
            {
                var rand = new Random();
                var tempList = new List<StudentModel>(model.Students);

                while (establishment.Preferencies.Count < model.Students.Count)
                {
                    var randomValue = rand.Next(0, tempList.Count);
                    var chosenStudent = tempList.ElementAt(randomValue);
                    tempList.RemoveAt(randomValue);

                    establishment.Preferencies.Add(chosenStudent);
                }
            }
        }

        /// <summary>
        /// Initialise le modèle provisoire.
        /// </summary>
        [HttpPost]
        public void InitModel()
        {
            TemporaryModel = new CandidaciesModel
            {
                Students = new List<StudentModel>(),
                Establishments = new List<EstablishmentModel>()
            };
        }

        /// <summary>
        /// Met à jour les préférences en fonction du modèle provisoire.
        /// </summary>
        /// <returns>Le modèle reconstruit.</returns>
        public CandidaciesModel UpdatePreferencies()
        {
            // Crée un modèle
            var model = new CandidaciesModel
            {
                Students = new List<StudentModel>(),
                Establishments = new List<EstablishmentModel>()
            };

            // Ajoute les étudiants
            foreach (var student in TemporaryModel.Students)
            {
                var preferencyIds = new List<Guid>(student.Preferencies.Select(p => p.Id));

                // Ajoute les préférences d'un étudiant
                student.Preferencies.Clear();
                foreach (var preferencyId in preferencyIds)
                {
                    student.Preferencies.Add(TemporaryModel.Establishments.First(e => e.Id == preferencyId));
                }

                model.Students.Add(student);
            }

            // Ajoute les établissements
            foreach (var establishment in TemporaryModel.Establishments)
            {
                var preferencyIds = new List<Guid>(establishment.Preferencies.Select(p => p.Id));

                // Ajoute les préférences d'un établissement
                establishment.Preferencies.Clear();
                foreach (var preferencyId in preferencyIds)
                {
                    establishment.Preferencies.Add(TemporaryModel.Students.First(e => e.Id == preferencyId));
                }

                model.Establishments.Add(establishment);
            }

            return model;
        }

        /// <summary>
        /// Calcule les correspondances en donnant la priorité aux étudiants.
        /// </summary>
        /// <param name="model">Le modèle.</param>
        /// <returns>Le modèle de correspondances.</returns>
        private static MatchesModel CalculateMatchesByStudents(CandidaciesModel model)
        {
            var freeStudents = new List<StudentModel>(model.Students);
            model.Students = new List<StudentModel>(model.Students.Select(s => new StudentModel(s)));

            var matches = new MatchesModel 
            {
                Candidacies = model,
                Matches = new List<KeyValuePair<EstablishmentModel, List<StudentModel>>>(),
                IsStudentPriority = true
            };

            while (matches.Matches.Count < matches.Candidacies.Students.Count || (matches.Matches.Any(m => m.Value.Count < Capacity) && freeStudents.SelectMany(s => s.Preferencies).Any()))
            {
                var propositions = new List<KeyValuePair<StudentModel, EstablishmentModel>>();
                
                // Chaque étudiant propose son premier choix
                foreach (var freeStudent in freeStudents)
                {
                    var bestChoice = freeStudent.Preferencies.FirstOrDefault();
                    freeStudent.Preferencies.Remove(bestChoice);

                    propositions.Add(new KeyValuePair<StudentModel, EstablishmentModel>(freeStudent, bestChoice));
                }

                // Chaque établissement choisit l'étudiant qui lui convient le mieux
                foreach (var establishment in model.Establishments)
                {
                    var bestOrders = new List<int>();

                    foreach (var proposition in propositions.Where(p => p.Value == establishment))
                    {
                        var propositionOrder = establishment.Preferencies.IndexOf(proposition.Key);

                        if (bestOrders.Count < Capacity || bestOrders.Any(b => b > propositionOrder))
                        {
                            bestOrders.Add(propositionOrder);
                        }
                    }

                    if (bestOrders.Any())
                    {
                        foreach (var bestOrder in bestOrders)
                        {
                            var bestStudent = establishment.Preferencies.ElementAt(bestOrder);

                            // Vérifie qu'un étudiant précédemment choisi n'est pas moins bien classé
                            if (matches.Matches.Any(m => m.Key == establishment && m.Value.Count >= Capacity))
                            {
                                var previousMatch = matches.Matches.First(m => m.Key == establishment);
                                var worstMatch = new StudentModel();
                                var newBestOrder = bestOrder;

                                foreach (var previousMatchElement in previousMatch.Value)
                                {
                                    var previousBestOrder = establishment.Preferencies.IndexOf(previousMatchElement);

                                    if (newBestOrder < previousBestOrder)
                                    {
                                        newBestOrder = previousBestOrder;
                                        worstMatch = previousMatchElement;
                                    }
                                }

                                if (worstMatch.Id != default)
                                {
                                    previousMatch.Value.Remove(worstMatch);
                                    freeStudents.Add(worstMatch);

                                    matches.Matches.First(m => m.Key == establishment).Value.Add(bestStudent);
                                }
                            }
                            else if (matches.Matches.SelectMany(m => m.Value.Where(v => v.Id == bestStudent.Id)).Count() < Capacity)
                            {
                                if (matches.Matches.Any(m => m.Key == establishment))
                                {
                                    matches.Matches.First(m => m.Key == establishment).Value.Add(bestStudent);
                                }
                                else
                                {
                                    matches.Matches.Add(new KeyValuePair<EstablishmentModel, List<StudentModel>>(establishment, new List<StudentModel> { bestStudent }));
                                }
                            }

                            if (matches.Matches.Where(m => m.Value.Contains(bestStudent)).Count() >= Capacity)
                            {
                                freeStudents.Remove(bestStudent);
                            }
                        }
                    }
                }
            }

            return matches;
        }

        /// <summary>
        /// Calcule les correspondances en donnant la priorité aux établissements.
        /// </summary>
        /// <param name="model">Le modèle.</param>
        /// <returns>Le modèle de correspondances.</returns>
        private static MatchesModel CalculateMatchesByEstablishment(CandidaciesModel model)
        {
            var freeEstablishments = new List<EstablishmentModel>(model.Establishments);
            model.Establishments = new List<EstablishmentModel>(model.Establishments.Select(s => new EstablishmentModel(s)));

            var matches = new MatchesModel
            {
                Candidacies = model,
                Matches = new List<KeyValuePair<EstablishmentModel, List<StudentModel>>>()
            };

            while (matches.Matches.Count < matches.Candidacies.Establishments.Count || (matches.Matches.Any(m => m.Value.Count < Capacity) && freeEstablishments.SelectMany(s => s.Preferencies).Any()))
            {
                var propositions = new List<KeyValuePair<StudentModel, EstablishmentModel>>();

                foreach (var freeEstablishment in freeEstablishments)
                {
                    var bestChoice = freeEstablishment.Preferencies.FirstOrDefault();
                    freeEstablishment.Preferencies.Remove(bestChoice);

                    propositions.Add(new KeyValuePair<StudentModel, EstablishmentModel>(bestChoice, freeEstablishment));
                }

                foreach (var student in model.Students)
                {
                    var bestOrders = new List<int>();

                    foreach (var proposition in propositions.Where(p => p.Key == student))
                    {
                        var propositionOrder = student.Preferencies.IndexOf(proposition.Value);

                        if (bestOrders.Count < Capacity || bestOrders.Any(b => b > propositionOrder))
                        {
                            bestOrders.Add(propositionOrder);
                        }
                    }

                    if (bestOrders.Any())
                    {
                        foreach (var bestOrder in bestOrders)
                        {
                            var bestEstablishment = student.Preferencies.ElementAt(bestOrder);

                            if (matches.Matches.Any(m => m.Key.Id == bestEstablishment.Id && m.Value.Count >= Capacity))
                            {
                                var previousMatch = matches.Matches.First(m => m.Key.Id == bestEstablishment.Id);
                                var worstMatch = new StudentModel();

                                foreach (var previousMatchElement in previousMatch.Value)
                                {
                                    var previousBestOrder = bestEstablishment.Preferencies.IndexOf(previousMatchElement);
                                    var newBestOrder = bestOrder;

                                    if (newBestOrder < previousBestOrder)
                                    {
                                        newBestOrder = previousBestOrder;
                                        worstMatch = previousMatchElement;
                                    }
                                }

                                if (worstMatch.Id != default)
                                {
                                    var previousBestOrder = bestEstablishment.Preferencies.Select(p => p.Id).ToList().IndexOf(worstMatch.Id);

                                    if (bestOrder < previousBestOrder)
                                    {
                                        matches.Matches.Remove(previousMatch);
                                        freeEstablishments.Add(previousMatch.Key);

                                        matches.Matches.Add(new KeyValuePair<EstablishmentModel, List<StudentModel>>(bestEstablishment, new List<StudentModel> { student }));
                                    }
                                }
                            }
                            else if (matches.Matches.SelectMany(m => m.Value).Where(v => v.Id == student.Id).Count() < Capacity)
                            {
                                if (matches.Matches.Any(m => m.Key.Id == bestEstablishment.Id))
                                {
                                    matches.Matches.First(m => m.Key.Id == bestEstablishment.Id).Value.Add(student);
                                }
                                else
                                {
                                    matches.Matches.Add(new KeyValuePair<EstablishmentModel, List<StudentModel>>(bestEstablishment, new List<StudentModel> { student }));
                                }
                            }

                            if (matches.Matches.First(m => m.Key == bestEstablishment).Value.Count >= Capacity)
                            {
                                freeEstablishments.Remove(bestEstablishment);
                            }
                        }
                    }
                }
            }

            return matches;
        }

        /// <summary>
        /// Calcule la satisfaction des étudiants.
        /// </summary>
        /// <param name="model">Le modèle.</param>
        private static void GetStudentSatisfaction(MatchesModel model)
        {
            model.StudentSatisfactions ??= new List<KeyValuePair<string, decimal>>();
            var maxCounter = model.Matches.Count;
            var sum = 0m;

            foreach (var student in model.Candidacies.Students)
            {
                var chosenEstablishments = model.Matches.Where(m => m.Value.Any(v => v.Id == student.Id)).Select(m => m.Key).ToList();
                var bestChoice = -1;

                foreach (var chosenEstablishment in chosenEstablishments)
                {
                    var newChoice = student.Preferencies.IndexOf(chosenEstablishment);

                    if (bestChoice == -1 || newChoice < bestChoice)
                    {
                        bestChoice = newChoice;
                    }
                }

                if (bestChoice == -1)
                {
                    model.StudentSatisfactions.Add(new KeyValuePair<string, decimal>(student.Name, 0));
                    continue;
                }

                decimal moins = maxCounter - bestChoice;
                decimal divise = moins / maxCounter;
                decimal pourcent = divise * 100;

                sum += pourcent;

                model.StudentSatisfactions.Add(new KeyValuePair<string, decimal>(student.Name, Math.Round(pourcent, 2)));
            }

            decimal average = sum / maxCounter;
            model.StudentSatisfactions.Add(new KeyValuePair<string, decimal>("Moyenne", Math.Round(average, 2)));
        }

        /// <summary>
        /// Calcule la satisfaction de établissements.
        /// </summary>
        /// <param name="model">Le modèle.</param>
        private static void GetEstablishmentSatisfaction(MatchesModel model)
        {
            model.EstablishmentSatisfactions = new List<KeyValuePair<string, decimal>>();
            var maxCounter = model.Matches.Count;
            var sum = 0m;

            foreach (var establishment in model.Candidacies.Establishments)
            {
                var chosenStudents = model.Matches.Where(m => m.Key.Id == establishment.Id).SelectMany(m => m.Value).ToList();
                var bestChoice = -1;

                foreach (var chosenStudent in chosenStudents)
                {
                    var newChoice = establishment.Preferencies.IndexOf(chosenStudent);

                    if (bestChoice == -1 || newChoice < bestChoice)
                    {
                        bestChoice = newChoice;
                    }
                }

                if (bestChoice == -1)
                {
                    model.EstablishmentSatisfactions.Add(new KeyValuePair<string, decimal>(establishment.Name, 0));
                    continue;
                }

                decimal moins = maxCounter - bestChoice;
                decimal divise = moins / maxCounter;
                decimal pourcent = divise * 100;

                sum += pourcent;

                model.EstablishmentSatisfactions.Add(new KeyValuePair<string, decimal>(establishment.Name, Math.Round(pourcent, 2)));
            }

            decimal average = sum / maxCounter;
            model.EstablishmentSatisfactions.Add(new KeyValuePair<string, decimal>("Moyenne", Math.Round(average, 2)));
        }
    }
}
