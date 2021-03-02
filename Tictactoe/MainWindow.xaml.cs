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
            // make sure the player names are inputted
            if (string.IsNullOrEmpty(XPlayerName.Text) || string.IsNullOrEmpty(OPlayerName.Text))
            {
                MessageBox.Show("To start the game, you need to input both player names");
            }
            else 
            {
                GameWindow gameWindow = new GameWindow(XPlayerName.Text, OPlayerName.Text);
                gameWindow.Show();
                this.Close();
            }
        }

       
    }
}
