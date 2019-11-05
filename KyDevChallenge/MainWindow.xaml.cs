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
using System.Windows.Threading;

namespace KyDevChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CounterModel counter;

        public MainWindow()
        {
            counter = new CounterModel()
            {
                CounterOutput = 0
            };

            DataContext = counter;
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
            // Increment watched counter object
            counter.CounterOutput++;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the watched counter object
            counter.CounterOutput = 0;
        }
    }
}
