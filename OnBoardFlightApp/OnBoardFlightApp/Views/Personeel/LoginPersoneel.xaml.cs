﻿using OnBoardFlightApp.Views.Personeel;
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

namespace OnBoardFlightApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPersoneel : Page
    {
        public LoginPersoneel()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = UsernameTextBox.Text;
            var wachtwoord = PasswordTextBox.Password;
            var token = await ViewModel.Login(email, wachtwoord);

            if(token != null && token != "")
            {
                var frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(MainPagePersoneel), token);
            }
            else
            {
                await new MessageDialog("Foute login!").ShowAsync();
            }
        }
    }
}
