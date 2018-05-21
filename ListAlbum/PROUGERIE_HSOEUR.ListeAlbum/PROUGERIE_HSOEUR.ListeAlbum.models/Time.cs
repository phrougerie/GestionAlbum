using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    public class Time
    {
        public int Min {get;  set;}
        public int Sec { get; internal set; }
        public Time(int min,int sec)
        {
            Min = min;
            Sec = sec;
        }
    }

}
