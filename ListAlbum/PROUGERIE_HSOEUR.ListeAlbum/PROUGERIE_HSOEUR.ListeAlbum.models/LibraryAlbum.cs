using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    
    public class LibraryAlbum : IEnumerable<Album>,INotifyPropertyChanged
    {
        private ObservableCollection<Album> listAlbum;
        
        public ObservableCollection<Album> ListAlbum
        {
            get { return listAlbum; }
            set
            {
                listAlbum = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("ListAlbum");
            }
        }

       
        public LibraryAlbum()
        {
            ListAlbum = new ObservableCollection<Album>();
        }
        public LibraryAlbum(ObservableCollection<Album> liste)
        {
            ListAlbum = liste;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }



        /// <summary>
        /// Add an album to the Librairy.
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
        ///  Delete an album to the Librairy
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
        /// Add a track to an Album.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="trackT"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        public bool AddTrackAl(string key,string trackT,int min,int sec,string genre,int tracknum)
        {
            foreach (var al in ListAlbum)
            {
                if (key.Equals(al.KeyAlbum))
                {
                    al.AddTrack(new Track(trackT, min,sec, al.Artist, al.Title,genre,al.Year,tracknum));
                    return true;
                }
            }
            return false;
        }
        
        
        /// <summary>
        /// Delte an album.
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
        /// Modifies the title of an album.
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
        /// Modifies the time of an album.
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
        /// Modifies the artist of an album.
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
        /// Modifies the genre of an album.
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
        /// Modifies the year of an album.
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
        /// allows you to choose what change you want to do to an album.
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
        /// Sort the albums by its key.
        /// </summary>
        public void listByKey()
        {
            var l = from album in ListAlbum
                    orderby album.KeyAlbum,album.Artist
                    select album;
            ListAlbum = new ObservableCollection<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }

        /// <summary>
        /// Sort the albums by its artsist.
        /// </summary>
        public void listByArtist()
        {
            var l = from album in ListAlbum
                    orderby album.Artist,album.Year
                    select album;
            ListAlbum = new ObservableCollection<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }
        /// <summary>
        /// Sort the albums by its title.
        /// </summary>
        public void listByAlbum()
        {
            var l = from album in ListAlbum
                    orderby album.Title, album.Year
                    select album;
            ListAlbum = new ObservableCollection<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }
        /// <summary>
        /// Sort the albums by its genre.
        /// </summary>
        public void listByGenre()
        {
            var l = from album in ListAlbum
                    orderby album.Title, album.Artist,album.Year
                    select album;
            ListAlbum = new ObservableCollection<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }
        /// <summary>
        /// Sort the albums by its year.
        /// </summary>
        public void listByYear()
        {
            var l = from album in ListAlbum
                    orderby album.Year,album.Title
                    select album;
            ListAlbum = new ObservableCollection<Album>();
            foreach (var album in l)
            {
                AddAlbum(album);
            }
        }

        /// <summary>
        /// Checks if a librairy is the same as an other one.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var album = obj as LibraryAlbum;
            return album != null &&
                   EqualityComparer<ObservableCollection<Album>>.Default.Equals(ListAlbum, album.ListAlbum);
        }

        /// <summary>
        /// return an hashcode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1727654344 + EqualityComparer<ObservableCollection<Album>>.Default.GetHashCode(ListAlbum);
        }
    }
}
