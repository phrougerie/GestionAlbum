using PROUGERIE_HSOEUR.ListeAlbum.views;
using PROUGERIE_HSOEUR.ListeAlbum.models;
using System.IO;
using System;
using System.Collections.Generic;
using LibraryALbumClass;
using PROUGERIE_HSOEUR.ListeAlbum.persistance;

namespace PROUGERIE_HSOEUR.ListeAlbum.Controllers
{
    public class BiblioControl
    {
        private readonly IView _view;


        public BiblioControl(IView view)
        {
            _view = view;
        }


        
        public void Start()
        {
            int valid;

            _view.DisplayText("Bienvenue dans la gestion d'album !");

            var serdes = new PersistanceXml();
            var library = new LibraryAlbum();
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
            library.AddAlbum(al2);
            library.AddAlbum(al1);
            var playlist = new Playlist();
            var aff=playlist.AddTrack("12346", "Karma Police", library);
            int hour1=0;
            Time time1 = playlist.TimeCalculator(ref hour1);
            _view.DisplayTimeList(time1, hour1);
            do
            {
                valid = _view.DisplayMenu();

                switch (valid)
                {
                    case 1:
                        _view.DisplayText("Voici la liste des albums enregistrés\nClé de l'album :\tTitre de l'album :\tDurée :\t\tArtist :\tGenre :\t\tAnnée :");
                        DisplayListAlbum(library);
                        break;
                    //OK
                    case 2:
                        ViewAlbum(library);
                        break;
                    //OK
                    case 3:
                        CreateAlbum(library);
                        break;
                    //OK
                    case 4:
                        DeleteAlb(library);
                        break;
                    //OK
                    case 5:
                        UpdateAlbum(library);
                        break;
                    //OK
                    case 6:
                        DeleteTrackLib(library);
                        break;
                    //ok
                    case 7:
                        AddTrackLib(library);
                        break;
                    // ok
                    case 8:
                        library=serdes.Deserialize();
                        break;
                    //pas ok
                    case 9:
                       serdes.Serialize(library);
                        break;
                    //pas ok
                    case 10:
                        AddTrackInList(library, playlist);
                        break;
                    case 11:
                        DisplayPlaylist(playlist);
                        break;
                    case 12:
                        ListBy(library);
                        break;
                    case 13:
                        PlayListSorting(playlist);
                        break;
                    default:
                        _view.DisplayText("Saisie incorrect !");
                        break;
                }

            } while (valid != 14);

        }
        private bool DisplayAlbum(string key, LibraryAlbum library)
        {
            foreach (var album in library)
            {
                if (album.KeyAlbum.Equals(key))
                {
                    Console.WriteLine(album.KeyAlbum + "\t" + album.Title + "\t" + album.TimeA.Min + " : " + album.TimeA.Sec + "\t" + album.Artist + "\t" + album.Genre + "\t" + album.Year);
                    DisplayList(album.ListTrack);
                    return true;
                }
            }
            return false;
        }

        private void ListBy(LibraryAlbum library)
        {
            var choice=_view.AskForNumber("1 - Trier par clé\n2 - Trier par artiste\n3 - Trier par album\n4 - Trier par genre\n5 - Trier par année");
            switch (choice)
            {
                default:
                    _view.DisplayText("Retour au menu principal");
                    return;
                case 1:
                    library.listByKey();
                    break;
                case 2:
                    library.listByArtist();
                    break;
                case 3:
                    library.listByAlbum();
                    break;
                case 4:
                    library.listByGenre();
                    break;
                case 5:
                    library.listByYear();
                    break;
            }
            DisplayListAlbum(library);
        }

        private void PlayListSorting(Playlist list)
        {
            var choice = _view.AskForNumber("1 - Trier par artiste\n2 - Trier par genre\n3 - Trier par année\n");
            switch (choice)
            {
                default:
                    _view.DisplayText("Retour au menu principal");
                    return;
                case 1:
                    list.ListByArtist();
                    break;
                case 2:
                    list.ListByGenre();
                    break;
                case 5:
                    list.ListByYear();
                    break;
            }
            DisplayPlaylist(list);
          }


        private void AddTrackInList(LibraryAlbum library, Playlist playlist)
        {
            int val1;
            int val2;
            bool aff = false;
            do
            {
                var key = _view.AskForString("Veuillez entrer la clé de l'album du morceau voulu:\n");
                DisplayAlbum(key, library);
                do
                {
                    var track = _view.AskForString("Veuillez entré le nom du morceau à ajouter à la playlist:\n");
                    aff = playlist.AddTrack(key, track, library);
                    _view.VerifyBool(aff);
                    val1 = _view.AskForNumber("Voulez vous ajouter un autre morceau de l'album : 1- Oui\t - Non");
                } while (val1 == 1);
                val2 = _view.AskForNumber("Voulez vous ajouter un autre morceau d'un autre album: 1- Oui\t - Non");
            } while (val2 == 1);
        }

        private void AddTrackLib(LibraryAlbum library)
        {
            
            int val1;
            int val2;
            bool aff = false;
            do
            {
                var key = _view.AskForString("Veuillez entrer une clé d'album :\n");
                DisplayAlbum(key, library);
                do
                {
                    foreach (var album in library)
                    {
                        if (album.KeyAlbum.Equals(key))
                        {
                            var track = _view.AskForTrack(album);
                            aff = album.AddTrack(track);
                            album.TimeCalculator();
                            break;
                        }
                    }
                    _view.VerifyBool(aff);
                    
                    val1 = _view.AskForNumber("Voulez vous ajouter un autre morceau ? 1 - Oui\t2 - Non");
                } while (val1 == 1);
                
                val2 = _view.AskForNumber("Voulez vous prendre un autre album ? 1 - Oui\t2 - Non");
                
            } while (val2 == 1);

        }

        private void DeleteTrackLib(LibraryAlbum library)
        {
            int val;
            do
            {
                var key = _view.AskForString("Veuillez entrer une clé d'album :\n");
                DisplayAlbum(key, library);
                var trackT = _view.AskForString("Entrer le nom du morceau à supprimer");
                var aff = library.DeleteTrack(key, trackT);
                _view.VerifyBool(aff);
                val = _view.AskForNumber("Voulez vous supprimer un autre morceau ? 1 - Oui\t2 - Non");
            } while (val == 1);
            
        }

        private void ViewAlbum(LibraryAlbum library)
        {
            int conf;
            do
            {
                var key = _view.AskForString("Veuiler entrer la clé de l'album");
                var verifyD = DisplayAlbum(key, library);
                _view.VerifyBool(verifyD);
                conf = _view.AskForNumber("Voulez vous afficher un autre album ? \t1 - Oui\t2 - Non");
            } while (conf == 1);
        }

        private void CreateAlbum(LibraryAlbum library)
        {
            int conf;
            int valid;
            do
            {
                _view.DisplayText("Ajout d'album selectioné :\n");
                Album album = _view.AskForAlbum();
                var done=library.AddAlbum(album);
                do
                {
                    Track track = _view.AskForTrack(album);
                    album.AddTrack(track);
                    valid = _view.AskForNumber("Voulez vous ajouter un autre morceau ? \t1 - Oui\t2 - Non");
                } while (valid == 1);
                album.TimeCalculator();

                conf = _view.AskForNumber("Voulez vous ajouter un autre album ? \t1 - Oui\t2 - Non");
            } while (conf == 1);
        }

        private void DeleteAlb(LibraryAlbum library)
        {
            int conf;
            do
            {
                _view.DisplayText("Suppression d'album sélectionnée :\n");
                var key = _view.AskForString("Entrer la clé d'identification de l'album");
                DisplayAlbum(key, library);
                var ret = library.DeleteAlbum(key);
                _view.VerifyBool(ret);
                conf = _view.AskForNumber("Voulez vous supprimer un autre album ? \t1 - Oui\t2 - Non");
            } while (conf == 1);
        }
        private void DisplayListAlbum(LibraryAlbum library)
        {
            foreach (var album in library)
            {
                Console.WriteLine(album.KeyAlbum + "\t" + album.Title + "\t" + album.TimeA.Min + " : " + album.TimeA.Sec + "\t" + album.Artist + "\t" + album.Genre + "\t" + album.Year);
                DisplayList(album.ListTrack);
            }
        }

        private void UpdateAlbum(LibraryAlbum library)
        {
            int conf;
            do
            {
                var verify = false;
                var key = _view.AskForString("Entrer la clé d'identification de l'album à modifier");
                DisplayAlbum(key, library);
                var valid = _view.AskForNumber("1 - Modifier le titre\n2 - Modifier la durée\n3 - Modifier l'artiste\n4 - Modifier le genre\n5 - Mofifier l'année\n");
                if (valid == 2)
                {
                    Time time = _view.AskForTime();
                    verify = library.ModifyTime(key, time.Min, time.Sec);
                }
                else if (valid == 5)
                {
                    int year = _view.AskForNumber("Entrer l'année");
                    verify = library.ModifyYear(key, year);
                }
                else
                {
                    var modif = _view.AskForTheModif(valid);
                    verify = library.ModifyAlbum(key, modif, valid);
                }
                _view.VerifyBool(verify);
                conf = _view.AskForNumber("Voulez vous modifier autre chose ? \t1 - Oui\t2 - Non");
            } while (conf == 1);
        }
        private void DisplayList(List<Track> listTrack)
        {
            foreach (var track in listTrack)
            {
                Console.WriteLine("\t" + track.Title + "    " + track.TimeT.Min + " : " + track.TimeT.Sec + "     " + track.Artist + "      " + track.Album + "      " + track.Genre + "        " + track.Year);
                
            }
        }

        private void DisplayPlaylist(Playlist playlist)
        {
            DisplayList(playlist.ListTrack);
            int hour=0;
            Time time=playlist.TimeCalculator(ref hour);
            _view.DisplayTimeList(time, hour);

        }
        
    }
}
