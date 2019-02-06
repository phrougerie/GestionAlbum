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
        /// <summary>
        /// Display the text that's in param.
        /// </summary>
        /// <param name="textdisplay"></param>
        void DisplayText(string textdisplay);

        /// <summary>
        /// Ask for the number you want to choose.
        /// </summary>
        /// <param name="textToDisplay"></param>
        /// <returns></returns>
        int AskForNumber(string textToDisplay);

        /// <summary>
        /// Ask for the string you want to write.
        /// </summary>
        /// <param name="textToDisplay"></param>
        /// <returns></returns>
        string AskForString(string textToDisplay);

        /// <summary>
        /// Allows the user to enter a track
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        Track AskForTrack(Album album);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Album AskForAlbum();

        /// <summary>
        /// Allows a user to enter an album
        /// </summary>
        /// <param name="ret"></param>
        void VerifyBool(bool ret);

        /// <summary>
        /// Checks if the operation is successful or not.
        /// </summary>
        /// <param name="valid"></param>
        /// <returns></returns>
        string AskForTheModif(int valid);

        /// <summary>
        /// Allows the user to enter a time of track.
        /// </summary>
        /// <returns></returns>
        Time AskForTime();

        /// <summary>
        /// Ask for the minutes of the song's time.
        /// </summary>
        /// <returns></returns>
        int AskForMinute();

        /// <summary>
        /// Ask for the seconds of the song's time.
        /// </summary>
        /// <returns></returns>
        int AskForSeconds();

        /// <summary>
        /// Display the total time of the playlist.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hour"></param>
        void DisplayTimeList(Time time, int hour);

        /// <summary>
        /// Display the main menu.
        /// </summary>
        /// <returns></returns>
        int DisplayMenu();
    }
}
