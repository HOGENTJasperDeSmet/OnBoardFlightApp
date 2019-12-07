using OnBoardFlightApp.Model;
using System;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayMusic : Page
    {
        private MP3 song { get; set; }
        public PlayMusic()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            song = (MP3)e.Parameter;
            // Zo zou het zijn als we voor elke mp3 file een link hadden naar een online mp3 bestand nu gebruiken we 1 dummy mp3 bestand
            //mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(song.SourceMP3));
            await Show_mp3();
        }

        private async Task Show_mp3()
        {
            Uri uri = new Uri("https://file-examples.com/wp-content/uploads/2017/11/file_example_MP3_700KB.mp3");
           

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("user", "myName");
            // load HTTP Stream 

            HttpRandomAccessStream stream = await HttpRandomAccessStream.CreateAsync(client, uri);

            mediaPlayer.AutoPlay = true;

            mediaPlayer.Source = MediaSource.CreateFromStream(stream, stream.ContentType);

        }
    }
}
