using System.Windows;
using System.Windows.Input;

namespace PagesOnScreen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.AppViewModel();
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Выключение экрана типа
        {
            UIStackPanel.Visibility = Visibility.Hidden;
            StatusBar.Visibility = Visibility.Hidden;
        }

        private void Window_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }
    }
}
