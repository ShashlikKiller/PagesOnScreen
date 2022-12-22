using PagesOnScreen.BackEnd;
using System.Collections.ObjectModel;
using System.Windows;
using WordClassLibrary;

namespace PagesOnScreen.ViewModels
{
    class Game1ViewModel : GameViewModel
    {
        public Game1ViewModel()
        {
            DictionaryForGame = DictionaryRandomize(WordsCollection);
            WordToTranslate = DictionaryForGame[0];
            Time2play = 60;
            Score = 0;
            StartTimer();
        }

        private Word wordToTranslate;
        public Word WordToTranslate
        {
            get
            {
                return wordToTranslate;
            }
            set
            {
                wordToTranslate = value;
                OnPropertyChanged("WordToTranslate");
            }
        }
        private ObservableCollection<Word> dictionaryForGame;
        public ObservableCollection<Word> DictionaryForGame
        {
            get
            {
                return dictionaryForGame;
            }
            set
            {
                dictionaryForGame = value;
                OnPropertyChanged("DictionaryForGame");
            }
        }
        private Command submitAnswer;
        public Command SubmitAnswer
        {
            get
            {
                return submitAnswer ?? (submitAnswer = new Command(obj =>
                {
                    bool answerbool = false;
                    if ((string)obj == WordToTranslate.English)
                    {
                        MessageBox.Show("Правильно!");
                        answerbool = true;
                    }
                    else MessageBox.Show("Неправильно!");
                    Score = ScoreRecalculate(Score, WordToTranslate, answerbool);
                    WordToTranslate = GoToNextWord(WordToTranslate, DictionaryForGame);
            }));
            }
        }
    }
}
