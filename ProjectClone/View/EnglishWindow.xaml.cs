using ProjectClone.ViewModel;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ProjectClone.View
{
    public partial class EnglishWindow : Window
    {
        private EnglishViewModel _viewModel;

        public EnglishWindow()
        {
            InitializeComponent();
            _viewModel = new EnglishViewModel();
            DataContext = _viewModel;

            // המילה הראשונה תופיע על המסך כשהחלון נפתח
            DisplayWord();

        }


        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Visibility = Visibility.Visible;

            // בדיקת התשובה שהוגשה
            bool isCorrect = _viewModel.SubmitAnswer(TranslationTextBox.Text);
            if (isCorrect)
            {
                // יופיע  הודעה המראה על נכונות התשובה
                ResultTextBlock.Text = "Correct!";
                correctSound.Play();
            }
            else
            {
                //יופיע הודעה המראה על אי נכונות התשובה
                ResultTextBlock.Text = "Incorrect!";

            }

            // לבטל את האופציה ללחיצה על הכפתור בזמן שהמילה הבאה נטענת
            SubmitButton.IsEnabled = false;

            // חיכוי שני שניות בין הצגת כל מילה
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2); 
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                SubmitButton.IsEnabled = true; 
                DisplayWord();

                // בדיקה האם הגענו לסיום השאלון
                if (_viewModel.QuestionCounter >= 10)
                {
                    // התוצאות יופיעו בסוף השאלון
                    MessageBox.Show($"You got {_viewModel.CorrectCount} out of 10 correct!");

                }
            };
            timer.Start(); 
        }


        private void DisplayWord()
        {
            questionNumberTextBlock.Text = $"Question {_viewModel._questionCounter + 1}/10";
            correctSound.Stop();
            CurrentWordTextBlock.Text = _viewModel.CurrentWord;
            TranslationTextBox.Text = ""; // כאשר מילה מוצגת הט

            WordImage.Source = new BitmapImage(new Uri(_viewModel.CurrentImagePath, UriKind.RelativeOrAbsolute));
            
            if (ResultTextBlock.Visibility == Visibility.Visible)
            {
                ResultTextBlock.Text = ""; 
                ResultTextBlock.Visibility = Visibility.Collapsed; 
            }
        }

        private void instructions_click(object sender, RoutedEventArgs e)
        {
           InstructionsBlock.Visibility = Visibility.Visible;
        }
    }
}