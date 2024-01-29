using ProjectClone.Model;
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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private UserViewModel _userViewModel;
        public SignUpWindow()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from UI elements (e.g., TextBoxes)
            string firstName = FirstName_box.Text;
            string lastName = LastName_box.Text;
            string kidName = KidName_box.Text;
            string kidAge = KidAge_box.Text;
            string email = Email_box.Text;
            string username = UserName_box.Text;
            string password = Password_box.Text;

            // Call the method in SignUpViewModel
            if (_userViewModel.CreateUser(firstName, lastName, kidName, kidAge, email, username, password))
            {
                User user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    KidName = kidName,
                    KidAge = int.Parse(kidAge),
                    Email = email,
                    Username = username,
                    Password = password
                };
                FirstWindow firstWindow = new FirstWindow(user);
                firstWindow.Show();
                Close();

            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
