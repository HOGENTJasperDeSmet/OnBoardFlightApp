using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlightApp.Views.Personeel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VeranderZetel : Page
    {
        public VeranderZetel()
        {
            this.InitializeComponent();
            GetZetels();

        }

        private async void GetZetels()
        {
            var zetels = await ViewModel.GetZetels();
            zetelBox1.ItemsSource = zetels;
            zetelBox2.ItemsSource = zetels;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(zetelBox1.SelectedIndex != -1 && zetelBox2.SelectedIndex != -1)
            {
                var id1 = zetelBox1.SelectedIndex + 1;
                var id2 = zetelBox2.SelectedIndex + 1;
                ViewModel.VeranderZetel(id1, id2);
                Refresh();
            }
            else
            {
                await new MessageDialog("Gelieve 2 personen te selecteren.").ShowAsync();
            }
        }

        private async void Refresh()
        {
            await Task.Delay(1000);
            Frame.Navigate(typeof(VeranderZetel));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.SetToken(e.Parameter as string);
        }
    }
}
