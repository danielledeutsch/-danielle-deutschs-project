using System.Collections.Generic;
using System.ComponentModel;

namespace ProjectClone.ViewModel
{
    public class EnglishViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<(string, string, string)> _wordTranslations;

        private int _currentWordIndex;
        private int _correctCount;
        public int _questionCounter;
        public string CurrentWord => _wordTranslations[_currentWordIndex].Item1;
        public string CurrentTranslation => _wordTranslations[_currentWordIndex].Item2;
        public string CurrentImagePath => _wordTranslations[_currentWordIndex].Item3;
        public int CorrectCount
        {
            get { return _correctCount; }
            set
            {
                _correctCount = value;
                OnPropertyChanged(nameof(CorrectCount));
            }
        }

        public int QuestionCounter
        {
            get { return _questionCounter; }
            set
            {
                _questionCounter = value;
                OnPropertyChanged(nameof(QuestionCounter));
            }
        }



        public EnglishViewModel()
        {
            // רשימת המילים, תרגומם והתמונה המתארת אותם
            _wordTranslations = new List<(string, string, string)>
            {
                ("bells", "פעמונים","https://i.pinimg.com/564x/3a/5a/24/3a5a244524858d4d15dc02bfcd5eefb3.jpg"),
                ("Santa Claus", "סנטה קלאוס", "https://i.pinimg.com/564x/2d/7c/14/2d7c144e65850b6411a359cf1f2b34dd.jpg"),
                ("snowman", "איש שלג", "https://i.pinimg.com/564x/ce/fd/80/cefd8075dd108929d0bc5d209662e171.jpg"),
                ("present", "מתנה","https://i.pinimg.com/564x/5f/d2/dc/5fd2dc1630c56527c1bb2ade37f64de9.jpg"),
                ("christmas tree", "עץ אשוח", "https://i.pinimg.com/564x/bc/ea/81/bcea81057c5feb6c105b3efaa121ff75.jpg"),
                ("ornament", "קישוט", "https://i.pinimg.com/564x/ad/1b/2f/ad1b2fe9088397e8bdeff6e165384273.jpg"),
                ("deer", "אייל","https://i.pinimg.com/564x/80/b1/f6/80b1f67b2504504e1342656ac9bd5f00.jpg"),
                ("cookie", "עוגיה","https://i.pinimg.com/564x/83/d7/e1/83d7e1b5b9775ac07fba65329966a9f0.jpg"),
                ("family", "משפחה","https://i.pinimg.com/564x/f8/62/03/f86203909aeafa496434dc71ed9e8d6a.jpg"),
                ("chimney", "ארובה","https://i.pinimg.com/564x/5f/be/cb/5fbecb222407950eb277fcf4cd97d66e.jpg")
            };

            _currentWordIndex = 0;
            _correctCount = 0;
            _questionCounter = 0;
        }

        //מעבר למילה הבאה ברשימה
        public void LoadNextWord()
        {
            _currentWordIndex = (_currentWordIndex + 1) % _wordTranslations.Count;
            OnPropertyChanged(nameof(CurrentWord));
            OnPropertyChanged(nameof(CurrentTranslation));
        }

        //פעולה המשומשת כשתובה מוגשת כדי לבדוק אותה
        public bool SubmitAnswer(string submittedTranslation)
        {
            bool isCorrect = submittedTranslation == CurrentTranslation;
            if (isCorrect)
            {
                CorrectCount++;
            }
            QuestionCounter++;
            LoadNextWord();
            return isCorrect;

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
