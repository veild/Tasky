using System.Windows;

namespace Tasky
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Height of the MainWindow.
        /// </summary>
        public static double WindowHeight;

        /// <summary>
        /// Width of this MainWindow.
        /// </summary>
        public static double WindowWidth;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            WindowHeight = this.Width;
            WindowWidth = this.Height;

            this.DataContext = new MainWindowView();
        }

        /// <summary>
        /// Sets the starting window location to the bottom left corner.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = System.Windows.SystemParameters.WorkArea.Width - MainWindowView.Width;
            this.Top = System.Windows.SystemParameters.WorkArea.Height - MainWindowView.Height;
        }
    }
}
