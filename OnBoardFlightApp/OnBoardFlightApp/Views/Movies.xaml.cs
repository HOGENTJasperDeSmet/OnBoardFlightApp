﻿using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Movies : Page
    {
        public Movies()
        {
            this.InitializeComponent();
        }

        private void LvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void Movie_Click(object sender, ItemClickEventArgs e)
        {
            var lstview = sender as ListView;
            Movie movie = (Movie)e.ClickedItem;
            Frame.Navigate(typeof(PlayMovie), movie);
        }
    }
}
