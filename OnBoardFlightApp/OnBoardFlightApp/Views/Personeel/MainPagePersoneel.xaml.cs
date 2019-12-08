using OnBoardFlightApp.Views;
using OnBoardFlightApp.Views.Personeel;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPagePersoneel : Page
    {
        public string Token { get; set; }

        public MainPagePersoneel()
        {
            //Token = token;
            this.InitializeComponent();
        }
        private void nvSample_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in nvSample.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    nvSample.SelectedItem = item;
                    break;
                }
            }
        }

        private void nvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                contentFrame.Navigate(typeof(LoginPersoneel));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                nvSample_Navigate(item as NavigationViewItem);
            }
        }

        private void nvSample_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "Bestellingen":
                    contentFrame.Navigate(typeof(Bestellingen), Token);
                    break;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Token = e.Parameter as string;
            contentFrame.Navigate(typeof(Bestellingen), Token);
        }
    }
}