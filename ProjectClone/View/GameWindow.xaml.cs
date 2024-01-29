using ProjectClone.Model;
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
using System.Windows.Threading;

namespace ProjectClone.View
{
    public partial class GameWindow : Window
    {
        private OneGame game;
        private int questionCounter;
        private int correctCount;
        public GameWindow(int kidage)
        {
            InitializeComponent();
            // משחק חדש
            game = new OneGame(kidage);
            questionCounter = 0;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            answerTextBox.Text = "";
            // מספר שאלה
            questionNumberTextBlock.Text = $"Question {questionCounter + 1}/10";

            questionTextBlock.Text = game.Question;
            resultTextBlock.Text = "";
            // כשמוצגת שאלה חדשה הגיף והמוזיקה מפסיקים
            backgroundGif.Stop();
            correctSound.Stop();
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(answerTextBox.Text, out int userAnswer))
            {
                if (userAnswer == game.CorrectAnswer)
                {
                    resultTextBlock.Text = "Correct!";
                    correctCount++;
                    resultTextBlock.Visibility = Visibility.Visible;
                    // גיף וסאונד מתנגן אם התשובה נכונה
                    backgroundGif.Visibility = Visibility.Visible;
                    backgroundGif.Play();
                    correctSound.Play();

                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(4); // Adjust the delay as needed
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        DisplayQuestion();
                    };
                    timer.Start();
                }
                else
                {
                    resultTextBlock.Text = "Incorrect.";

                    resultTextBlock.Visibility = Visibility.Visible;
                }


                questionCounter++;

                // לאחר 10 שאלות יגמר המבחן
                if (questionCounter < 10)
                {
                    // Display the next question after a delay
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(2); // Adjust the delay as needed
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        resultTextBlock.Visibility = Visibility.Collapsed;
                        game = new OneGame(game.GetAge());
                        DisplayQuestion();
                    };
                    timer.Start();
                }
                else
                {
                    // לאחר 10 שאלות נגמר
                    MessageBox.Show($"You're done!  You got {correctCount} out of 10 questions correctly!");
                    this.Close();
                }
            }
            else
            {
                // אם הוכנס פרמטר שהוא לא מספר
                MessageBox.Show("Please enter a valid integer for your answer.");
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {

            if (questionCounter < 10)
            {

                game = new OneGame(game.GetAge());
                DisplayQuestion();
            }
            else
            {

                MessageBox.Show("You're done!");
            }
        }
    }
}
