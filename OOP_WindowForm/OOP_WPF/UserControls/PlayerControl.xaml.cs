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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {
        private string path = "/Icon/football-player.png";
        public string Image
        {
            get => path;
            set
            {
                if (value != "")
                    path = value;
            }
        }
        public string PlayerName { get; set; }
        public string ShirtNUmber { get; set; }
        public Player()
        {
            InitializeComponent();
        }

        public void InitFields()
        {
            image.Source = new BitmapImage(new Uri(Image, UriKind.Relative));
            lblName.Text = PlayerName;
            lblNumber.Text = ShirtNUmber;
        }
    }
}
