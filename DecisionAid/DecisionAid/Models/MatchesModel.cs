using System.Collections.Generic;

namespace DecisionAid.Models
{
    public class MatchesModel
    {
        public CandidaciesModel Candidacies { get; set; }

        public List<KeyValuePair<StudentModel, EstablishmentModel>> Matches { get; set; }
    }
}
