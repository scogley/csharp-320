using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1App.Models
{
    public class DriverModel
    {
        public int Id { get; set; }
        public string CircuitName { get; set; }
        public string DriverName { get; set; }
        public string TeamName { get; set; }
        public string Position { get; set; }
        public string Points { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public DriverRepository.DriverModel ToRepositoryModel()
        {
            var repositoryModel = new DriverRepository.DriverModel
            {
                Id = Id,
                CircuitName = CircuitName,
                DriverName = DriverName,
                TeamName = TeamName,
                Position = Position,
                Points = Points,
                CreatedDate = CreatedDate
            };

            return repositoryModel;
        }

        public static DriverModel ToModel(DriverRepository.DriverModel respositoryModel)
        {
            var contactModel = new DriverModel
            {

                Id = respositoryModel.Id,
                CircuitName = respositoryModel.CircuitName,
                DriverName = respositoryModel.DriverName,
                TeamName = respositoryModel.TeamName,
                Position = respositoryModel.Position,
                Points = respositoryModel.Points,
                CreatedDate = respositoryModel.CreatedDate
            };

            return contactModel;
        }
    }
}
