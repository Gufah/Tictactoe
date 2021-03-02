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
    public partial class GameWindow : Window
    {
        #region Private Attributes

        // Set the player turns
        bool playerTurn; // (True if its player1 [X])

        ButtonSymbol[] status;  // holds the status of the cells in an array

        private readonly string player1Name;

        private readonly string player2Name;

        private int player1Score = 0;

        private int player2Score = 0;

        #endregion

        #region Constructor
        public GameWindow(string player1Name, string player2Name) // default constructor
        {
            InitializeComponent();

            this.player1Name = player1Name;
            this.player2Name = player2Name;
            NewGame();
        }

        public GameWindow() // default constructor
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
            XPlayer.Text = player1Name;
            OPlayer.Text = player2Name;

            player1ScoreTb.Text = player1Score.ToString();
            player2ScoreTb.Text = player2Score.ToString();
            // Set player 1 as current player
            playerTurn = true;

            // create a blank array of free cells
            status = new ButtonSymbol[9];

            for (int i = 0; i < status.Length; i++)
            {
              status[i] = ButtonSymbol.Free;       
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
            var cellNumber = column + (row * 3);

            // Make sure the cells can't be overwritten
            if (status[cellNumber] != ButtonSymbol.Free)
                return;

            if (playerTurn)
            {
                status[cellNumber] = ButtonSymbol.Ex;
                cell.Content = "X";
                cell.Foreground = Brushes.DarkRed;
                playerTurn = false;
            }
            else
            {
                status[cellNumber] = ButtonSymbol.Zero;
                cell.Content = "O";
                cell.Foreground = Brushes.DarkRed;
                playerTurn = true;
            }                 

            CheckForWinner();
        }


        // Determine the winner of the game
        private void CheckForWinner()
        {
            
            bool isHorizontalWin = HorizontalWin();
            bool isVerticalWin = VerticalWin();
            bool isDiagonalWin = DiagonalWin();

            if (isHorizontalWin || isVerticalWin || isDiagonalWin)
            {                
                var winner = "";

                if (playerTurn) 
                { 
                    winner = player2Name;
                    player2Score++;
                }
                else
                {
                    winner = player1Name;
                    player1Score++;
                }
                    
                MessageBox.Show($"{winner} wins");
                NewGame();
            }

            if (!status.Any(p => p == ButtonSymbol.Free))
            {
                MessageBox.Show("Draw!");
                NewGame();
            }
        }

        private bool DiagonalWin()
        {
            if (status[0] != ButtonSymbol.Free && (status[0] & status[4] & status[8]) == status[0])
            {
                return true;
            }
            if (status[2] != ButtonSymbol.Free && (status[2] & status[4] & status[6]) == status[2])
            {
                return true;
            }            
            return false;
        }

        private bool VerticalWin()
        {
            if (status[0] != ButtonSymbol.Free && (status[0] & status[3] & status[6]) == status[0])
            {
                return true;
            }
            if (status[1] != ButtonSymbol.Free && (status[1] & status[4] & status[7]) == status[1])
            {
                return true;
            }
            if (status[2] != ButtonSymbol.Free && (status[2] & status[5] & status[8]) == status[2])
            {
                return true;
            }
            return false;
        }

        private bool HorizontalWin()
        {
            if (status[0] != ButtonSymbol.Free && (status[0] & status[1] & status[2]) == status[0])
            {
                return true;                 
            }
            if (status[3] != ButtonSymbol.Free && (status[3] & status[4] & status[5]) == status[3])
            {
                return true;
            }
            if (status[6] != ButtonSymbol.Free && (status[6] & status[7] & status[8]) == status[6])
            {
                return true;
            }
            return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            player1Score = 0;
            player2Score = 0;
            NewGame();            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }    
    }
}