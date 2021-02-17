using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Attributes

        // Set the player turns
        bool player1Turn; // (True if its player1 [X])

        ButtonSymbol[,] status;  // holds the status of the cells in an array

        bool gameOver;      // should return true if game is over

        #endregion

        #region Constructor
        public MainWindow() // default constructor
        {
            InitializeComponent();

            NewGame();
        }


        #endregion

        /// <summary>
        /// Default start of the game
        /// </summary>
        private void NewGame()
        {
            gameOver = false;

            // Set player 1 as current player
            player1Turn = true;

            // create a blank array of free cells
            status = new ButtonSymbol[3,3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    status[i, j] = ButtonSymbol.Free;
                }
            }
                                        
            Box.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                // set default values at game start
                Button.Content = string.Empty;
                Button.Background = Brushes.BurlyWood;                
            });                        
        }

        /// <summary>
        /// What happens when a button is clicked
        /// </summary>
        /// <param name="sender">The clicked cell</param>
        /// <param name="e">its corresponding event</param>
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cell = (Button)sender;
            var column = Grid.GetColumn(cell);
            var row = Grid.GetRow(cell);

            if (gameOver)
            {
                NewGame();
                return;
            }
                
            // assign player turn to X and O
            /*if (player1Turn)
            {
                cell.Content = "X";
                cell.Foreground = Brushes.Black;
            }                
            else
                cell.Content = "O";
            player1Turn = !player1Turn; // player1Turn ^= true | this toggles the bool
            */

            if (player1Turn)
            {
                status[row, column] = ButtonSymbol.Ex;
                cell.Content = "X";
                cell.Foreground = Brushes.Black;
            }
            else
            {
                status[row, column] = ButtonSymbol.Zero;
                cell.Content = "O";
            }

            player1Turn = !player1Turn; // player1Turn ^= true | this toggles the bool

            // Make sure the cells can't be overwritten
            if (status[row, column] != ButtonSymbol.Free)
                return;

            CheckForWinner();
        }


        // Check for winner
        private void CheckForWinner()
        {
            #region Horizontal win check
            ///<summary>
            /// Check for horizontal wins
            /// </summary>

            var horizontal1 = status[0, 0] & status[0, 1] & status[0, 2];
            var horizontal2 = status[1, 0] & status[1, 1] & status[1, 2];
            var horizontal3 = status[2, 0] & status[2, 1] & status[2, 2];

            if (status[0, 0] != ButtonSymbol.Free && (status[0, 0] == horizontal1))   
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            if (status[1, 0] != ButtonSymbol.Free && (status[1, 0] == horizontal2))
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            if (status[2, 0] != ButtonSymbol.Free && (status[2, 0] == horizontal3))
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            #endregion

            #region Vertical win check
            ///<summary>
            /// Check for vertical wins
            /// </summary>

            var vertical1 = status[0, 0] & status[0, 1] & status[0, 2];
            var vertical2 = status[1, 0] & status[1, 1] & status[1, 2];
            var vertical3 = status[2, 0] & status[2, 1] & status[2, 2];

            if (status[0, 0] != ButtonSymbol.Free && (status[0, 0] == vertical1))
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            if (status[0, 1] != ButtonSymbol.Free && (status[0, 1] == vertical2))
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            if (status[0, 2] != ButtonSymbol.Free && (status[0, 2] == vertical3))
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            #endregion

            #region diagonal win check
            ///<summary>
            /// Check for vertical wins
            /// </summary>

            var dia1 = status[0, 0] & status[1, 1] & status[2, 2];
            var dia2 = status[0, 2] & status[1, 1] & status[2, 0];
            
            if (status[0, 0] != ButtonSymbol.Free && (status[0, 0] == dia1))
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            if (status[0, 2] != ButtonSymbol.Free && (status[0, 2] == dia2))
            {
                if (player1Turn)
                {
                    var winner = "Player 1";
                    MessageBox.Show($"{0} wins", winner);
                }
                else
                {
                    var winner = "Player 2";
                    MessageBox.Show($"{0} wins", winner);
                }
                gameOver = true;
            }

            
            #endregion

            if (!status.Any(p => p == ButtonSymbol.Free))
            {
                // Stalemate
                gameOver = true;
                if (player1Turn)
                {
                    MessageBox.Show("Stalemate");
                }
                
                
            }
        }
    }
}
