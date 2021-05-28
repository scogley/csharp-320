using System;
using System.ComponentModel;


namespace ContactApp.Models
{
    public class ContactModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

        // Fix update so background contacts are not updated.
        internal ContactModel Clone()
        {
            return (ContactModel)this.MemberwiseClone();
        }

        private string nameError { get; set; }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";

                            if (Name == null || string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            else if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }

                            return NameError;
                        }
                }

                return null;
            }
        }

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public ContactRepository.ContactModel ToRepositoryModel()
        {
            var repositoryModel = new ContactRepository.ContactModel
            {
                Age = Age,
                CreatedDate = CreatedDate,
                Email = Email,
                Id = Id,
                Name = Name,
                Notes = Notes,
                PhoneNumber = PhoneNumber,
                PhoneType = PhoneType
            };

            return repositoryModel;
        }

        public static ContactModel ToModel(ContactRepository.ContactModel respositoryModel)
        {
            var contactModel = new ContactModel
            {
                Age = respositoryModel.Age,
                CreatedDate = respositoryModel.CreatedDate,
                Email = respositoryModel.Email,
                Id = respositoryModel.Id,
                Name = respositoryModel.Name,
                Notes = respositoryModel.Notes,
                PhoneNumber = respositoryModel.PhoneNumber,
                PhoneType = respositoryModel.PhoneType
            };

            return contactModel;
        }
    }
}