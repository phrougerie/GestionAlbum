using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    
    public class LibraryAlbum : IEnumerable<Album>
    {
        
        /// <summary>
        /// 
        /// </summary>
        public List<Album> ListAlbum { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public LibraryAlbum()
        {
            ListAlbum = new List<Album>();
        }
        public LibraryAlbum(List<Album> liste)
        {
            ListAlbum = liste;
        }
        

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public bool AddAlbum(Album album)
        {
            foreach (var al in ListAlbum)
            {
                if ((al.Title.Equals(album.Title) && al.Artist.Equals(album.Artist))||al.KeyAlbum.Equals(album.KeyAlbum))
                {
                    
                    return false;
                } 
            }
            ListAlbum.Add(album);
            return true;
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="trackT"></param>
        /// <returns></returns>
        public bool DeleteTrack(string key,string trackT)
        {
            
            foreach (var al in ListAlbum)
            {
                if (key.Equals(al.KeyAlbum))
                {
                    al.EraseTrack(trackT);
                    al.TimeCalculator();
                    return true;
                }
                 
            }
            return false;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="trackT"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        public bool AddTrackAl(string key,string trackT,int min,int sec,string genre)
        {
            foreach (var al in ListAlbum)
            {
                if (key.Equals(al.KeyAlbum))
                {
                    al.AddTrack(new Track(trackT, min,sec, al.Artist, al.Title,genre,al.Year));
                    return true;
                }
            }
            return false;
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteAlbum(string key)
        {
            foreach (var al in ListAlbum)
            {
                if (al.KeyAlbum.Equals(key))
                {
                    ListAlbum.Remove(al);
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool ModifyTitle(Album album,string title)
        {
            if (title == "")
            {
                return false;
            }
            album.Title = title;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public bool ModifyTime(string key, int min,int sec)
        {
            foreach (var al in ListAlbum)
            {
                if (al.KeyAlbum.Equals(key))
                {
                    al.TimeA.Min = min;
                    al.TimeA.Sec = sec;
                    return true;
                }

            }
            
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="artist"></param>
        /// <returns></returns>
        public bool ModifyArtist(Album album, string artist)
        {
            if (artist == "")
            {
                return false;
            }
            album.Artist = artist;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="album"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        public bool ModifyGenre(Album album, string genre)
        {
            if (genre == "")
            {
                return false;
            }
            album.Genre = genre;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool ModifyYear(string key, int year)
        {
            foreach (var al in ListAlbum)
            {
                if (al.KeyAlbum.Equals(key))
                {
                    
                    al.Year = year;
                    return true;
                }
                al.Year = year;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="modify"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        public bool ModifyAlbum(string key, string modify,int valid)
        {
            bool verify = false;
            foreach (var al in ListAlbum)
            {
                if (al.KeyAlbum.Equals(key))
                {
                    switch (valid)
                    {
                        case 1:
                            verify = ModifyTitle(al, modify);
                            break;
                        case 3:
                            verify = ModifyArtist(al, modify);
                            break;
                        case 4:
                            verify = ModifyGenre(al, modify);
                            break;
                    }
                    return verify;
                }

            }
            return verify;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Album> GetEnumerator()
        {
            for (int i = 0; i < ListAlbum.Count; i++)
            {
                yield return ListAlbum[i];
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
        public void listByKey()
        {
            var l = from album in ListAlbum
                    orderby album.KeyAlbum,album.Artist
                    select album;
            ListAlbum = new List<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void listByArtist()
        {
            var l = from album in ListAlbum
                    orderby album.Artist,album.Year
                    select album;
            ListAlbum = new List<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void listByAlbum()
        {
            var l = from album in ListAlbum
                    orderby album.Title, album.Year
                    select album;
            ListAlbum = new List<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void listByGenre()
        {
            var l = from album in ListAlbum
                    orderby album.Title, album.Artist,album.Year
                    select album;
            ListAlbum = new List<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void listByYear()
        {
            var l = from album in ListAlbum
                    orderby album.Year,album.Title
                    select album;
            ListAlbum = new List<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var album = obj as LibraryAlbum;
            return album != null &&
                   EqualityComparer<List<Album>>.Default.Equals(ListAlbum, album.ListAlbum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1727654344 + EqualityComparer<List<Album>>.Default.GetHashCode(ListAlbum);
        }
    }
}
