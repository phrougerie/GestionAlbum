using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROUGERIE_HSOEUR.ListeAlbum.views
{
    public interface IView
    {
        void DisplayText(string textdisplay);

        int AskForNumber(string textToDisplay);

        string AskForString(string textToDisplay);

        Track AskForTrack(Album album);

        Album AskForAlbum();

        void VerifyBool(bool ret);

        string AskForTheModif(int valid);

        Time AskForTime();

        int AskForMinute();

        int AskForSeconds();

        void DisplayTimeList(Time time, int hour);

        int DisplayMenu();
    }
}
