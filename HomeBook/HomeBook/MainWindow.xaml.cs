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

namespace HomeBook
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOperations_Click(object sender, RoutedEventArgs e)
        {
            Operations operations = new Operations();
            operations.Show();
            this.Close();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Close();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            Settings units = new Settings();
            units.Show();
            this.Close();
        }
    }
}
