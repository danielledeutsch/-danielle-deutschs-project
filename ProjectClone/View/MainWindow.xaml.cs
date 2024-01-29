using ProjectClone.ViewModel;
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
using System.Windows.Shapes;

namespace ProjectClone.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserViewModel _userViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel();
            
        }

        

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = username_Box.Text;
            string enteredPassword = password_Box.Text;



            if (_userViewModel.AuthenticateUser(enteredUsername, enteredPassword))
            {
                var user = _userViewModel.Users.FirstOrDefault(u => u.Username == enteredUsername);

                FirstWindow firstWindow = new FirstWindow(user);
                firstWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }


        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signupWindow = new SignUpWindow();
            signupWindow.Show();
            Close();
        }
    }
}
