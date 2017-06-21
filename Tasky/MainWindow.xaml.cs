using System;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace Tasky
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double _aspectRatio = 1.6;

        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = new MainWindowView();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = System.Windows.SystemParameters.WorkArea.Width - this.Width;
            this.Top = System.Windows.SystemParameters.WorkArea.Height - this.Height;
        }
    }
}
