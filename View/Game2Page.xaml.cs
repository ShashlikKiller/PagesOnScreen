using System.Windows.Controls;

namespace PagesOnScreen.View
{
    /// <summary>
    /// Логика взаимодействия для Game2Page.xaml
    /// </summary>
    public partial class Game2Page : Page
    {
        public Game2Page()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Game2ViewModel();
        }
    }
}
