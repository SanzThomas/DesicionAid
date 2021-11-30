using System.Collections.Generic;

namespace DecisionAid.Models
{
    public class MatchesModel
    {
        public CandidaciesModel Candidacies { get; set; }

        public List<KeyValuePair<EstablishmentModel, List<StudentModel>>> Matches { get; set; }

        public List<KeyValuePair<string, decimal>> StudentSatisfactions { get; set; }
        public List<KeyValuePair<string, decimal>> EstablishmentSatisfactions { get; set; }

        public bool IsStudentPriority { get; set; }
    }
}
