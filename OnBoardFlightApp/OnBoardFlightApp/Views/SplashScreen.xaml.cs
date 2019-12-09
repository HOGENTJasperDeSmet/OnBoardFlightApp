using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnBoardFlightApp.Model;
using OnBoardFlightApp.Services;
using OnBoardFlightApp.ViewModel;
using System;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashScreen : Page
    {
        SplashScreenViewModel splashScreenViewModel = new SplashScreenViewModel();

        public SplashScreen()
        {
            this.InitializeComponent();
            this.DataContext = splashScreenViewModel;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
        }


        private void Page_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
