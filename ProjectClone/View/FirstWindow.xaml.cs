using ProjectClone.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectClone.View
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        private User _currentUser;

        public FirstWindow(User user)
        {
            InitializeComponent();
            backgroundGif.MediaEnded += OnMediaEnded;
            backgroundGif.Play();
            
            _currentUser = user;

            // Access the user's first name
            string firstName = _currentUser.FirstName;
            string kidName = _currentUser.KidName;
            WelcomeTextBlock.Text = $"Welcome, {firstName} and {kidName} Please choose a game.";
            
        }
          private void OnMediaEnded(object sender, RoutedEventArgs e)
        {
            //ריסט לגיף כדי שלא להתנע ממסך שחור
            backgroundGif.Position = TimeSpan.FromMilliseconds(1);
            backgroundGif.Play();
        }

        private void Math_Click(object sender, RoutedEventArgs e)
        {

            int kidage = _currentUser.KidAge;
            GameWindow gameWindow = new GameWindow(kidage);
            gameWindow.Owner = this;
            gameWindow.ShowDialog();  // ShowDialog to wait for GameWindow to close


            this.Show();
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            EnglishWindow englishWindow = new EnglishWindow();
            englishWindow.Owner = this;
            englishWindow.ShowDialog();
        }
    }
}
