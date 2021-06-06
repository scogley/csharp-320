﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Formula1App.Models;

namespace Formula1App
{
    /// <summary>
    /// Interaction logic for ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        public ChangeWindow()
        {
            InitializeComponent();
            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public DriverModel Driver { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {

            var driver = App.DriverRepository.GetDriverById(uxDriverId.Text);
            
          
            driver.DriverName = uxDriverName.Text;
            driver.TeamName = uxTeamName.Text;
            driver.Position = uxPosition.Text;

            driver.CreatedDate = DateTime.Now;


            var uiContactModel = driver;

            var repositoryContactModel = uiContactModel.ToRepositoryModel();

            App.DriverRepository.Update(repositoryContactModel);

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }
    }
}
