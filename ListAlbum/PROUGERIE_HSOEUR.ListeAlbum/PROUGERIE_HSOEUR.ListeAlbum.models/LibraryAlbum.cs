using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    public class LibraryAlbum : IEnumerable<Album>
    {
        public List<Album> ListAlbum { get; set; }

        public LibraryAlbum()
        {
            ListAlbum = new List<Album>();
        }
        
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

        public bool ModifyTitle(Album album,string title)
        {
            if (title == "")
            {
                return false;
            }
            album.Title = title;
            return true;
        }
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
        public bool ModifyArtist(Album album, string artist)
        {
            if (artist == "")
            {
                return false;
            }
            album.Artist = artist;
            return true;
        }

        public bool ModifyGenre(Album album, string genre)
        {
            if (genre == "")
            {
                return false;
            }
            album.Genre = genre;
            return true;
        }
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

        public IEnumerator<Album> GetEnumerator()
        {
            for (int i = 0; i < ListAlbum.Count; i++)
            {
                yield return ListAlbum[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        

        
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

        public override bool Equals(object obj)
        {
            var album = obj as LibraryAlbum;
            return album != null &&
                   EqualityComparer<List<Album>>.Default.Equals(ListAlbum, album.ListAlbum);
        }

        public override int GetHashCode()
        {
            return -1727654344 + EqualityComparer<List<Album>>.Default.GetHashCode(ListAlbum);
        }
    }
}
