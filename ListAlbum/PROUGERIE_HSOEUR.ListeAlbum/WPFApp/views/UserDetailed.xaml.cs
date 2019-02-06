using PROUGERIE_HSOEUR.ListeAlbum.models;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPFApp.views
{
    /// <summary>
    /// Logique d'interaction pour UserDetailed.xaml
    /// </summary>
    public partial class UserDetailed : UserControl
    {
        public static readonly DependencyProperty SelectedTrackProperty;
        public static readonly DependencyProperty AlbumProperty;
        //Definit la propriété sur un album, qui communique avec SelectedAlbum
        public Album TheAlbum
        {

            get { return (Album)GetValue(AlbumProperty); }
            set { SetValue(AlbumProperty, value); }
        }


        
        //Definit un morceau selectionné, pour permettre de le supprimer
        public Track SelectedTrack
        {
            get { return (Track)GetValue(SelectedTrackProperty); }
            set { SetValue(SelectedTrackProperty, value); }
        }
        
        static UserDetailed()
        {
            AlbumProperty = DependencyProperty.Register("TheAlbum", typeof(Album), typeof(UserDetailed));
            SelectedTrackProperty= DependencyProperty.Register("SelectedTrack", typeof(Track), typeof(UserDetailed));
        }

        public UserDetailed()
        {
            InitializeComponent();
            

            
        }
        
        //Ouvre la fenetre d'ajout d'album, abonne newTrack_Closing à Closing
        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            AddNewTrack addNewTrack = new AddNewTrack();
            addNewTrack.Closing += newTrack_Closing;
            if(TheAlbum != null) addNewTrack.ShowDialog();
            
        }
        //Quand la fentre se fermera un nouveau morceau sera ajouter si les paramètres sont valides
        void newTrack_Closing(object sender, CancelEventArgs e)
        {
            var window = sender as AddNewTrack;
            int min;
            int sec;
            int tracknum;
            
            if (int.TryParse(window.TextMinT.Text, out min))
            {
                if (min < 0) min = -1;
            }
            else
            {
                min = -1;
            }
            if (int.TryParse(window.TextSecT.Text, out sec))
            {
                if (sec<0||sec>59) min = -1;
            }
            else
            {
                min = -1;
            }
            if (!int.TryParse(window.TextNomTrack.Text, out tracknum))
            {
                tracknum = 0;
            }
            if (window.TextNameT.Text != "" && window.TextGenreT.Text != "" && min!=-1 && sec!=-1 && tracknum>0)
            {
                Track tr = new Track(window.TextNameT.Text,min,sec,(TheAlbum as Album).Artist,(TheAlbum as Album).Title,window.TextGenreT.Text,(TheAlbum as Album).Year,tracknum,window.SongBox.Text);
                (TheAlbum as Album).AddTrack(tr);
                TheAlbum .TimeCalculator();
            }
            else if(window.TextGenreT.Text == "" && window.TextNameT.Text != "" && min != -1 && sec != -1 && tracknum > 0)
            {
                Track tr = new Track(window.TextNameT.Text, min, sec, (TheAlbum as Album).Artist, (TheAlbum as Album).Title, (TheAlbum.Genre), (TheAlbum as Album).Year, tracknum, window.SongBox.Text);
                (TheAlbum as Album).AddTrack(tr);
                TheAlbum.TimeCalculator();
            }
        }

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;
        //Tri la liste de morceaux
        void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
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

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(myListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }
        //Supprime un morceau si selectionné
        private void Track_Removed(object sender, RoutedEventArgs e)
        {
            if (SelectedTrack != null)
            {
                Album al = TheAlbum as Album;

                al.ListTrack.Remove(SelectedTrack as Track);
                TheAlbum.TimeCalculator();
                
            }
        }
        //Ouvre la fenetre de modification de l'image
        
        private void Image_Modified(object sender, RoutedEventArgs e)
        {
            Modifmage modifmage = new Modifmage();
            modifmage.Closing += Image_Closing;
            if (TheAlbum != null)
            {
                modifmage.ShowDialog();
            }

        }
        //Effectue les changements quand la fenetre de modif d'image se ferme
        void Image_Closing(object sender, CancelEventArgs e)
         {
            var window = sender as Modifmage;
            Uri uri;
            if (Uri.TryCreate(window.TexBoxImage.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeFile))
            {
                (TheAlbum as Album).CoverAlbum = window.TexBoxImage.Text;
            }
            
         }


        private MediaPlayer mediaPlayer = new MediaPlayer();
        //Le button play permet de lancer le morceau
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }
        //Le boutton pause permet de mettre le morceau en pause
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }
        //Le boutton stop permet d'arreter le morceau
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            
        }
        //Affiche le temps actuel du morceau ou affiche un message si 
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan)
                timeState.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                timeState.Content = "Aucun fichier selectionné";
        }
        //Permet de modifier le volume
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            mediaPlayer.Volume = volumeSlider.Value;
            
        }
        //Permet de lire le morceau
        private void Play_Song(object sender, RoutedEventArgs e)
        {
            Uri uri;
            if (Uri.TryCreate(SelectedTrack.Music, UriKind.Absolute, out uri)&&  uri.Scheme==Uri.UriSchemeFile)
            {

                PlayThetrack(uri);
            }
            else if(Uri.TryCreate(SelectedTrack.Music, UriKind.Relative, out uri))
            {

                PlayThetrack(uri);
            }
        }
        //La methode ouvre le fichier, initialise le timer et lis le morceau
        private void PlayThetrack(Uri uri)
        {
            mediaPlayer.Open(uri);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            mediaPlayer.Play();
        }
        
    }
}
