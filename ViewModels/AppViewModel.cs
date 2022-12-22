using PagesOnScreen.BackEnd;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PagesOnScreen.ViewModels
{
    class AppViewModel : ViewModel
    {
        private Page currentPage;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private Page currentStatusPage;
        public Page CurrentStatusPage
        {
            get
            {
                return currentStatusPage;
            }
            set
            {
                currentStatusPage = value;
                OnPropertyChanged("CurrentStatusPage");
            }
        }
        private Page welcome; // private => public
        private Page disabledscreen;
        private Page statusbar;
        public Page listsettings;
        public Page game1;
        public Page game2;
        public AppViewModel()
        {
            statusbar = new View.StatusBar();
            welcome = new View.WelcomePage();
            CurrentStatusPage = statusbar;
            CurrentPage = welcome;
            game1 = new View.Game1Page();
            game2 = new View.Game2Page();
            listsettings = new View.ListSettingsPage();
            disabledscreen = new View.DisabledScreen();
            FrameOpacity = 1;
        }

        private RelayCommand openPage;
        public RelayCommand OpenPage // Обобщение метода открытия страниц
        {
            get
            {
                return openPage ?? (openPage = new RelayCommand(obj =>
                {
                    //out Page page;
                    Page selectedpage = obj as Page;
                    SlowOpacity(selectedpage);
                }
                ));
            }
        }

        private Command game1ButtonClick;
        public Command Game1ButtonClick
        {
            get
            {
                return game1ButtonClick ?? (game1ButtonClick = new Command(obj =>
                {
                    SlowOpacity(game1);
                }));
            }
        }
        private Command game2ButtonClick;
        public Command Game2ButtonClick
        {
            get
            {
                return game2ButtonClick ?? (game2ButtonClick = new Command(obj =>
                {
                    SlowOpacity(game2);
                }));
            }
        }
        private Command listButtonClick;
        public Command ListButtonClick
        {
            get
            {
                return listButtonClick ?? (listButtonClick = new Command(obj =>
                {
                    SlowOpacity(listsettings);
                }));
            }
        }

        private Command turnOff;

        public Command TurnOff
        {
            get
            {
                return turnOff ?? (turnOff = new Command(obj =>
                {
                    CurrentPage = null;
                    //SlowOpacity(disabledscreen);
                }));
            }
        }

        private double frameOpacity;
        public double FrameOpacity
        {
            get
            {
                return frameOpacity;
            }
            set
            {
                frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }

        private protected async void SlowOpacity(Page page) // async
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }
    }
}
