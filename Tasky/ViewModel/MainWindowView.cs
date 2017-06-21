using System;
using System.Collections.ObjectModel;
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
        public string TestName { get; set; }
        public ObservableCollection<string> TaskList { get; set; }

        static double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
        static double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

        public ICommand ResizeWindowCommand { get; set; }
        public ICommand TaskPlusCommand { get; set; }

        public MainWindowView()
        {
            MainWindowTitle = "Hello World";
            TestLabel = "Hello";
            BtnCol = "0";
            BtnRow = "2";
            MainWindowHeight = "130";
            MainWindowWidth = "455";

            TaskList = new ObservableCollection<string>();
            TestName = "Task 1";

            this.ResizeWindowCommand = new RelayCommand(ResizeWindowPlus);
            this.TaskPlusCommand = new RelayCommand(TaskPlus);

        }
        
        /// <summary>
        /// Resizes the window depending on the screen resolution.
        /// </summary>
        public void ResizeWindowPlus()
        {
            int height = int.Parse(MainWindowHeight) + 50;
            MainWindowHeight = $"{height}";
        }

        /// <summary>
        /// Adds a task to the list.
        /// </summary>
        public void TaskPlus()
        {
            TaskList.Add(TestName);
            ResizeWindowPlus();
        }
    }
}
