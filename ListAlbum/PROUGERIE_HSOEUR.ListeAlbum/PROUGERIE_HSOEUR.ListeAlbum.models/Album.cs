using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    [DataContract(Name = "album")]
    public class Album : IEnumerable<Track>, INotifyPropertyChanged
    {
        
        private string title;
        public string artist;
        public string genre;
        public int year;
        private string coverAlbum;
        private Time timeA;
        private  ObservableCollection<Track> listTrack;
        [DataMember]
        public string KeyAlbum { get; set; }

        [DataMember]
        public string Title{get { return title; } set{
                title = value;
                
                OnPropertyChanged("Title");
            }
        }
        [DataMember]
        public Time TimeA
        {
            get { return timeA; }
            set
            {
                timeA = value;
                
                OnPropertyChanged("TimeA");
            }
        }
        [DataMember]
        public string Artist
        {
            get { return artist; }
            set
            {
                artist = value;
                
                OnPropertyChanged("Artist");
            }
        }
        [DataMember]
        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                
                OnPropertyChanged("Genre");
            }
        }
        [DataMember]
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                
                OnPropertyChanged("Year");
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Track> ListTrack
        {
            get { return listTrack; }
            set
            {
                listTrack = value;
                
                OnPropertyChanged("ListTrack");
            }
        }
        [DataMember]
        public string CoverAlbum
        {
            get
            {
                return coverAlbum;
            }
            set
            {
                coverAlbum = value;
                OnPropertyChanged("CoverAlbum");
                
            }
        }
        
        /// <param name="keyAlbum"></param>
        /// <param name="title"></param>
        /// <param name="artist"></param>
        /// <param name="genre"></param>
        /// <param name="year"></param>
        public Album(string keyAlbum,string title, string artist, string genre, int year):this(keyAlbum,title,artist,genre,year,"unknown")
        {
            
        }
        
        public Album(string keyAlbum, string title, string artist, string genre, int year,string image)
        {
            KeyAlbum = keyAlbum;
            Title = title;
            TimeA = new Time(0,0);
            Artist = artist;
            Genre = genre;
            Year = year;
            ListTrack = new ObservableCollection<Track>();
            CoverAlbum = image;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged([CallerMemberName]string name="")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Track> GetEnumerator()
        {
            for (int i = 0; i < ListTrack.Count; i++)
            {
                yield return ListTrack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




        /// <summary>
        ///  Delete a track in an album.
        /// </summary>
        /// <param name="track"></param>
        public void EraseTrack(string track)
        {
            foreach (var thetrack in ListTrack)
            {

                if (thetrack.Title.Equals(track))
                {
                    ListTrack.Remove(thetrack);
                    return;
                }
            }
        }

        /// <summary>
        /// Add a track in an album.
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        public bool AddTrack(Track track)
        {
              foreach (var thetrack in ListTrack)
              {
                    if ((thetrack.Title.Equals(track.Title) && thetrack.Album.Equals(track.Album)))
                     {
                        
                        return false;
                     }
              }
              ListTrack.Add(track);
              return true;
        }
        /// <summary>
        /// Calculate the time of a list of track.
        /// </summary>
        public void TimeCalculator()
        {
            int timeMin = 0;
            int timeSec = 0;
            

            foreach (var track in ListTrack)
            {
                timeSec += track.TimeT.Sec;
                timeMin += track.TimeT.Min;

                if (timeSec >= 60)
                {
                    timeSec = timeSec % 60;
                    timeMin++;

                }
            }
            TimeA = new Time(timeMin, timeSec);
            
            
        }

        /// <summary>
        /// Checks if an album is the same as an other one.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public override bool Equals(object obj)
        //{
        //    var album = obj as Album;
        //    return album != null &&
        //           KeyAlbum == album.KeyAlbum &&
        //           Title == album.Title &&
        //           EqualityComparer<Time>.Default.Equals(TimeA, album.TimeA) &&
        //           Artist == album.Artist &&
        //           Genre == album.Genre &&
        //           Year == album.Year &&
        //           EqualityComparer<ObservableCollection<Track>>.Default.Equals(ListTrack, album.ListTrack);
        //}



        /// <summary>
        /// returns an hashcode.
        /// </summary>
        /// <returns></returns>

        //public override int GetHashCode()
        //{
        //    var hashCode = -1714544371;
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(KeyAlbum);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<Time>.Default.GetHashCode(TimeA);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Artist);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genre);
        //    hashCode = hashCode * -1521134295 + Year.GetHashCode();
        //    hashCode = hashCode * -1521134295 + EqualityComparer<ObservableCollection<Track>>.Default.GetHashCode(ListTrack);
        //    return hashCode;
        //}
    }
}
