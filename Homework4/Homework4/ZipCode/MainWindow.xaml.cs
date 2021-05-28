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
using System.Text.RegularExpressions;

namespace ZipCode
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

        private void uxZipText_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Using regex to check these patterns:
            // US Zip Codes ##### or #####-####
            // Canadian Postal Codes: A#B#C#
            // The window contains a Submit button that is only enabled when a valid zip code or postal code is entered.

            // So for example, a user could enter 98122 or 98012-4444 or T1R2X4 and the Submit button would be enabled.

            string inputText = uxZipText.Text;
            string inputPattern = @"[0-9][0-9][0-9][0-9][0-9]|[0-9][0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]|[A-Z][0-9][A-Z][0-9][A-Z][0-9]";

            // Regular Expression object
            
            Regex findMatches = new Regex(inputPattern);

            int count = 0;
            foreach (var match in findMatches.Matches(inputText))
            {
                count++;
            }
            if (count == 1)
            {
                // MessageBox.Show($"found {count} matches");
                uxSubmitButton.IsEnabled = true;
            }

        }
    }
}
