using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriverDB;

namespace DriverRepository
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
    }

    public class DriverRepository
    {
        public DriverModel Add(DriverModel contactModel)
        {
            var driverDb = ToDbModel(contactModel);

            DatabaseManager.Instance.TblDriver.Add(driverDb);
            DatabaseManager.Instance.SaveChanges();

            contactModel = new DriverModel
            {
                Id = driverDb.Id,
                CircuitName = driverDb.CircuitName,
                DriverName = driverDb.DriverName,
                TeamName = driverDb.TeamName,
                Position = driverDb.Position,
                Points = driverDb.Points,
                CreatedDate = driverDb.CreatedDate
            };
            return contactModel;
        }

        public List<DriverModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.TblDriver
              .Select(t => new DriverModel
              {
                  Id = t.Id,
                  CircuitName = t.CircuitName,
                  DriverName = t.DriverName,
                  TeamName = t.TeamName,
                  Position = t.Position,
                  Points = t.Points,
                  CreatedDate = t.CreatedDate,
              }).ToList();

            return items;
        }

        public bool Update(DriverModel driverModel)
        {
            var original = DatabaseManager.Instance.TblDriver.Find(driverModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(driverModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int contactId)
        {
            var items = DatabaseManager.Instance.TblDriver
                                .Where(t => t.Id == contactId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.TblDriver.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private TblDriver ToDbModel(DriverModel contactModel)
        {
            var contactDb = new TblDriver
            {
                Id = contactModel.Id,
                CircuitName = contactModel.CircuitName,
                DriverName = contactModel.DriverName,
                TeamName = contactModel.TeamName,
                Position = contactModel.Position,
                Points = contactModel.Points,
                CreatedDate = contactModel.CreatedDate,
            };

            return contactDb;
        }
    }
}
