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
        bool playerTurn; // (True if its player1 [X])

        ButtonSymbol[] status;  // holds the status of the cells in an array

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
                cell.Foreground = Brushes.Black;
                playerTurn = false;
            }
            else
            {
                status[cellNumber] = ButtonSymbol.Zero;
                cell.Content = "O";
                playerTurn = true;
            }
            
            

            CheckForWinner();

        }


        // Check for winner
        private void CheckForWinner()
        {
            
            bool isHorizontalWin = HorizontalWin();
            bool isVerticalWin = VerticalWin();
            bool isDiagonalWin = DiagonalWin();

            if (isHorizontalWin || isVerticalWin || isDiagonalWin)
            {                
                var winner = "";

                if (playerTurn)
                    winner = "Player 2";
                else
                    winner = "Player 1";

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

        //private void Navigate(object sender, RoutedEventArgs e)
        //{
        //    var textBox = text1.Text;
        //    var text2Box = text1.Text;
        //    if (textBox == "" || text2Box == "")
        //    {
        //        MessageBox.Show("You need to fill in both player names");
        //    } 
        //    else
        //    {
        //        NameSelector nameSelector = new NameSelector();
        //        nameSelector.Show();
        //        this.Close();
        //    }
        //}

    }
}