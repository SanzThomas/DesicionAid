using System;
using System.Collections.Generic;

namespace DecisionAid.Models
{
    public class EstablishmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<StudentModel> Preferencies { get; set; }

        public EstablishmentModel()
        {

        }

        public EstablishmentModel(EstablishmentModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Preferencies = new List<StudentModel>(model.Preferencies);
        }
    }
}
