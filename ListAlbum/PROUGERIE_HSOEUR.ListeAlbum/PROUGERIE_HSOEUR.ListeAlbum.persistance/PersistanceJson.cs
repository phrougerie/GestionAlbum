     using Newtonsoft.Json;
using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.persistance
{
    public class PersistanceJson
    {

        public void Serialize(LibraryAlbum library)
        {
            
            String fullPath = Path.Combine(Environment.CurrentDirectory, "config.json");
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(fullPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {



                serializer.Serialize(writer, library);

            }
           
        }

        public LibraryAlbum Deserialize()
        {
            string fullPath = Path.Combine(Environment.CurrentDirectory, "config.json"); //pr gerer path system pas besoin de demander si / ,// ou \
            using (StreamReader r = new StreamReader(fullPath))
            {
                string content = File.ReadAllText(fullPath);

                LibraryAlbum l = JsonConvert.DeserializeObject<LibraryAlbum>(content);
                return l;
            }
        }
    }
}
