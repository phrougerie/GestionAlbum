using PROUGERIE_HSOEUR.ListeAlbum.Controllers;

namespace PROUGERIE_HSOEUR.ListeAlbum.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var view = new ConsoleView();
            var biblioControlSimul = new BiblioControl(view);
            biblioControlSimul.Start();
        }
    }
}
