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
        /// Lance l'algorithme avec des préférences aléatoires.
        /// </summary>
        [HttpPost]
        public ActionResult GenerateSolution(List<StudentModel> students, List<EstablishmentModel> establishments)
        {
            var model = UpdatePreferencies(students, establishments);

            var result = CalculateMatchesByStudents(model);

            GetStudentSatisfaction(result);
            GetEstablishmentSatisfaction(result);

            //return Json(new { model });

            return View("Result", result);
        }

        [HttpPost]
        public ActionResult GenerateCandidacies(int count)
        {
            var model = new CandidaciesModel
            {
                Students = new List<StudentModel>(),
                Establishments = new List<EstablishmentModel>()
            };

            for (int i = 1; i <= count; i++)
            {
                AddStudent(model, "Etudiant " + i);
                AddEstablishment(model, "Etablissement " + i);
            }

            AddRandomPreferencies(model);

            return PartialView(model);
        }

        private static void AddStudent(CandidaciesModel model, string name)
        {
            model.Students.Add(new StudentModel
            {
                Id = System.Guid.NewGuid(),
                Name = name,
                Preferencies = new List<EstablishmentModel>()
            });
        }

        private static void AddEstablishment(CandidaciesModel model, string name)
        {
            model.Establishments.Add(new EstablishmentModel
            {
                Id = System.Guid.NewGuid(),
                Name = name,
                Preferencies = new List<StudentModel>()
            });
        }

        private static void AddRandomPreferencies(CandidaciesModel model)
        {
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

        private static CandidaciesModel UpdatePreferencies(List<StudentModel> students, List<EstablishmentModel> establishments)
        {
            var model = new CandidaciesModel
            {
                Students = new List<StudentModel>(),
                Establishments = new List<EstablishmentModel>()
            };

            foreach (var student in students)
            {
                var preferencyIds = new List<Guid>(student.Preferencies.Select(p => p.Id));

                student.Preferencies.Clear();
                foreach (var preferencyId in preferencyIds)
                {
                    student.Preferencies.Add(establishments.First(e => e.Id == preferencyId));
                }
                
                model.Students.Add(student);
            }

            foreach (var establishment in establishments)
            {
                var preferencyIds = new List<Guid>(establishment.Preferencies.Select(p => p.Id));

                establishment.Preferencies.Clear();
                foreach (var preferencyId in preferencyIds)
                {
                    establishment.Preferencies.Add(students.First(e => e.Id == preferencyId));
                }

                model.Establishments.Add(establishment);
            }

            return model;
        }

        private static MatchesModel CalculateMatchesByStudents(CandidaciesModel model)
        {
            var freeStudents = new List<StudentModel>(model.Students);
            model.Students = new List<StudentModel>(model.Students.Select(s => new StudentModel(s)));

            var matches = new MatchesModel 
            {
                Candidacies = model,
                Matches = new List<KeyValuePair<StudentModel, EstablishmentModel>>()
            };

            while (matches.Matches.Count < model.Students.Count)
            {
                var propositions = new List<KeyValuePair<StudentModel, EstablishmentModel>>();
                
                foreach (var freeStudent in freeStudents)
                {
                    var bestChoice = freeStudent.Preferencies.FirstOrDefault();
                    freeStudent.Preferencies.Remove(bestChoice);

                    propositions.Add(new KeyValuePair<StudentModel, EstablishmentModel>(freeStudent, bestChoice));
                }

                foreach (var establishment in model.Establishments)
                {
                    var bestOrder = -1;

                    foreach (var proposition in propositions.Where(p => p.Value == establishment))
                    {
                        var order = establishment.Preferencies.IndexOf(proposition.Key);

                        if (bestOrder == -1 || order < bestOrder)
                        {
                            bestOrder = order;
                        }
                    }

                    if (bestOrder != -1)
                    {
                        var bestStudent = establishment.Preferencies.ElementAt(bestOrder);

                        if (matches.Matches.Any(m => m.Value == establishment))
                        {
                            var previousMatch = matches.Matches.First(m => m.Value == establishment);
                            var previousBestOrder = establishment.Preferencies.IndexOf(previousMatch.Key);

                            if (bestOrder < previousBestOrder)
                            {
                                matches.Matches.Remove(previousMatch);
                                freeStudents.Add(previousMatch.Key);

                                matches.Matches.Add(new KeyValuePair<StudentModel, EstablishmentModel>(bestStudent, establishment));
                                freeStudents.Remove(bestStudent);
                            }
                        } 
                        else
                        {
                            matches.Matches.Add(new KeyValuePair<StudentModel, EstablishmentModel>(bestStudent, establishment));
                            freeStudents.Remove(bestStudent);
                        }
                    }
                }
            }

            return matches;
        }

        private static MatchesModel CalculateMatchesByEstablishment(CandidaciesModel model)
        {
            var freeEstablishments = new List<EstablishmentModel>(model.Establishments);
            model.Establishments = new List<EstablishmentModel>(model.Establishments.Select(s => new EstablishmentModel(s)));

            var matches = new MatchesModel
            {
                Candidacies = model,
                Matches = new List<KeyValuePair<StudentModel, EstablishmentModel>>()
            };

            while (matches.Matches.Count < model.Establishments.Count)
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
                    var bestOrder = -1;

                    foreach (var proposition in propositions.Where(p => p.Key == student))
                    {
                        var order = student.Preferencies.IndexOf(proposition.Value);

                        if (bestOrder == -1 || order < bestOrder)
                        {
                            bestOrder = order;
                        }
                    }

                    if (bestOrder != -1)
                    {
                        var bestEstablishment = student.Preferencies.ElementAt(bestOrder);

                        if (matches.Matches.Any(m => m.Key == student))
                        {
                            var previousMatch = matches.Matches.First(m => m.Key == student);
                            var previousBestOrder = student.Preferencies.IndexOf(previousMatch.Value);

                            if (bestOrder < previousBestOrder)
                            {
                                matches.Matches.Remove(previousMatch);
                                freeEstablishments.Add(previousMatch.Value);

                                matches.Matches.Add(new KeyValuePair<StudentModel, EstablishmentModel>(student, bestEstablishment));
                                freeEstablishments.Remove(bestEstablishment);
                            }
                        }
                        else
                        {
                            matches.Matches.Add(new KeyValuePair<StudentModel, EstablishmentModel>(student, bestEstablishment));
                            freeEstablishments.Remove(bestEstablishment);
                        }
                    }
                }
            }

            return matches;
        }

        private static void GetStudentSatisfaction(MatchesModel model)  // TODO : Calculer la moyenne de chaque satisfaction
        {
            model.StudentSatisfactions ??= new List<KeyValuePair<string, decimal>>();
            var maxCounter = model.Matches.Count;

            foreach (var match in model.Matches)
            {
                var student = model.Candidacies.Students.FirstOrDefault(s => s.Id == match.Key.Id);
                var establishment = model.Candidacies.Establishments.FirstOrDefault(s => s.Id == match.Value.Id);

                decimal order = student.Preferencies.Select(p => p.Id).ToList().IndexOf(establishment.Id);
                decimal moins = maxCounter - order;
                decimal divise = moins / maxCounter;
                decimal pourcent = divise * 100;

                model.StudentSatisfactions.Add(new KeyValuePair<string, decimal>(student.Name, pourcent));
            }
        }

        private static void GetEstablishmentSatisfaction(MatchesModel model)
        {
            model.EstablishmentSatisfactions = new List<KeyValuePair<string, decimal>>();
            var maxCounter = model.Matches.Count;

            foreach (var match in model.Matches)
            {
                var student = model.Candidacies.Students.FirstOrDefault(s => s.Id == match.Key.Id);
                var establishment = model.Candidacies.Establishments.FirstOrDefault(s => s.Id == match.Value.Id);

                decimal order = establishment.Preferencies.Select(p => p.Id).ToList().IndexOf(student.Id);
                decimal moins = maxCounter - order;
                decimal divise = moins / maxCounter;
                decimal pourcent = divise * 100;

                model.EstablishmentSatisfactions.Add(new KeyValuePair<string, decimal>(establishment.Name, pourcent));
            }
        }
    }
}
