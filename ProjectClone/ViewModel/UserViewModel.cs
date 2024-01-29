using ProjectClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectClone.ViewModel
{
    class UserViewModel
    {
        private List<User> _UsersList;

        public UserViewModel()
        {
            _UsersList = new List<User>
            {
                new User { KidAge  = 10, FirstName = "danielle", LastName = "deutsch", Username  = "danielle1", Password  = "london9876", Email  = "danielle.com", KidName ="yonatan" },
                new User { KidAge  = 2, FirstName = "roni", LastName = "levi", Username  = "roni3", Password  = "12345", Email = "roni@gmail.com", KidName ="ori" },
                new User { KidAge  = 3, FirstName = "sarah", LastName = "cain", Username  = "sarahcain", Password  = "wherearetheavocados", Email = "sarah.com", KidName ="roey" },
                new User { KidAge  = 4, FirstName = "jacob", LastName = "miles", Username  ="jaconwashere", Password  = "23082009", Email  = "jacob@gmail.com", KidName ="len" },
            };
        }

        public List<User> Users
        {
            get { return _UsersList; }
            set { _UsersList = value; }
        }

        //פעולה הבודקת אם משתמש קיים לפי השם משתמש וסיסמא שהוכנסה בחלון הראשון
        public bool AuthenticateUser(string enteredUsername, string enteredPassword)
        {
            // Check if the email exists in the list of users
            var user = _UsersList.FirstOrDefault(u => u.Username == enteredUsername);

            if (user != null)
            {
                // בדיקת הסיסמא
                if (user.Password == enteredPassword)
                {
                    
                    return true;
                }

            }

           
            return false;
        }


        //פעולה שקולטת משתמש חדש ומאמתת את הפרטים שלו
        public bool CreateUser(string firstName, string lastName, string kidName, string kidAgeText, string email, string username, string password)
        {
            //האם כל הנתונים מולאו
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(kidName) ||
                string.IsNullOrEmpty(kidAgeText) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            //האם האימייל כבר קיים
            if (_UsersList.Any(u => u.Email == email))
            {
                MessageBox.Show("Email already exists. Please choose a different email.");
                return false;
            }

            //האם הסיסמא עומדת בתנאים
            if (password.Length < 6 || password.Length > 10 || !password.Any(char.IsUpper) || !password.Any(char.IsDigit))
            {
                MessageBox.Show("Password must be between 6-10 characters, contain at least one capital letter, and at least one number.");
                return false;
            }

            if (!int.TryParse(kidAgeText, out int kidAge))
            {
                MessageBox.Show("Invalid Kid's Age. Please enter a valid number.");
                return false;
            }
            return true;

        }
    }
}

