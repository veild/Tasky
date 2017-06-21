using System;
using System.Windows.Input;

namespace Tasky
{
    class MainWindowView : BaseViewModel
    {
        public string MainWindowTitle { get; set; }
        public string TestLabel { get; set; }
        public string BtnCol { get; set; }
        public string BtnRow { get; set; }
        public string MainWindowHeight { get; set; }
        public string MainWindowWidth { get; set; }

        public ICommand ResizeWindowCommand { get; set; }

        public MainWindowView()
        {
            MainWindowTitle = "Hello World";
            TestLabel = "Hello";
            BtnCol = "0";
            BtnRow = "1";
            MainWindowHeight = "600";
            MainWindowWidth = "400";

            this.ResizeWindowCommand = new RelayCommand(ResizeWindow);

        }
        
        /// <summary>
        /// Sets the property Number_GB to the next entry of the collection Anzahl.
        /// </summary>
        public void ResizeWindow()
        {
            int height = int.Parse(MainWindowHeight) + 100;
            int width = int.Parse(MainWindowWidth) + 50;

            MainWindowHeight = $"{height}";
            MainWindowWidth = $"{width}";
        }
    }
}
