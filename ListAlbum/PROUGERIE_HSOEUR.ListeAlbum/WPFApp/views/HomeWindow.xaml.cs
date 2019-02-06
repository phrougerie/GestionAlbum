
using PROUGERIE_HSOEUR.ListeAlbum.models;
using PROUGERIE_HSOEUR.ListeAlbum.persistance;
using System.Windows;

namespace WPFApp.views
{
    /// <summary>
    /// Logique d'interaction pour HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private readonly PersistanceXml serdes= new PersistanceXml(); 
        public LibraryAlbum TheListAlbums { get; set; }
        //Initialise la fentre principale. Charge le fichier xml dans une library d'albums?
        public HomeWindow()
        {
             
            InitializeComponent();
            DataContext = this;
            TheListAlbums = new LibraryAlbum(serdes.Deserialize());
            
        }
        private void MasterUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserDetailed_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
