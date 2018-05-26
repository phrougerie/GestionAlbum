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
        /// 
        /// </summary>
        /// <param name="textdisplay"></param>
        void DisplayText(string textdisplay);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textToDisplay"></param>
        /// <returns></returns>
        int AskForNumber(string textToDisplay);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textToDisplay"></param>
        /// <returns></returns>
        string AskForString(string textToDisplay);

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="ret"></param>
        void VerifyBool(bool ret);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valid"></param>
        /// <returns></returns>
        string AskForTheModif(int valid);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Time AskForTime();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int AskForMinute();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int AskForSeconds();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hour"></param>
        void DisplayTimeList(Time time, int hour);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int DisplayMenu();
    }
}
