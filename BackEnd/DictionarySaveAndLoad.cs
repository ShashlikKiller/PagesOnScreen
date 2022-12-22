using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace PagesOnScreen.BackEnd
{
    public class DictionarySaveAndLoad : INotifyPropertyChanged
    {
        #region Сохранение листа в файл (полностью)
        /// <summary>
        /// Полное сохранение листа в файл (перезапись, если файл не пуст!)
        /// </summary>
        /// <typeparam name="T"> Класс объекта </typeparam>
        /// <param name="FileName"> Название файла, в который будет сохранятся объект </param>
        /// <param name="SerializableObjects"> Название объекта, который сохранится в файл </param>
        public static void SaveCollectionToFile<T>(String FileName, ObservableCollection<T> SerializableObjects) // => json
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(FileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, SerializableObjects);
            }
        }
        #endregion

        #region Загрузка листа из файла (полностью)
        /// <summary>
        /// Загрузка листа из файла (полностью)
        /// </summary>
        /// <typeparam name="T"> Класс, из которого состоит ObservableCollection </typeparam>
        /// <param name="FileName"> Название файла, из которого будет происходить загрузка </param>
        /// <returns> </returns>
        public static ObservableCollection<T> LoadCollectionFromFile<T>(string FileName)
        {
            if (File.Exists(FileName))
            {
                using (StreamReader file = new StreamReader(FileName))
                {
                    string json = file.ReadToEnd();
                    return JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                }
            }
            throw new FileNotFoundException("файла нету!!!!");
        }
        #endregion

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
