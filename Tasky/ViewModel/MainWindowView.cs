using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Threading;

namespace Tasky
{
    class MainWindowView : BaseViewModel
    {
        /// <summary>
        /// Title of the MainWindow.
        /// </summary>
        public string MainWindowTitle { get; set; }

        /// <summary>
        /// Height of the MainWindow.
        /// </summary>
        public string MainWindowHeight { get; set; }

        /// <summary>
        /// Width of the MainWindow.
        /// </summary>
        public string MainWindowWidth { get; set; }

        /// <summary>
        /// Horizontal position of the MainWindow.
        /// </summary>
        public string MainWindowLeft { get; set; }

        /// <summary>
        /// Vertical position of the MainWindow.
        /// </summary>
        public string MainWindowTop { get; set; }

        /// <summary>
        /// Indicates whether the task is running or not.
        /// </summary>
        public string PlayPauseContent { get; set; }

        /// <summary>
        /// Collection of tasks.
        /// </summary>
        public ObservableCollection<Task> TaskList { get; set; }
        
        /// <summary>
        /// Command for ResizeWindow().
        /// </summary>
        public ICommand ResizeWindowCommand { get; set; }

        /// <summary>
        /// Command for TaskPlus().
        /// </summary>
        public ICommand TaskPlusCommand { get; set; }

        /// <summary>
        /// Command for TaskMinus().
        /// </summary>
        public ICommand TaskMinusCommand { get; set; }

        /// <summary>
        /// Command for PlayPause().
        /// </summary>
        public ICommand PlayPauseCommand { get; set; }

        /// <summary>
        /// The added height when a task has been added.
        /// </summary>
        private int mDeltaHeight = 50;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindowView()
        {
            // Init properties.
            MainWindowTitle = "Hello World";
            MainWindowHeight = "130";
            MainWindowWidth = "455";
            PlayPauseContent = "Run";
            TaskList = new ObservableCollection<Task>();

            // Commands.
            this.ResizeWindowCommand = new RelayCommand(ResizeWindowPlus);
            this.TaskPlusCommand = new RelayCommand(TaskPlus);
            this.TaskMinusCommand = new RelayCommand(param => this.TaskMinus(param));
            this.PlayPauseCommand = new RelayCommand(param => this.PlayPause(param));

            ResizeWindow();

            Thread thread = new Thread(new ThreadStart(RunTimes));
            thread.IsBackground = true;
            thread.Name = "Data Polling Thread";
            thread.Start();
        }

        /// <summary>
        /// Resizes the window depending on the screen resolution.
        /// </summary>
        public void ResizeWindow()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double screenX = 455;
            double screenY = 130;

            // TODO: more resolutions or responsive.
            if (screenWidth <= 1920)
            {
                screenX = 455;
                screenY = 130;
                
            }
            else if (screenWidth <= 3840)
            {
                screenX = 910.0;
                screenY = 260.0;
                mDeltaHeight = 80;
            }
            
            // TODO: test this
            double top = screenHeight - screenY - 50;

            MainWindowHeight = $"{screenY}";
            MainWindowWidth = $"{screenX}";
            MainWindowTop = $"{top}";
        }

        /// <summary>
        /// Resizes the window depending on the screen resolution.
        /// </summary>
        public void ResizeWindowPlus()
        {
            int height = int.Parse(MainWindowHeight) + mDeltaHeight;
            MainWindowHeight = $"{height}";

            int top = int.Parse(MainWindowTop) - mDeltaHeight;
            MainWindowTop = $"{top}";
        }

        /// <summary>
        /// Adds a task to the list.
        /// </summary>
        public void TaskPlus()
        {
            // Get TaskName of TextInput.
            TextInput txtÍnput = new TextInput();
            txtÍnput.ShowDialog();

            // Add the task to the list.
            if (string.IsNullOrEmpty(txtÍnput.TaskName))
                return;

            TaskList.Add(new Task(txtÍnput.TaskName));
            ResizeWindowPlus();
        }

        /// <summary>
        /// Removes the selected task from the list.
        /// </summary>
        /// <param name="parameter"></param>
        public void TaskMinus(object parameter)
        {
            Task task = (Task)parameter;
            int i = TaskList.IndexOf(task);
            if (TaskList[i].IsRunning) return;
            TaskList.RemoveAt(i);
        }

        public void PlayPause(object parameter)
        {
            Task task = (Task)parameter;
            int i = TaskList.IndexOf(task);
            if (TaskList[i].IsRunning)
            {
                TaskList[i].IsRunning = false;
                PlayPauseContent = "Play";
            }
            else
            {
                TaskList[i].IsRunning = true;
                PlayPauseContent = "||";
            }
        }

        /// <summary>
        /// Looks which tasks are running and updates their times.
        /// </summary>
        public void RunTimes()
        {
            while (true)
            {
                Thread.Sleep(1000);
                foreach (var task in TaskList)
                {
                    if (task.IsRunning)
                    {
                        DateTime dateTime = DateTime.ParseExact(task.Time, "HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime newTime = dateTime.Add(new TimeSpan(0, 0, 1));
                        task.Time = newTime.ToLongTimeString();
                    }
                }
            }
        }

        /// <summary>
        /// Task class for the task list.
        /// </summary>
        public class Task : BaseViewModel
        {
            public string Name { get; set; }
            public string Time { get; set; }
            public bool IsRunning { get; set; }

            public Task(string name)
            {
                Name = name;
                Time = "00:00:00";
                IsRunning = false;
            }

            public string GetTaskName()
            {
                string name = Name;
                return name;
            }
        }
    }
}
