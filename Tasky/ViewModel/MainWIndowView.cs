using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Tasky.ViewModel
{
    class MainWIndowView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MainWindowTitle { get; set; }
        public string TestLabel { get; set; }
        public MainWIndowView()
        {
            MainWindowTitle = "Hello World";
            TestLabel = "Hello";
        }
    }
}