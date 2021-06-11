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
using Formula1App.Models;

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

        private void LoadDrivers()
        {
            var drivers = App.DriverRepository.GetAll();

            uxDriverList.ItemsSource = drivers
                .Select(t => DriverModel.ToModel(t))
                .ToList();
            uxStatus.Text = drivers.Count.ToString() + " rows";
        }

        private void LoadDrivers(string query)
        {
            var drivers = App.DriverRepository.GetAll(query);

            uxDriverList.ItemsSource = drivers
                .Select(t => DriverModel.ToModel(t))
                .ToList();
            uxStatus.Text = drivers.Count.ToString() + " rows";
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

                //var uiContactModel = ChangeWindow.Driver;

                //var repositoryContactModel = uiContactModel.ToRepositoryModel();

                //App.DriverRepository.Update(repositoryContactModel);
                
                
                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

       

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            var window = new DeleteWindow();
            if(window.ShowDialog() == true)
            {

            }
        }

        private void SortGridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //todo: add stuff here!
        }

        
        private void uxFileListAll_Click(object sender, RoutedEventArgs e)
        {
            LoadDrivers();
        }

        private void uxFileQuit_Click(object sender, RoutedEventArgs e)
        {
            // Exit the app.
            System.Windows.Application.Current.Shutdown();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoadDrivers(uxSearchBox.Text);
        }
    }


}
