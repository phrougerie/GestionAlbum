using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    public class Track
    {
        [JsonProperty(PropertyName = "Title")]
        
        public string Title { get; internal set; }
        [JsonProperty(PropertyName = "TimeT")]
        public Time TimeT { get; internal set; }
        [JsonProperty(PropertyName = "Artist")]
        public string Artist { get; internal set; }
        [JsonProperty(PropertyName = "Album")]
        public string Album { get; internal set; }
        [JsonProperty(PropertyName = "Genre")]
        public string Genre { get; internal set; }
        [JsonProperty(PropertyName = "Year")]
        public int Year { get; internal set; }


        public Track(string title, int min,int sec, string artist, string album, string genre, int year)
        {
            
            Title = title;
            TimeT = new Time(min, sec);
            Artist = artist;
            Album = album;
            Genre = genre;
            Year = year;
        }

        public override bool Equals(object obj)
        {
            var track = obj as Track;
            return track != null &&
                   Title == track.Title &&
                   EqualityComparer<Time>.Default.Equals(TimeT, track.TimeT) &&
                   Artist == track.Artist &&
                   Album == track.Album &&
                   Genre == track.Genre &&
                   Year == track.Year;
        }

        public override int GetHashCode()
        {
            var hashCode = 2029241367;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<Time>.Default.GetHashCode(TimeT);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Artist);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Album);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genre);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
