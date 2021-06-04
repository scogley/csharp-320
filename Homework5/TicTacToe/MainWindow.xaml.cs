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

        private bool isGameOver = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            reset_game();
            // X goes first, then O.
        }

        private void reset_game()
        {
            // Erase the board and start with X again.
            foreach (Button child in uxGrid.Children)
            {
                child.Content = null;
            }
            player = "X";
            isGameOver = false;
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            // Exit the game.
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // HINT: Notice the Tag and that you ONLY have the Button_Click event. 
            // The tag gives you the row and column. The tag is also an object but as you can see it 
            // is actually a string (unbox it or call ToString). Then you can parse the string into row and column.
            // Remember the Button_Click event has an object sender parameter.That sender object is a Button, 
            // so cast it to a Button and get the Tag object.
            if (!isGameOver)
            {
                Button uxButton = sender as Button;
                string tagString = uxButton.Tag.ToString();
                // Allow placement only on empty spots.
                if (uxButton.Content != null) return;

                // Place the mark on empty spot.
                mark_grid_button(uxButton, tagString);

                // When you get three in a row, you declare a winner. Stop any more actions.
                if (isWinner(uxButton, tagString))
                {
                    uxTurn.Text = player + " is the winner!";
                    isGameOver = true;
                    return;
                }

                swapPlayerForNextTurn();
            }
        }

        private void swapPlayerForNextTurn()
        {
            // Fall here if game is not over. Swap the player variable for next turn.
            if (player == "X") player = "O";
            else if (player == "O") player = "X";
            uxTurn.Text = player + " turn";
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
            // Keep it simple: use existing collection to build a list of button objects with a Content property as the data structure for the game board.
            List<Button> gameBoardButtons = new List<Button>();
            foreach (Button btn in uxGrid.Children)
            {
                gameBoardButtons.Add(btn);
            }
            
            // Checks the adjacent values to determine if win condition is met (3 in a row!).
            switch (tagString)
            {
                case "0,0":
                    if (gameBoardButtons[3].Content == player && gameBoardButtons[6].Content == player) return true;
                    if (gameBoardButtons[1].Content == player && gameBoardButtons[2].Content == player) return true;
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[8].Content == player) return true;
                    break;
                case "0,1":
                    if (gameBoardButtons[0].Content == player && gameBoardButtons[2].Content == player) return true;
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[7].Content == player) return true;
                    break;
                case "0,2":
                    if (gameBoardButtons[0].Content == player && gameBoardButtons[1].Content == player) return true;
                    if (gameBoardButtons[5].Content == player && gameBoardButtons[8].Content == player) return true;
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[6].Content == player) return true;
                    break;
                case "1,0":
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[5].Content == player) return true;
                    if (gameBoardButtons[0].Content == player && gameBoardButtons[6].Content == player) return true;
                    break;
                case "1,1":
                    if (gameBoardButtons[3].Content == player && gameBoardButtons[5].Content == player) return true;
                    if (gameBoardButtons[6].Content == player && gameBoardButtons[2].Content == player) return true;
                    if (gameBoardButtons[0].Content == player && gameBoardButtons[8].Content == player) return true;
                    if (gameBoardButtons[1].Content == player && gameBoardButtons[7].Content == player) return true;
                    break;
                case "1,2":
                    if (gameBoardButtons[2].Content == player && gameBoardButtons[8].Content == player) return true;
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[3].Content == player) return true;
                    break;
                case "2,0":
                    if (gameBoardButtons[3].Content == player && gameBoardButtons[0].Content == player) return true;
                    if (gameBoardButtons[7].Content == player && gameBoardButtons[8].Content == player) return true;
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[2].Content == player) return true;
                    break;
                case "2,1":
                    if (gameBoardButtons[6].Content == player && gameBoardButtons[8].Content == player) return true;
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[1].Content == player) return true;
                    break;
                case "2,2":
                    if (gameBoardButtons[6].Content == player && gameBoardButtons[7].Content == player) return true;
                    if (gameBoardButtons[5].Content == player && gameBoardButtons[2].Content == player) return true;
                    if (gameBoardButtons[4].Content == player && gameBoardButtons[0].Content == player) return true;
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
