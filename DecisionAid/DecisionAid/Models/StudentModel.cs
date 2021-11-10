using System;
using System.Collections.Generic;

namespace DecisionAid.Models
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<EstablishmentModel> Preferencies { get; set; }

        public StudentModel()
        {

        }

        public StudentModel(StudentModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Preferencies = new List<EstablishmentModel>(model.Preferencies);
        }
    }
}
