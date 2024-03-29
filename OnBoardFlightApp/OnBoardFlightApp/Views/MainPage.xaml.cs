﻿using OnBoardFlightApp.Model;
using OnBoardFlightApp.Views;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Load();
        }
        public void Load()
        {
            contentFrame.Navigate(typeof(Home));
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
        private void MainView_NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(SplashScreen));
        }
        private void nvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {

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

                case "Home":
                    contentFrame.Navigate(typeof(Home));
                    break;

                case "Melding":
                    contentFrame.Navigate(typeof(Meldingen));
                    break;

                case "Movie":
                    contentFrame.Navigate(typeof(Movies));
                    break;

                case "MoviePlay":
                    contentFrame.Navigate(typeof(PlayMovie));
                    break;
                case "Music":
                    contentFrame.Navigate(typeof(Music));
                    break;
                case "Overzicht":
                    contentFrame.Navigate(typeof(MijnBestellingen));
                    break;
                case "Bestelling":
                    contentFrame.Navigate(typeof(PlaatsBestelling));
                    break;
                case "Chat":
                    contentFrame.Navigate(typeof(Groepschat));
                    break;
                case "Teken":
                    contentFrame.Navigate(typeof(Teken));
                    break;

            }
        }
    }
}