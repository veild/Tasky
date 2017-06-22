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
                return;

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
            this.Left = System.Windows.SystemParameters.WorkArea.Width - MainWindow.WindowWidth * 3;
            this.Top = System.Windows.SystemParameters.WorkArea.Height - MainWindow.WindowHeight;
        }
    }
}
