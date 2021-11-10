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
        /// <returns></returns>
        public ActionResult RandomPreferencies()
        {
            var model = GenerateCandidacies();

            AddRandomPreferencies(model);
            var result = CalculateMatches(model);

            return View("Result", result);
        }

        public CandidaciesModel GenerateCandidacies()
        {
            var model = new CandidaciesModel
            {
                Students = new List<StudentModel>(),
                Establishments = new List<EstablishmentModel>()
            };

            AddStudent(model, "Gérard");
            AddStudent(model, "Michel");
            AddStudent(model, "Jean");
            AddStudent(model, "Philippe");
            AddStudent(model, "Nizar");

            AddEstablishment(model, "E1");
            AddEstablishment(model, "E2");
            AddEstablishment(model, "E3");
            AddEstablishment(model, "E4");
            AddEstablishment(model, "E5");

            return model;
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

        private static MatchesModel CalculateMatches(CandidaciesModel model)
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

                        if (bestOrder != -1 && order < bestOrder)
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
    }
}
