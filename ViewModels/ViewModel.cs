using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WordClassLibrary;
using static PagesOnScreen.BackEnd.DictionarySaveAndLoad;

namespace PagesOnScreen.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Word> wordsCollection;
        public ObservableCollection<Word> WordsCollection
        {
            get
            {
                return wordsCollection;
            }
            set
            {
                wordsCollection = value;
                OnPropertyChanged("WordsCollection");
            }
        }
        public ViewModel()
        {
            WordsCollection = LoadCollectionFromFile<Word>("wordslist.json");
        }

        #region Notify about prop changes
        public event PropertyChangedEventHandler PropertyChanged; // notify
        public void OnPropertyChanged([CallerMemberName] string prop = "") // notify bout prop changes
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
