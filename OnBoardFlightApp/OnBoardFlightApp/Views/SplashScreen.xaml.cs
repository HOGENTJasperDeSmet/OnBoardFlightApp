using OnBoardFlightApp.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Media.MediaProperties;
using ZXing;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using OnBoardFlightApp.Model;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashScreen : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        DispatcherTimer TimerQr = new DispatcherTimer();

        SplashScreenViewModel splashScreenViewModel = new SplashScreenViewModel();
        MediaCapture mediaCapture;
        bool isPreviewing;

        public SplashScreen()
        {
            DataContext = this;
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            TimerQr.Tick += captureQr;
            TimerQr.Interval = new TimeSpan(0, 0, 3);
            TimerQr.Start();
            this.InitializeComponent();
     
            this.DataContext = splashScreenViewModel;
        }
        private async void captureQr(object sender, object e)
        {
            mediaCapture = new MediaCapture();
            await mediaCapture.InitializeAsync();
            mediaCapture.Failed += MediaCapture_Failed;
            // Prepare and capture photo
            var lowLagCapture = await mediaCapture.PrepareLowLagPhotoCaptureAsync(ImageEncodingProperties.CreateUncompressed(MediaPixelFormat.Bgra8));

            var capturedPhoto = await lowLagCapture.CaptureAsync();
            var softwareBitmap = capturedPhoto.Frame.SoftwareBitmap;

            BarcodeReader r = new BarcodeReader();
            Result res = r.Decode(softwareBitmap);
            if (res != null)
            {
                Passagier passagier = ((App)Application.Current).Zetel.Passagier;
                if (passagier.getCode() == res.Text)
                {
                    Frame.Navigate(typeof(MainPage), null, new DrillInNavigationTransitionInfo());

                }
                else
                {
                    
                }
            }
            //softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
            //var source = new SoftwareBitmapSource();
            //await source.SetBitmapAsync(softwareBitmap);
            //test.Source = source;

            await lowLagCapture.FinishAsync();
        }

        private void MediaCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            Console.Write("gail");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            splashScreenViewModel.getSplashArt();
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            TimerQr.Stop();
            base.OnNavigatedFrom(e);
        }




        private void Timer_Tick(object sender, object e)
        {
            Clock.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        private void Page_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            
        }
    }
}
