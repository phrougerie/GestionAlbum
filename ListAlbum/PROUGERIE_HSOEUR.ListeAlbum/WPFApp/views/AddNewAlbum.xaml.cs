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
    /// Logique d'interaction pour AddNewAlbum.xaml
    /// </summary>
    public partial class AddNewAlbum : Window
    {
        //Initialise une nouvelle fenetre AddNewTrack
        public AddNewAlbum()
        {

            InitializeComponent();
        }
        //Ferme la fenetre AddNewtrack
        private void AddAlbOnClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // Verifie sur l'uri entrée est valide et affiche l'image si c'est le cas
        private void ImageVerified(object sender, RoutedEventArgs e)
        {
            Uri uri;
            if (Uri.TryCreate(TexBoxCover.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps|| uri.Scheme==Uri.UriSchemeFile))
            {
                try
                {
                    Imageverif.Source = new BitmapImage(uri);
                }
                catch(DirectoryNotFoundException dirEx)
                {
                    TexBoxCover.Text = "Directory not found: " + dirEx.Message;
                    Imageverif.Source = new BitmapImage(new Uri("Covers/CoverDefault.jpg",UriKind.Relative));
                }
            }

            
            
        }
        //Permet de recuperer une image dans les fichiers
        private void Image_Choiced(object sender, RoutedEventArgs e)
        {
            string filepath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filepath = openFileDialog.InitialDirectory + openFileDialog.FileName;
            }
            TexBoxCover.Text = filepath;
        }
    }
}
