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
    }
}
