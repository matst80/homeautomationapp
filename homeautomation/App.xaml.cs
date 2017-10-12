using Xamarin.Forms;

namespace homeautomation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Views.MyMasterView();
            MainPage = new StyledNavigationPage(new Views.NodeListView());
            //MainPage = new StyledNavigationPage(new AutomationStart());

        }

        public static void ShowConnectionErrorMessage(string title, System.Exception ex) {
            Device.BeginInvokeOnMainThread(()=>{
                App.Current.MainPage.DisplayAlert("Connection error",title+"\n\r"+ex.Message,"Ok");
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
