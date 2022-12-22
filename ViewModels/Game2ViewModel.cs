using PagesOnScreen.BackEnd;
using System.Collections.ObjectModel;
using System.Windows;
using WordClassLibrary;
using static WordClassLibrary.Word;

namespace PagesOnScreen.ViewModels
{
    class Game2ViewModel : GameViewModel
    {
        private ObservableCollection<Word> dictionaryForGame1;
        private ObservableCollection<Word> dictionaryForGame2;
        private Word word1;
        private Word word2;

        public ObservableCollection<Word> DictionaryForGame1
        {
            get
            {
                return dictionaryForGame1;
            }
            set
            {
                dictionaryForGame1 = value;
                OnPropertyChanged("DictionaryForGame1");
            }
        }

        public ObservableCollection<Word> DictionaryForGame2
        {
            get
            {
                return dictionaryForGame2;
            }
            set
            {
                dictionaryForGame2 = value;
                OnPropertyChanged("DictionaryForGame2");
            }
        }

        //        <Application.Resources>
        //    <!-- ... -->
        //    <s:Boolean x:Key="True">True</s:Boolean>
        //    <s:Boolean x:Key="False">False</s:Boolean>
        //</Application.Resources>

        // <KeyBinding...CommandParameter="{StaticResource True}"/>



        private Command yesButton;
        public Command YesButton // Объединить с noButton через передачу булевой переменной
        {
            get
            {
                return yesButton ?? (yesButton = new Command(obj =>
                {
                    bool answerbool = false;
                    if (CheckForRightTranslation(Word1, Word2.English))
                    {
                        MessageBox.Show("Правильно!");
                        answerbool = true;
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    Score = ScoreRecalculate(Score, Word1, answerbool);
                    Word2 = GoToNextWord(Word2, DictionaryForGame2); // Объединить в метод
                    Word1 = GoToNextWord(Word1, dictionaryForGame1); // И вынести в общую гейм вью модель ( нет не надо)
                }
                ));
            }
        }
        private Command noButton;
        public Command NoButton // Человек отвечает нет - если перевод неправильный то +, иначе- 
        {
            get
            {
                return noButton ?? (noButton = new Command(obj =>
                {
                    bool answerbool = false;
                    if (CheckForRightTranslation(Word1, Word2.English))
                    {
                        MessageBox.Show("Неправильно!");
                    }
                    else
                    {
                        MessageBox.Show("Правильно!");
                        answerbool = true;
                    }
                    Score = ScoreRecalculate(Score, Word1, answerbool);
                    Word1 = GoToNextWord(Word1, dictionaryForGame1);
                    Word2 = GoToNextWord(Word2, DictionaryForGame2);
                }
                ));
            }
        }

        public Word Word1
        {
            get
            {
                return word1;
            }
            set
            {
                word1 = value;
                OnPropertyChanged("Word1");
            }
        }
        public Word Word2
        {
            get
            {
                return word2;
            }
            set
            {
                word2 = value;
                OnPropertyChanged("Word2");
            }
        }

        public Game2ViewModel()
        {
            DictionaryForGame1 = DictionaryRandomize(WordsCollection);
            DictionaryForGame2 = DictionaryRandomize(DictionaryForGame1); //DictionaryRandomize();
            Time2play = 60; // 60 seconds for a game
            Score = 0; // 0 = starts player score
            Word1 = DictionaryForGame1[0];
            Word2 = DictionaryForGame2[0];
            StartTimer();
        }
    }
}
