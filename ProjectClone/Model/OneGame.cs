using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClone.Model
{
    public class OneGame
    {
        private int num1;
        private int num2;
        private string question;
        private int kidage;

        public int Num1 { get { return num1; } }
        public int Num2 { get { return num2; } }
        public string Question { get { return question; } }
        public double CorrectAnswer { get { return CalculateAnswer(); } }

        public OneGame(int kidage)
        {
            this.kidage = kidage;

            Random random = new Random();

            num1 = random.Next(1, 15);
            GetSecondNumber(random);
            GenerateQuestion();
        }

        public int GetAge()
        {
            return kidage;
        }
        //הפיכת גיל הילד של המשתמש לרמה במשחק
        private int ConvertKidAgeToGrade(int kidAge)
        {
            if (kidAge <= 7)
            {
                return 1;
            }
            else if (kidAge >= 8 && kidAge <= 9)
            {
                return 2;
            }
            else if (kidAge >= 10 && kidAge <= 11)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        private void GetSecondNumber(Random random)
        {
            int grade = ConvertKidAgeToGrade(kidage);
            // לוודא שבכל הרמות חוץ מ-ד המספר השני קטן מהראשון כדי שלא יהיה מצב שהתשובה שלילית
            num2 = grade != 4 ? random.Next(1, num1) : random.Next(1, 15);
        }

        private void GenerateQuestion()
        {
            int grade = ConvertKidAgeToGrade(kidage);
            switch (grade)
            {
                case 1:
                    // רמה א- חיבור
                    question = $"{num1} + {num2} = ";
                    break;
                case 2:
                    // רמה ב- חיסור
                    question = $"{num1} - {num2} = ";
                    break;
                case 3:
                    // רמה ג- כפל
                    question = $"{num1} x {num2} = ";
                    break;
                case 4:
                    // רמה ד- חילוק
                    question = $"{num1 * num2} ÷ {num2} = ";
                    break;
                default:
                    throw new ArgumentException("Invalid grade parameter.");
            }
        }

        private double CalculateAnswer()
        {
            int grade = ConvertKidAgeToGrade(kidage);
            switch (grade)
            {
                case 1:
                    // רמה א
                    return num1 + num2;
                case 2:
                    // רמה ב
                    return num1 - num2;
                case 3:
                    // רמה ג
                    return num1 * num2;
                case 4:
                    // רמה ד
                    // לוודא שהמספר השני לא 0
                    if (num2 != 0)
                    {
                        // לוודא שהתשובה לא תהיה מספר עשרוני
                        return (double)num1 * num2 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return 0;
                    }
                default:
                    throw new ArgumentException("Invalid grade parameter.");
            }
        }
    }
}
