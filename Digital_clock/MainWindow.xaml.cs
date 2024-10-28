using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Media.Animation;

namespace Digital_clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent(); // Ensure this is called to initialize the UI components

            Left = System.Windows.SystemParameters.WorkArea.Width - Width;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height;

            this.Loaded += MainWindow_Loaded; // Subscribe to the Loaded event
        }
        private DispatcherTimer timer;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, args) => digitalClock();
            timer.Start();
            digitalClock(); // Call method after the window is loaded
        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }
        private void digitalClock()
        {
            // Find the TextBlocks by their names within mainGrid
            var secondsTextBlock = mainGrid.Children.OfType<TextBlock>()
                                                    .FirstOrDefault(tb => tb.Name == "secondsTimer");
            var dateTextBlock = mainGrid.Children.OfType<TextBlock>()
                                                 .FirstOrDefault(tb => tb.Name == "dateTextBlock");

            // Update the time for secondsTimer
            if (secondsTextBlock != null)
            {
                secondsTextBlock.Text = DateTime.Now.ToString("HH:mm:ss tt");
            }

            // Update the date for dateTextBlock
            if (dateTextBlock != null)
            {
                dateTextBlock.Text = DateTime.Now.ToString("dd MMMM, yyyy"); // For example, "28 october, 2024"
            }
        }
    }
}
