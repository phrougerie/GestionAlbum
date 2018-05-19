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

        public LibraryEnum(List<Album> list)
        {
            _library = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _library.Capacity);
        }
        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
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

