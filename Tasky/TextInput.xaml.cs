using System.Windows;

namespace Tasky
{
    /// <summary>
    /// Interaktionslogik für TextInput.xaml
    /// </summary>
    public partial class TextInput : Window
    {
        /// <summary>
        /// Input string for TaskName.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Height of this window.
        /// </summary>
        public string TextInputWindowHeight { get; set; }

        /// <summary>
        /// Width of this window.
        /// </summary>
        public string TextInputWindowWidth { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TextInput()
        {
            InitializeComponent();
            TaskName = "";
            TextBoxTaskName.Focus();
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxTaskName.Text))
            {
                TextBoxTaskName.Focus();
                return;
            }

            TaskName = TextBoxTaskName.Text;
            this.Close();
        }

        /// <summary>
        /// Sets the starting window location relativ to the MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = System.Windows.SystemParameters.WorkArea.Width - (MainWindow.WindowWidth * 4);
            this.Top = System.Windows.SystemParameters.WorkArea.Height - MainWindow.WindowHeight;

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double screenX = 220;
            double screenY = 90;

            if (screenWidth <= 1920)
            {
                screenX = 220;
                screenY = 90;

            }
            else if (screenWidth <= 3840)
            {
                screenX = 440.0;
                screenY = 180.0;
            }

            TextInputWindowHeight = $"{screenY}";
            TextInputWindowWidth = $"{screenX}";
        }
    }
}
