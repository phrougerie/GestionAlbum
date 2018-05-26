
using PROUGERIE_HSOEUR.ListeAlbum.models;
using PROUGERIE_HSOEUR.ListeAlbum.persistance;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp.views
{
    /// <summary>
    /// Logique d'interaction pour HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public LibraryAlbum TheListAlbums { get; set; }
        public HomeWindow()
        {
            
            InitializeComponent();
            DataContext = this;
            var serdes = new PersistanceXml();
            TheListAlbums = serdes.Deserialize();
            
        }
        //Probleme: les binding ne fonctionnent pas
        private void MasterUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserDetailed_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
