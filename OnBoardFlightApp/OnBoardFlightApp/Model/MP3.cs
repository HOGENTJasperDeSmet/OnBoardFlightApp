using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace OnBoardFlightApp.Model
{
    public class MP3 : INotifyPropertyChanged
    {
        #region Properties
        private string naam;
        public string name
        {
            get
            {
                return naam;
            }
            set
            {
                naam = value;
                RaisePropertyChanged("name");
            }
        }
        private String afbeelding;
        public String img
        {
            get
            {
                return afbeelding;
            }
            set
            {
                afbeelding = value;
                RaisePropertyChanged("img");
            }
        }
        private string sourceMP3;
        public string SourceMP3
        {
            get { return sourceMP3; }
            set
            {
                sourceMP3 = value;
                MediaPlayer mediaPlayer = new MediaPlayer();
                mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(sourceMP3));
                this.SourceMP3Media = new Uri(SourceMP3);
                RaisePropertyChanged("SourceMP3");
                RaisePropertyChanged("SourceMP3Media");
            }
        }

        private Uri source;

        public Uri SourceMP3Media
        {
            get { return source; }
            set { source = value; }
        }
        #endregion


        #region Constructors
        public MP3(string naam, string img)
        {
            name = naam;
            img = afbeelding;
        }
        public MP3()
        {
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

