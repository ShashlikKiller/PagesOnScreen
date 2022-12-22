using System.Windows;
using System.Windows.Controls;

namespace PagesOnScreen.View
{
    public partial class ListSettingsPage : Page
    {
        //ObservableCollection<TextBox> TextBoxes = new ObservableCollection<TextBox>();
        //public void ClearTextBoxes(ObservableCollection<TextBox> listname)
        //{
        //    foreach (TextBox item in listname)
        //    {
        //item.Text = "";
        //Thread.Sleep(200);
        //item.Clear();// - Не работает(?)
        //    }
        //}
        public ListSettingsPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.ListSettingsViewModel();
            //TextBoxes.Add(TextBoxEnglish);
            //TextBoxes.Add(TextBoxRussian);
        }
        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            //ClearTextBoxes(TextBoxes);
        }
    }
}
