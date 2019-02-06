using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Security.Principal;
namespace PROUGERIE_HSOEUR.ListeAlbum.persistance
{
    public class PersistanceXml
    {
        String fullPath = Path.Combine(Environment.CurrentDirectory, "SaveAlbum.xml");
        DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Album>));
        //Donne tous les droits à l'utilisateur sur le fichier xml
        private void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }
        /// <summary>
        /// Serialize a librairy.
        /// </summary>
        /// <param name="library"></param>
        public void Serialize(LibraryAlbum library)
        {
            GrantAccess(fullPath);
            using (Stream s = File.Create(fullPath))
                {
                    serializer.WriteObject(s, library.ListAlbum);
                }
            //work
        }
        /// <summary>
        /// Deserialize a librairy.
        /// </summary>
        /// <returns></returns>
        /// 
        
        public ObservableCollection<Album> Deserialize()
        {
            
            var tmp =new ObservableCollection<Album>();
            if (!File.Exists(fullPath))
            {

                using (System.IO.FileStream fs = System.IO.File.Create(fullPath))
                {

                }
                var al1 = new Album("12345", "Black album", "Metallica", "Trash", 1991,"pack://application:,,,/views/Covers/BlackAlbum.jpg");
                var m1 = new Track("Enter SandMan", 5, 10, "Metallica", "Black album", "Trash", 1991,1, "");

                var al2 = new Album("12346", "Ok Computer", "Radiohead", "Art rock", 1997, "https://images-na.ssl-images-amazon.com/images/I/91eIIIfAlSL._SL1500_.jpg");
                var m2 = new Track("Karma Police", 4, 21, "Radiohead", "Ok Computer", "Rock", 1997, 6, "06 Karma Police.mp3");

                al1.AddTrack(m1);
                al2.AddTrack(m2);
                
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
                    tmp = serializer.ReadObject(s) as ObservableCollection<Album>;
                }
            }
            
            return tmp;
        }

    }
}
