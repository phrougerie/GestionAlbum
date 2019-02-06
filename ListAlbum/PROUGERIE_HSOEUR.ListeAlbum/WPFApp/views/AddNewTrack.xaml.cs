using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour AddNewTrack.xaml
    /// </summary>
    public partial class AddNewTrack : Window
    {
        //Initialise une nouvelle fenetre AddNewTrack
        public AddNewTrack()
        {
            InitializeComponent();
            
        }
        //Ferme la fenetre AddNewtrack
        private void AddTrackOnClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Permet de récuperer un morceau depuis les fichiers
        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            string filepath="";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|FLAC files (*.flac)|*.flac|WAV files (*.wav)|*.wav|M4a files (*.m4a)|*.m4a|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filepath = openFileDialog.InitialDirectory + openFileDialog.FileName;
            }
            SongBox.Text=filepath;
        }
    }
}
