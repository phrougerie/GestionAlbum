using PROUGERIE_HSOEUR.ListeAlbum.models;
using PROUGERIE_HSOEUR.ListeAlbum.persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //Propriété définissant une liste d'albums. Bindée avec la liste d'albums générale
        public LibraryAlbum LAlbum
        {

            get { return (LibraryAlbum)GetValue(LAlbumProperty); }
            set { SetValue(LAlbumProperty, value); }
        }
        //Propriété permettant de faire communiquer l'album selectionné avec le detail
        public Album SelectedAlbum
        {
            get { return (Album)GetValue(SelectedAlbumProperty); }
            set { SetValue(SelectedAlbumProperty, value); }
        }
        //Definit les deux propriétés pré-citées
        static MasterUserControl()
        {
            LAlbumProperty = DependencyProperty.Register("LAlbum", typeof(LibraryAlbum), typeof(MasterUserControl));
            SelectedAlbumProperty = DependencyProperty.Register("SelectedAlbum", typeof(Album), typeof(MasterUserControl));
        }
        //Initialise le Master control
        public MasterUserControl()
        {
            InitializeComponent();
            
        }
        

        //Supprime un morceau selectioné, sinon ne fait rien
        private void OnTrackRemoved(object sender, RoutedEventArgs e)
        {
            if (SelectedAlbum != null)
            {
                LAlbum.DeleteAlbum((SelectedAlbum as Album).KeyAlbum);
            }
        }
        //Ouvre une nouvelle fenetre d'ajout d'album. Abonne newAlbum_Closing à l'événement Closing
        private void NewAlbumAdded(object sender, RoutedEventArgs e)
        {
            AddNewAlbum addNewAlbum = new AddNewAlbum();
            addNewAlbum.Closing+= newAlbum_Closing;
            addNewAlbum.ShowDialog();
        }
        //Effectuera les modifications à la fermeture de AddNewAlbum (un album sera ajouté à la lliste dans le detail)
        void newAlbum_Closing(object sender, CancelEventArgs e)
        {
            var window = sender as AddNewAlbum;
            int year;
            if (int.TryParse(window.TextBoxYearAl.Text, out year))
            {
                if (year < 0) year=-1;
            }
            else
            {
                year = -1;
            }
            Uri uri;
            string cover;
            if (Uri.TryCreate(window.TexBoxCover.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps || uri.Scheme==Uri.UriSchemeFile))
            {
                cover = window.TexBoxCover.Text;
            }
            else
            {
                cover = "Covers/CoverDefault.jpg";
            }

            if (window.TextBoxcle.Text!=""&& window.TextBoxNameAl.Text!=""&& window.TextBoxArtAl.Text!=""&& window.TextBoxGenreAl.Text!=""&&(year!=-1)) {
                Album al = new Album(window.TextBoxcle.Text, window.TextBoxNameAl.Text, window.TextBoxArtAl.Text, window.TextBoxGenreAl.Text, year, cover);
                (LAlbum as LibraryAlbum).AddAlbum(al);
            }
        }
        

        // Evenement de sauvegarde appelé quand on appuie sur le boutton de sauvegarde. la liste sera sauvegardée et une fenetre s'ouvrira pour indiquer à l'utilisateur qu"elle a bien eue lieu
        private void On_Saved(object sender, RoutedEventArgs e)
        {
            ConfirmWindowSave confirmWindowSave = new ConfirmWindowSave();
            PersistanceXml ser = new PersistanceXml();
            ser.Serialize(LAlbum as LibraryAlbum);
            confirmWindowSave.ShowDialog();
        }


        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        //Initialise le tri d'albums
        void GridViewColumnHeaderClickedHandler(object sender,RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;
            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }
                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);
                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }
                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        //methode de tri d'albums
            private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(AlbumListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

       

    }
}
