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
using System.Windows.Shapes;

namespace WPFApp.views
{
    /// <summary>
    /// Logique d'interaction pour HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public static readonly DependencyProperty AlbumProperty;
        public Album Album
        {

            get { return (Album)GetValue(AlbumProperty); }
            set { SetValue(AlbumProperty, value); }
        }



        static HomeWindow()
        {
            AlbumProperty = DependencyProperty.Register("Album", typeof(Album), typeof(HomeWindow));

        }

        public HomeWindow()
        {

            InitializeComponent();
            LibraryAlbum listAlbums = new LibraryAlbum();
            listAlbums.ListAlbum.Add(new Album("1254", "Cdhamoix", "Gdddaja", "neo lama", 2019));
            listAlbums.ListAlbum.Add(new Album("1254", "Chamfoix", "Gcaja", "neo lama", 2019));
            listAlbums.ListAlbum.Add(new Album("1254", "Chamoix", "Gaja", "neo lama", 2019));
            listAlbums.ListAlbum.Add(new Album("1254", "Chcvamoix", "Gcaja", "neo lama", 2019));
            listAlbums.ListAlbum.Add(new Album("1254", "Chamcoix", "Gaja", "neo lama", 2019));
            DataContext = this;
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