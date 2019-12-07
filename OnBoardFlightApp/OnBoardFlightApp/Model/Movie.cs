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
    public class Movie : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged("Title"); }
        }

        private string runtime;

        public string Runtime
        {
            get { return runtime; }
            set { runtime = value; RaisePropertyChanged("Runtime"); }
        }

        private string released;

        public string Released
        {
            get { return released; }
            set { released = value; RaisePropertyChanged("Released"); }
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; RaisePropertyChanged("Genre"); }
        }

        private string language;

        public string Language
        {
            get { return language; }
            set { language = value; RaisePropertyChanged("Language"); }
        }

        private string director;

        public string Director
        {
            get { return director; }
            set { director = value; RaisePropertyChanged("Director"); }
        }

        private string writer;

        public string Writer
        {
            get { return writer; }
            set { writer = value; RaisePropertyChanged("Writer"); }
        }

        private string actors;

        public string Actors
        {
            get { return actors; }
            set { actors = value; RaisePropertyChanged("Actors"); }
        }

        private string poster;

        public string Poster
        {
            get { return poster; }
            set { poster = value; RaisePropertyChanged("Poster"); }
        }

        private string sourceMP4;

        public string SourceMP4
        {
            get { return sourceMP4; }
            set { sourceMP4 = value;
                MediaPlayer mediaPlayer = new MediaPlayer();
                mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(sourceMP4));
                this.SourceMP4Media = new Uri(SourceMP4);
                RaisePropertyChanged("SourceMP4");
                RaisePropertyChanged("SourceMP4Media");
            }
        }

        private Uri source;

        public Uri SourceMP4Media
        {
            get { return source; }
            set { source = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
