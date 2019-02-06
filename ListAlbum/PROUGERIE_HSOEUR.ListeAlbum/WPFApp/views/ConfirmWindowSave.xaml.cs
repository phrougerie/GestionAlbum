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
    /// Logique d'interaction pour ConfirmWindowSave.xaml
    /// </summary>
    public partial class ConfirmWindowSave : Window
    {
        //Initialise la fenetre 
        public ConfirmWindowSave()
        {
            InitializeComponent();
        }
        //Ferme la fenetre
        private void OnCloseConfirmed(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
