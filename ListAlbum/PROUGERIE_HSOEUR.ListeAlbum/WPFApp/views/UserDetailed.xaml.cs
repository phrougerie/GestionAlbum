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

namespace WPFApp.views
{
    /// <summary>
    /// Logique d'interaction pour UserDetailed.xaml
    /// </summary>
    public partial class UserDetailed : UserControl
    {
        
        public static readonly DependencyProperty AlbumProperty;
        public Album TheAlbum
        {

            get { return (Album)GetValue(AlbumProperty); }
            set { SetValue(AlbumProperty, value); }
        }



        static UserDetailed()
        {
            AlbumProperty = DependencyProperty.Register("TheAlbum", typeof(Album), typeof(UserDetailed));

        }

        public UserDetailed()
        {
            InitializeComponent();
        }
    }
}
