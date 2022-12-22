using WordClassLibrary;
using static WordClassLibrary.Word;

namespace PagesOnScreen.BackEnd
{
    class BuilderPattern
    {
        public abstract class WordBuild
        {
            public abstract void AddEnglish(string english, Word CurrentWord); // Добавить английский перевод слова
            public abstract void AddRussian(string russian, Word CurrentWord); // Добавить русский перевод слова
            public abstract void RightOrNot(bool rightornot, LastWord CurrentLastWord); // Добавить правильность ответа юзера
            public abstract Word GetResult(Word CurrentWord); // Собрать слово с переводом воедино
            public abstract LastWord GetResult(LastWord CurrentLastWord); // Собрать слово с правильностью ответа пользователя
        }

        public class Director
        {
            WordBuild currentWordBuilder;
            public Director(WordBuild builder)
            {
                this.currentWordBuilder = builder;
            }
            public void AddWord(string english, string russian, Word CurrentWord)
            {
                currentWordBuilder.AddEnglish(english, CurrentWord);
                currentWordBuilder.AddRussian(russian, CurrentWord);
                currentWordBuilder.GetResult(CurrentWord);

            }
            public void MakeWordLast(bool rightornot, LastWord CurrentLastWord)
            {
                currentWordBuilder.RightOrNot(rightornot, CurrentLastWord);
                currentWordBuilder.GetResult(CurrentLastWord); // LastWord
            }
        }
        public class ConcreteBuilder : WordBuild
        {
            public override void AddEnglish(string english, Word CurrentWord) // Добавление категории
            {
                CurrentWord.English = english;
            }
            public override void AddRussian(string russian, Word CurrentWord) // Добавление категории
            {
                CurrentWord.Russian = russian;
            }
            public override void RightOrNot(bool rightornot, LastWord CurrentLastWord) // Добавление категории
            {
                CurrentLastWord.Rightornot = rightornot;
            }

            public override Word GetResult(Word CurrentWord)
            {
                return CurrentWord;
            }
            public override LastWord GetResult(LastWord CurrentLastWord)
            {
                return CurrentLastWord;
            }
        }
    }
}
