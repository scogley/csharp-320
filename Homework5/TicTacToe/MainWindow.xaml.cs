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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // The current player X or O. X is default.
        private string player = "X";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            clear_board();
            // X goes first, then O.

            // When you get three in a row, you declare a winner. Stop any more actions.
        }

        private void clear_board()
        {
            // Erase the board and start with X again.
            foreach (Button child in uxGrid.Children)
            {
                child.Content = null;
            }
            player = "X";
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            // Exit the game.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // HINT: Notice the Tag and that you ONLY have the Button_Click event. 
            // The tag gives you the row and column. The tag is also an object but as you can see it 
            // is actually a string (unbox it or call ToString). Then you can parse the string into row and column.
            // Remember the Button_Click event has an object sender parameter.That sender object is a Button, 
            // so cast it to a Button and get the Tag object.

            Button uxButton = sender as Button;
            string tagString = uxButton.Tag.ToString();
            mark_grid_button(uxButton, tagString);
            isWinner(uxButton, tagString);
                
            // swap the player variable for next turn.
            if (player == "X") player = "O";
            else if (player == "O") player = "X";
        }

        private void mark_grid_button(Button uxButton, string tagString)
        {
            switch (tagString)
            {
                case "0,0":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "0,1":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "0,2":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "1,0":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "1,1":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "1,2":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "2,0":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "2,1":
                    {
                        uxButton.Content = player;
                        break;
                    }
                case "2,2":
                    {
                        uxButton.Content = player;
                        break;
                    }

                default:
                    break;
            }
        }

        bool isWinner(Button uxButton, string tagString)
        {
            switch (tagString)
            {
                default:
                    break;
            }
            return false;
        }
    }
}
