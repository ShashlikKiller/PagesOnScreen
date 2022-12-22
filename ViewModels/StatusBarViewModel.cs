namespace PagesOnScreen.ViewModels
{
    class StatusBarViewModel : ViewModel
    {
        private string statusTime;
        public string StatusTime
        {
            get
            {
                return statusTime;
            }
            set
            {
                statusTime = value;
                OnPropertyChanged("StatusTime");
            }
        }
        //AppViewModel arm = new AppViewModel();
        //private string title;
        //public string Title
        //{
        //    get
        //    {
        //        return title;
        //    }
        //    set
        //    {
        //        title = arm.CurrentPage.Title;
        //        OnPropertyChanged("Title");
        //    }
        //}
    }
}