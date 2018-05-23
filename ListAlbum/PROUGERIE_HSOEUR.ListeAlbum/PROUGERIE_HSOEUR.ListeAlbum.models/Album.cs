using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    [DataContract(Name = "album")]
    public class Album : IEnumerable<Track>
    {
        [DataMember]
        public string KeyAlbum { get; internal set; }
        [DataMember]
        public string Title{get; internal set;}
        [DataMember]
        public Time TimeA{ get; internal set; }
        [DataMember]
        public string Artist { get; internal set; }
        [DataMember]
        public string Genre { get; internal set; }
        [DataMember]
        public int Year { get; internal set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Track> ListTrack { get; private set; }

        public Album(string keyAlbum,string title, string artist, string genre, int year)
        {
            KeyAlbum = keyAlbum;
            Title = title;
            TimeA = new Time(0,0);
            Artist = artist;
            Genre = genre;
            Year = year;
            ListTrack = new List<Track>();
        }
        

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

        public override bool Equals(object obj)
        {
            var album = obj as Album;
            return album != null &&
                   KeyAlbum == album.KeyAlbum &&
                   Title == album.Title &&
                   EqualityComparer<Time>.Default.Equals(TimeA, album.TimeA) &&
                   Artist == album.Artist &&
                   Genre == album.Genre &&
                   Year == album.Year &&
                   EqualityComparer<List<Track>>.Default.Equals(ListTrack, album.ListTrack);
        }

        public override int GetHashCode()
        {
            var hashCode = -1714544371;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(KeyAlbum);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<Time>.Default.GetHashCode(TimeA);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Artist);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genre);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Track>>.Default.GetHashCode(ListTrack);
            return hashCode;
        }
    }
}
