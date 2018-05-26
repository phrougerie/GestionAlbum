using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace PROUGERIE_HSOEUR.ListeAlbum.persistance
{
    public class PersistanceXml
    {
        String fullPath = Path.Combine(Environment.CurrentDirectory, "SaveAlbum.xml");
        DataContractSerializer serializer = new DataContractSerializer(typeof(List<Album>));
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="library"></param>
        public void Serialize(LibraryAlbum library)
        {
            
                using (Stream s = File.Create(fullPath))
                {
                    serializer.WriteObject(s, library.ListAlbum);
                }
            //work
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public LibraryAlbum Deserialize()
        {
            var tmp =new List<Album>();
            if (!File.Exists(fullPath))
            {
                //File.Create(fullPath);
                
                var al1 = new Album("12345", "Black album", "Metallica", "Trash", 1991);
                var m1 = new Track("Nothing else matter", 5, 10, "Metallica", "Black album", "Power ballad", 1991);
                
                var al2 = new Album("12346", "Ok Computer", "Radiohead", "Art rock", 1997);
                var m2 = new Track("Karma Police", 4, 33, "Radiohead", "Ok Computer", "Rock", 1997);
                var m3 = new Track("Exit music(for a film)", 5, 22, "Radiohead", "Ok Computer", "Rock", 1997);
                al1.AddTrack(m1);
                al2.AddTrack(m2);
                al2.AddTrack(m3);
                al1.TimeCalculator();
                al2.TimeCalculator();
                tmp.Add(al1);
                tmp.Add(al2);
                Serialize(new LibraryAlbum(tmp));
            }
            else
            {
                using (Stream s = File.OpenRead(fullPath))
                {
                    tmp = serializer.ReadObject(s) as List<Album>;
                }
            }
            
            
            var lib = new LibraryAlbum(tmp);
            return lib;
        }

    }
}
