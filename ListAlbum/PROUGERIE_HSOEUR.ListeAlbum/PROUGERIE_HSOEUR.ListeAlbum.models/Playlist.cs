﻿using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryALbumClass
{
    public class Playlist : IEnumerable
    {
       
        public List<Track> ListTrack { get; private set; }
        public Playlist()
        {
            ListTrack = new List<Track>();
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
        /// 
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        public void ListByArtist()
        {
            var l = from track in ListTrack
                    orderby track.Artist, track.Year
                    select track;
            ListTrack = new List<Track>();
            foreach (var track in l)
            {
                AddTrackSort(track);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void ListByGenre()
        {
            var l = from track in ListTrack
                    orderby track.Title, track.Artist, track.Year
                    select track;
            ListTrack = new List<Track>();
            foreach (var track in l)
            {
                AddTrackSort(track);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ListByYear()
        {
            var l = from track in ListTrack
                    orderby track.Year, track.Title
                    select track;
            ListTrack = new List<Track>();
            foreach (var track in l)
            {
                AddTrackSort(track);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var playlist = obj as Playlist;
            return playlist != null &&
                   EqualityComparer<List<Track>>.Default.Equals(ListTrack, playlist.ListTrack);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1794596168 + EqualityComparer<List<Track>>.Default.GetHashCode(ListTrack);
        }
    }
}


