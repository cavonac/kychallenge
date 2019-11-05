using System;
using System.Windows;
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
            // Initialize model and set to data context
            counter = new CounterModel();
            DataContext = counter;
            InitializeComponent();

            // Initialize dispatch timer object
            DispatcherTimer dtSeconds = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1) // hr, min, secs
            };

            // Call tick event and start timer
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
            // TODO: Add validation in the model object instead of a dialog box
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
            // Increment counter 
            counter.Count++;
        }
    }
}
