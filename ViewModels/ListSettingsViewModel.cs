using PagesOnScreen.BackEnd;
using System.Windows;
using WordClassLibrary;
using static PagesOnScreen.BackEnd.BuilderPattern;
using static PagesOnScreen.BackEnd.DictionarySaveAndLoad;

namespace PagesOnScreen.ViewModels
{
    public class ListSettingsViewModel : ViewModel
    {
        private Word selectedWord;
        private string englishWord;
        private string russianWord;
        public string FileName = "wordslist.json";

        public ListSettingsViewModel()
        {
            
        }

        public Word SelectedWord
        {
            get
            {
                return this.selectedWord;
            }
            set
            {
                this.selectedWord = value;
                OnPropertyChanged("SelectedWord");
            }
        }

        public string EnglishWord
        {
            get
            {
                return englishWord;
            }
            set
            {
                englishWord = value;
                OnPropertyChanged("EnglishWord");
            }
        }
        public string RussianWord
        {
            get
            {
                return russianWord;
            }
            set
            {
                russianWord = value;
                OnPropertyChanged("RussianWord");
            }
        }

        private Command addWord;
        public Command AddWord
        {
            get
            {
                return addWord ?? (addWord = new Command(obj =>
                {
                    ConcreteBuilder builder = new ConcreteBuilder();
                    Director director = new Director(builder);
                    Word variableWord = new Word();
                    director.AddWord(EnglishWord, RussianWord, variableWord);
                    WordsCollection.Add(variableWord);
                    EnglishWord = ""; // обнуление текстбоксов
                    RussianWord = "";
                    MessageBox.Show("Слово было добавлено в словарь.");
                }));
            }
        }
        private Command saveList;
        public Command SaveList
        {
            get
            {
                return saveList ?? (saveList = new Command(obj =>
                {
                    SaveCollectionToFile(FileName, WordsCollection);
                    MessageBox.Show("Словарь слов обновлён.");
                }));
            }
        }
        private Command deleteWord;
        public Command DeleteWord
        {
            get
            {
                return deleteWord ?? (deleteWord = new Command(obj =>
                {
                    if (SelectedWord != null)
                    {
                        WordsCollection.RemoveAt(WordsCollection.IndexOf(SelectedWord));
                    }
                    else MessageBox.Show("Нет выбранного слова для удаления."); // Отключить здесь кнопку удаления
                                                                                //SaveCollectionToFile(FileName, WordsCollection);
                                                                                //MessageBox.Show("Словарь слов обновлён.");
                }));
            }
        }
    }
}
