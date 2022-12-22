using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using WordClassLibrary;

namespace PagesOnScreen.ViewModels
{
    class GameViewModel : ViewModel
    {
        private int score;
        private int time2play;
        DispatcherTimer timer;//Объявим поле для таймера
        private protected void StartTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1) // HH:mm:ss
            };
            timer.Tick += new EventHandler(Tick);
            timer.Start();
        }
        private void Tick(object sender, EventArgs e)
        {
            Time2play--;
            //Здесь пишем что должен делать таймер
        }


        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }
        public int Time2play
        {
            get
            {
                return time2play;
            }
            set
            {
                time2play = value;
                OnPropertyChanged("Time2play");
            }

        }
        /// <summary>
        /// Изменить количество очков в зависимости от ответа
        /// </summary>
        /// <param name="Score"> Текущее количество очков</param>
        /// <param name="WordToTranslate"> Переведенное слово</param>
        /// <param name="rightornot"> Правильность ответа (да/нет)</param>
        /// <returns></returns>
        public int ScoreRecalculate(int Score, Word WordToTranslate, bool rightornot)
        {
            if (rightornot) return Score += WordToTranslate.English.Length;
            return Score -= WordToTranslate.English.Length;
            //return Score;
        }

        /// <summary>
        /// Перейти к следующему слову в игровом словаре
        /// </summary>
        /// <typeparam name="T"> Название класса объекта</typeparam>
        /// <param name="Word"> Текущее слово</param>
        /// <param name="Dictionary"> Игровой словарь</param>
        /// <returns></returns>
        public T GoToNextWord<T>(T Word, ObservableCollection<T> Dictionary) // Static - ?
        {
            T NextWord;
            int CurrentWordIndex = Dictionary.IndexOf(Word);
            if (CurrentWordIndex == Dictionary.Count - 1)
            {
                MessageBox.Show("Извините, слова закончились! =("); // Вынести ЗА пределы этого цикла
                // ОРГАНИЗОВАТЬ ЦИКЛ, ГДЕ СЛОВАРЬ ДЛЯ ИГРЫ ПРОХОДИТ РАНДОМИЗАЦИЮ ЗАНОВО
                return default(T); // потому что некоторые T != null (не могут принять такое значение)
            }
            NextWord = Dictionary[CurrentWordIndex + 1];
            return NextWord;
        }

        /// <summary>
        /// Перемешивание словаря слов и превращение его в игровой словарь
        /// </summary>
        /// <typeparam name="T"> Название класса объекта, из которого состоит словарь</typeparam>
        /// <param name="OriginalDictionaty"> Название изначального словаря</param>
        /// <returns></returns>
        public ObservableCollection<T> DictionaryRandomize<T>(ObservableCollection<T> OriginalDictionaty) // Static - ?
        {
            //Random random = new Random(DateTime.Now.Millisecond);
            var shuffle = OriginalDictionaty;
            for (int i = 2; i < shuffle.Count; ++i)
            {
                Random random = new Random(DateTime.Now.Millisecond);
                T temp = shuffle[i];
                int nextRandom = random.Next(i - 1);
                shuffle[i] = shuffle[nextRandom];
                shuffle[nextRandom] = temp;
            }
            return shuffle;
        }
    }
}
