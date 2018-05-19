using PROUGERIE_HSOEUR.ListeAlbum.Controllers;

namespace PROUGERIE_HSOEUR.ListeAlbum.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new ConsoleView();
            var biblioControlSimul = new BiblioControl(view);
            biblioControlSimul.Start();
        }
    }
}
