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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
            uxName.DataContext = user;
            uxNameError.DataContext = user;
            uxContainer.DataContext = user; // now any child control of StackPanel can access he DataContext and bind to it
        }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private void uxTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxName.Text.Length > 0 && uxPassword.Text.Length > 0) uxSubmit.IsEnabled = true;
            else uxSubmit.IsEnabled = false;
        }
    }
}
