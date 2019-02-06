using PROUGERIE_HSOEUR.ListeAlbum.models;
using PROUGERIE_HSOEUR.ListeAlbum.views;
using System;

namespace PROUGERIE_HSOEUR.ListeAlbum.ConsoleApp
{
    internal class ConsoleView : IView
    {
        /// <summary>
        /// Displays the main menu.
        /// </summary>
        /// <returns></returns>
        public int DisplayMenu()
        {
            DisplayText("Menu");
            DisplayText("1 - Lister les albums");
            DisplayText("2 - Visualiser un album");
            DisplayText("3 - Creer un album");
            DisplayText("4 - Supprimer un album");
            DisplayText("5 - Mettre à jour");
            DisplayText("6 - Effacer des morceaux d'un album");
            DisplayText("7 - Ajouter un morceau à un album");
            DisplayText("8 - Charger le fichier"); ;
            DisplayText("9 - Sauvegarder le fichier");
            DisplayText("10 - Ajouter un morceau à la playlist");
            DisplayText("11 - Afficher la playlist");
            DisplayText("12 - Faire un tri de la liste d'album");
            var number = AskForNumber("13 - Faire un tri de la playlist\n");
            return number;
        }
        
        /// <summary>
        /// Display the text that's in param.
        /// </summary>
        /// <param name="textdisplay"></param>
        public void DisplayText(string textdisplay)
        {
            Console.WriteLine(textdisplay);
        }

        /// <summary>
        /// Ask for the number you want to choose.
        /// </summary>
        /// <param name="textdisplay"></param>
        /// <returns></returns>
        public int AskForNumber(string textdisplay)
        {
            int valid=1;
            int number;
            
            do
            {
                Console.WriteLine(textdisplay);
                string snumber = Console.ReadLine();
                Console.WriteLine("\n");
                if (!int.TryParse(snumber, out number))
                {
                    Console.WriteLine(snumber + " est incorrect");
                }
                else
                {
                    valid = 0;
                }


            } while (valid==1);
            return number;
        }
        /// <summary>
        /// Display the total time of the playlist.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hour"></param>
        public void DisplayTimeList(Time time, int hour)
        {
            Console.WriteLine("Le temps de la liste est de : " + hour + " h, " + time.Min + " m, " + time.Sec + ".");
        }
        /// <summary>
        /// Ask for the string you want to write.
        /// </summary>
        /// <param name="textdisplay"></param>
        /// <returns></returns>
        public string AskForString(string textdisplay)
        {
            Console.WriteLine(textdisplay);
            string chaine = Console.ReadLine();
            Console.WriteLine("\n");
            return chaine;

        }
        /// <summary>
        /// Ask for the time of a track.
        /// </summary>
        /// <returns></returns>
        public Time AskForTime()
        {
            
            DisplayText("Donner la durée");
            var min = AskForMinute();
            var sec = AskForSeconds();
            return new Time(min, sec);

        }
        /// <summary>
        /// Ask for the seconds of the song's time.
        /// </summary>
        /// <returns></returns>
        public int AskForSeconds()
        {
            int sec;
            var valid = 1;
            do
            {
                var ssec = AskForString("Donner le nombre de secondes\n");
                if (!int.TryParse(ssec, out sec))
                {
                    Console.WriteLine(ssec + " n'estpas un entier");
                }
                else
                {
                    if (sec <= 60)
                    {
                        valid = 0;
                    }
                    else
                    {
                        DisplayText("L'entier est supérieur à 60");
                    }
                }
            } while (valid == 1);
            return sec;
        }
        /// <summary>
        /// Ask for the minutes of the song's time.
        /// </summary>
        /// <returns></returns>
        public int AskForMinute()
        {
            int min;
            var valid = 1;
            do
            {
                var smin = AskForString("Donner le nombre de minutes\n");
                if (!int.TryParse(smin, out min))
                {
                    Console.WriteLine(smin + " n'estpas un entier");
                }
                else
                {
                    valid = 0;
                }
            } while (valid == 1);
            return min;
        }
        /// <summary>
        /// Allows a user to enter an album
        /// </summary>
        /// <returns></returns>
        public Album AskForAlbum()
        {
            var code = AskForString("Entrez la clé unique de l'album");
            var title = AskForString("Donner le titre :\n");
            var artist = AskForString("Donner l'artiste :\n");
            var genre= AskForString("Donner le genre:\n");
            var year = AskForNumber("Donner l'année :\n");

            return new Album(code,title, artist, genre, year);

        }

        /// <summary>
        /// Checks if the operation is successful or not.
        /// </summary>
        /// <param name="ret"></param>
        public void VerifyBool(bool ret)
        {
            if(ret == true)
            {
                Console.WriteLine("L'action a été bien executée\n");
            }
            else
            {
                Console.WriteLine("Impossible d'effectuer l'action\n");
            }
        }


        /// <summary>
        /// Allows the user to enter a track.
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public Track AskForTrack(Album album)
        {
            var title = AskForString("Donner le titre du morceau :\n");
            var time = AskForTime();
            var genre = AskForString("Donner le genre:\n");
       
            return new Track(title, time.Min, time.Sec, album.Artist,album.Title, genre, album.Year,1);

        }

        /// <summary>
        /// Allows the user to change an album or a track.
        /// </summary>
        /// <param name="valid"></param>
        /// <returns></returns>
        public string AskForTheModif(int valid)
        {
            
            string ret="";
            switch (valid)
            {
                case 1:
                    ret =AskForString("Entrer un titre\n");
                    break;
                case 3:
                    ret =AskForString("Entrer un artiste\n");
                    break;
                case 4:
                    ret =AskForString("Entrer un genre\n");
                    break;
                
            }
            return ret;
        }
    }
}
