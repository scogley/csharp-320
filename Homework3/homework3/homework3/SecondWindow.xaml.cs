using System;
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

namespace homework3
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;

        }
        
        private void uxListGridViewColumnHeaderClicked(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();

            var gridViewColHeader = e.OriginalSource as GridViewColumnHeader;

            if (gridViewColHeader.Column.Header.ToString() == "Password")
            {
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Password", System.ComponentModel.ListSortDirection.Ascending));
            }
            else if (gridViewColHeader.Column.Header.ToString() == "Name")
            {
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
            }
        }

    }
}
