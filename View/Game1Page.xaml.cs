using System.Windows.Controls;

namespace PagesOnScreen.View
{
    /// <summary>
    /// Логика взаимодействия для Game1Page.xaml
    /// </summary>
    public partial class Game1Page : Page
    {
        public Game1Page()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Game1ViewModel();
        }
    }
}
