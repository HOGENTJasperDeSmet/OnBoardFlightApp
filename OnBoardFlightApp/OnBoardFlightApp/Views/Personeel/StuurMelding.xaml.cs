using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class StuurMelding : Page
    {
        public StuurMelding()
        {
            this.InitializeComponent();
            VulOp();
        }

        private async void VulOp()
        {
            passagierBox.ItemsSource = await ViewModel.GetPassagiers();
        }

        private async void StuurButton_Click(object sender, RoutedEventArgs e)
        {
            var inhoud = MeldingText.Text;
            if(inhoud != null && inhoud != "" && passagierBox.SelectedIndex != -1)
            {
                await ViewModel.Post(inhoud, passagierBox.SelectedIndex + 1);
                await new MessageDialog("Melding geplaatst voor " + "user").ShowAsync();
            }
            else
            {
                await new MessageDialog("Vul een melding in en selecteer een passagier.").ShowAsync();
            }
        }

        private async void StuurButtonNaarIedereen_Click(object sender, RoutedEventArgs e)
        {
            var inhoud = MeldingText.Text;
            if (inhoud != null && inhoud != "")
            {
                await ViewModel.PostToAll(inhoud);
                await new MessageDialog("Melding geplaatst voor alle passagiers!").ShowAsync();
            }
            else
            {
                await new MessageDialog("Vul een melding in.").ShowAsync();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.SetToken(e.Parameter as string);
        }
    }
}
