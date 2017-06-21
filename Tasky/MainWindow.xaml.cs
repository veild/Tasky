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

#region Resize Window
        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    HwndSource source = HwndSource.FromVisual(this) as HwndSource;
        //    if (source != null)
        //    {
        //        source.AddHook(new HwndSourceHook(WinProc));
        //    }
        //}

        //public const Int32 WM_EXITSIZEMOVE = 0x0232;
        //private IntPtr WinProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
        //{
        //    IntPtr result = IntPtr.Zero;
        //    switch (msg)
        //    {
        //        case WM_EXITSIZEMOVE:
        //            {
        //                this.Height = this.Width * _aspectRatio;
        //                break;
        //            }
        //    }

        //    return result;
        //}
#endregion

    }
}
