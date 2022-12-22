namespace PagesOnScreen.BackEnd
{
    //[Serializable]
    //public class Word : INotifyPropertyChanged
    //{
    //    private string english;
    //    private string russian;

    //    public string English
    //    {
    //        get
    //        {
    //            return english;
    //        }
    //        set
    //        {
    //            english = value;
    //            OnPropertyChanged("English");
    //        }
    //    }
    //    public string Russian
    //    {
    //        get
    //        {
    //            return russian;
    //        }
    //        set
    //        {
    //            russian = value;
    //            OnPropertyChanged("Russian");
    //        }
    //    }

    //    public Word()
    //    {
    //        // заглушка
    //    }

    //    /// <summary>
    //    /// Конструктор слова
    //    /// </summary>
    //    /// <param name="english"> Перевод на английский язык</param>
    //    /// <param name="russian"> Перевод на русский язык</param>
    //    public Word(string english, string russian)
    //    {
    //        this.english = english;
    //        this.russian = russian;
    //    }

    //    public bool CheckForRightTranslation(Word Word1, string useranswer)
    //    {
    //        //bool rightornot = false;
    //        if (Word1.English == useranswer) // If Word1 = Word2 => return true
    //        {
    //            return true;
    //        }
    //        else return false;
    //        //return rightornot;
    //    }

    //    //public int TestMethod(int x, int y)
    //    //{
    //    //    return x + y;
    //    //}

    //    public class LastWord : Word // Класс ПРОШЛЫХ слов для записи в историю игр.
    //    {
    //        private bool rightornot; // Бул, отвечающий за правильность прошедших слов
    //        public LastWord()
    //        {
    //            // заглушка
    //        }
    //        public LastWord(Word Word, bool rightornot)
    //        {
    //            this.english = Word.english;
    //            this.russian = Word.russian;
    //            this.rightornot = rightornot;
    //        }

    //        public bool Rightornot { get => rightornot; set => rightornot = value; }
    //    }
    //    #region Notify about prop changes
    //    public event PropertyChangedEventHandler PropertyChanged; // notify
    //    public void OnPropertyChanged([CallerMemberName] string prop = "") // notify bout prop changes
    //    {
    //        if (PropertyChanged != null)
    //            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    //    }
    //    #endregion
    //}
}
