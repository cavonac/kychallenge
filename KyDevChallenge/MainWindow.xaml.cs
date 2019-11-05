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
using System.Windows.Threading;

namespace KyDevChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dtSeconds = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1) // hr, min, secs
            };

            dtSeconds.Tick += DtSeconds_Tick;
            dtSeconds.Start();
        }

        private void DtSeconds_Tick(object sender, EventArgs e)
        {
            // TODO: Change the execution of this event to increment a databound property
            timerLabel.Content = DateTime.Now.ToLongTimeString();
        }
    }
}
