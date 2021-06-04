using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Formula1App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new DriverWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Driver;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.DriverRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ChangeWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Driver;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.DriverRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            //todo: add stuff here!
        }

        private void SortGridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //todo: add stuff here!
        }

        private void uxFileChange_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }


}
