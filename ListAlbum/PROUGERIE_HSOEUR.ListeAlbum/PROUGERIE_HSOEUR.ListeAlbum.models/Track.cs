
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    [DataContract(Name = "track")]
    public class Track
    {

        [DataMember]
        public string Title { get; internal set; }
        [DataMember]
        public Time TimeT { get; internal set; }
        [DataMember]
        public string Artist { get; internal set; }
        [DataMember]
        public string Album { get; internal set; }
        [DataMember]
        public string Genre { get; internal set; }
        [DataMember]
        public int Year { get; internal set; }
        [DataMember]
        public int TrackNumber { get; internal set; }
        [DataMember]
        public string Music { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        /// <param name="artist"></param>
        /// <param name="album"></param>
        /// <param name="genre"></param>
        /// <param name="year"></param>
        public Track(string title, int min, int sec, string artist, string album, string genre, int year, int tracknumber):this(title,min,sec,artist,album,genre,year,tracknumber,"unknown")
        {

        }

        public Track(string title, int min, int sec, string artist, string album, string genre, int year,int tracknumber,string music)
        {

            Title = title;
            TimeT = new Time(min, sec);
            Artist = artist;
            Album = album;
            Genre = genre;
            Year = year;
            TrackNumber = tracknumber;
            Music = music;
        }
        

        /// <summary>
        /// Checks if a track is the same as an other one.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns an hashcode.
        /// </summary>
        /// <returns></returns>
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
