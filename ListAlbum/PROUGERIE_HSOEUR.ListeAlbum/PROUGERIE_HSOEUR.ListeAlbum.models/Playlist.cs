using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryALbumClass
{
    public class Playlist : IEnumerable
    {
       
        public ObservableCollection<Track> ListTrack { get; private set; }
        public Playlist()
        {
            ListTrack = new ObservableCollection<Track>();
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
                //Le yield permet de simplifier considérable le Ienum
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        

        /// <summary>
        /// Add a track to a playlist.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="titleT"></param>
        /// <param name="library"></param>
        /// <returns></returns>
        public bool AddTrack(string key, string titleT, LibraryAlbum library)
        {
            foreach (var track in ListTrack)
            {
                if (titleT.Equals(track.Title))
                {
                    return false;
                }
            }

            foreach (var album in library)
            {
                if (album.KeyAlbum.Equals(key))
                {
                    foreach (var thetrack in album)
                    {
                        if (thetrack.Title.Equals(titleT))
                        {
                            ListTrack.Add(thetrack);
                            return true;
                        }
                    }
                    return false;

                }
                
            }
            return false;
            
        }

        /// <summary>
        /// Add a track if it's not already in the playlist.
        /// </summary>
        /// <param name="track"></param>
        private void AddTrackSort(Track track)
        {
            foreach (var t in ListTrack)
            {
                if (track.Title.Equals(t.Title))
                {
                    return;
                }

                ListTrack.Add(track);
            }
        }
        
        /// <summary>
        /// Calculate the time of a playlist.
        /// </summary>
        /// <param name="timeHour"></param>
        /// <returns></returns>
        public Time TimeCalculator(ref int timeHour)
        {
            int timeMin = 0;
            int timeSec = 0;
            timeHour = 0;

            foreach (var track in ListTrack)
            {
                timeSec += track.TimeT.Sec;
                timeMin += track.TimeT.Min;

                if (timeSec >= 60)
                {
                    timeSec = timeSec % 60;
                    timeMin++;

                    if (timeMin >= 60)
                    {
                        timeMin = timeMin % 60;
                        timeHour++;
                    }
                }
            }

            return new Time(timeMin, timeSec);
        }

        
        /// <summary>
        /// Sort the playlist by its artist.
        /// </summary>
        public void ListByArtist()
        {
            var l = from track in ListTrack
                    orderby track.Artist, track.Year
                    select track;
            ListTrack = new ObservableCollection<Track>();
            foreach (var track in l)
            {
                AddTrackSort(track);
            }
        }

        /// <summary>
        /// Sort the playlist by its genre.
        /// </summary>
        public void ListByGenre()
        {
            var l = from track in ListTrack
                    orderby track.Title, track.Artist, track.Year
                    select track;
            ListTrack = new ObservableCollection<Track>();
            foreach (var track in l)
            {
                AddTrackSort(track);
            }
        }
        /// <summary>
        /// Sort the playlist by its year.
        /// </summary>
        public void ListByYear()
        {
            var l = from track in ListTrack
                    orderby track.Year, track.Title
                    select track;
            ListTrack = new ObservableCollection<Track>();
            foreach (var track in l)
            {
                AddTrackSort(track);
            }
        }

        /// <summary>
        /// Checks if a playlist is the same as an other one.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var playlist = obj as Playlist;
            return playlist != null &&
                   EqualityComparer<ObservableCollection<Track>>.Default.Equals(ListTrack, playlist.ListTrack);
        }

        /// <summary>
        /// Returns an hashcode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1794596168 + EqualityComparer<ObservableCollection<Track>>.Default.GetHashCode(ListTrack);
        }
    }
}


