using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.models
{
    [DataContract(Name = "time")]
    public class Time
    {
        [DataMember]
        public int Min {get;  set;}
        [DataMember]
        public int Sec { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        public Time(int min,int sec)
        {
            Min = min;
            Sec = sec;
        }
    }

}
