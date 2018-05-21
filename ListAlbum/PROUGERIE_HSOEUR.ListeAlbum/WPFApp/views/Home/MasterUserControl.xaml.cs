using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp.views.Home
{
    /// <summary>
    /// Logique d'interaction pour MasterUserControl.xaml
    /// </summary>
    public partial class MasterUserControl : UserControl
    {
        public MasterUserControl()
        {
            
            InitializeComponent();
            List<Album> albums = new List<Album>();
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoixddddddddd", "Gajaddddddddddd", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            albums.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            albums.Add(new Album("124575", "Chamoix", "hj", "neo lama", 2019));
            AlbumListBox.ItemsSource = albums;
            this.DataContext = albums;
        }
    }
}
