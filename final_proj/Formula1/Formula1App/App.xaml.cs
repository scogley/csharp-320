using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Formula1App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DriverRepository.DriverRepository contactRepository;

        static App()
        {
            contactRepository = new DriverRepository.DriverRepository();
        }

        public static DriverRepository.DriverRepository DriverRepository
        {
            get
            {
                return contactRepository;
            }
        }

    }
}
