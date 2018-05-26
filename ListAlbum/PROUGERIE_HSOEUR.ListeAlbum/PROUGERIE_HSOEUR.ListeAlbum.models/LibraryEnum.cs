using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryALbumClass
{
    class LibraryEnum : IEnumerator
    {
        public List<Album> _library;

        int position = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public LibraryEnum(List<Album> list)
        {
            _library = list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return (position < _library.Capacity);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            position = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Album Current
        {
            get
            {
                try
                {
                    return _library[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}

