﻿using System;
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
    /// Logique d'interaction pour AddNewAlbum.xaml
    /// </summary>
    public partial class AddNewAlbum : Window
    {
        public AddNewAlbum()
        {
            InitializeComponent();
        }

        private void AddAlbOnClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        
    }
}
