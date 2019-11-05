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
                Timer = 0, 
                Count = 0
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
            counter.Timer++;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the watched counter object
            counter.Timer = 0;
        }

        private void SetTimerButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add validation in the model object
            var countText = setTimerTextBox.Text;
            if (int.TryParse(countText, out int result))
            {
                counter.Timer = result;
            }
            else
            {
                MessageBox.Show("Unable to parse input. Try again with an integer", 
                    "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SetCounterButton_Click(object sender, RoutedEventArgs e)
        {
            counter.Count++;
        }
    }
}
