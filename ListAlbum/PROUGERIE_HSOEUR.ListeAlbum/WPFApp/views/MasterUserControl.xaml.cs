using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFApp.views
{
    /// <summary>
    /// Logique d'interaction pour MasterUserControl.xaml
    /// </summary>
    public partial class MasterUserControl : UserControl
    {
        public static readonly DependencyProperty LAlbumProperty;
        public static readonly DependencyProperty SelectedAlbumProperty;
        public LibraryAlbum LAlbum
        {

            get { return (LibraryAlbum)GetValue(LAlbumProperty); }
            set { SetValue(LAlbumProperty, value); }
        }

        public Album SelectedAlbum
        {
            get { return (Album)GetValue(SelectedAlbumProperty); }
            set { SetValue(SelectedAlbumProperty, value); }
        }

        static MasterUserControl()
        {
            LAlbumProperty = DependencyProperty.Register("LAlbum", typeof(LibraryAlbum), typeof(MasterUserControl));
            SelectedAlbumProperty = DependencyProperty.Register("SelectedAlbum", typeof(Album), typeof(MasterUserControl));
        }
        public MasterUserControl()
        {
            InitializeComponent();
        }

        

        private void NewAlbumAdded(object sender, RoutedEventArgs e)
        {
            AddNewAlbum addNewAlbum = new AddNewAlbum();
            addNewAlbum.Closing+= newAlbum_Closing;
            addNewAlbum.ShowDialog();
        }
        void newAlbum_Closing(object sender, CancelEventArgs e)
        {
            var window = sender as AddNewAlbum;
            int year;
            if (int.TryParse(window.TextBoxYearAl.Text, out year))
            {
                if (year < 0) year=0;
            }
            else
            {
                year = 0;
            }
            
            if (window.TextBoxcle.Text!=""&& window.TextBoxNameAl.Text!=""&& window.TextBoxArtAl.Text!=""&& window.TextBoxGenreAl.Text!=""&&(year!=0)) {
                Album al = new Album(window.TextBoxcle.Text, window.TextBoxNameAl.Text, window.TextBoxArtAl.Text, window.TextBoxGenreAl.Text, year);
                (LAlbum as LibraryAlbum).AddAlbum(al);
            }
        }
    }
}
