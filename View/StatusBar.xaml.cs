using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace PagesOnScreen.View
{
    /// <summary>
    /// Логика взаимодействия для StatusBar.xaml
    /// </summary>
    public partial class StatusBar : Page
    {
        ViewModels.StatusBarViewModel statusVM = new ViewModels.StatusBarViewModel();
        public StatusBar()
        {
            InitializeComponent();
            this.DataContext = statusVM;
            CompositionTarget.Rendering += CompositionTarget_Rendering;

        }

        private void CompositionTarget_Rendering(object sender, EventArgs e) // refresh time
        {
            statusVM.StatusTime = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
