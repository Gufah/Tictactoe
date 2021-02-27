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

namespace Tictactoe
{
    /// <summary>
    /// Interaction logic for NameSelector.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();


            // make sure the player names are inputted
            if (string.IsNullOrEmpty(XPlayerName.Text) || string.IsNullOrEmpty(OPlayerName.Text))
            {
                MessageBox.Show("To start the game, you need to input both player names");
            }
            else 
            {          
                gameWindow.Show();
                this.Close();
                Submit();
            }
        }

        private void Submit()
        {
            Player1Name xPlayer = new Player1Name(XPlayerName);
        }
    }
}
