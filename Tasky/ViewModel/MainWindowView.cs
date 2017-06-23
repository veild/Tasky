using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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
        /// Collection of tasks.
        /// </summary>
        public ObservableCollection<Task> TaskList { get; set; }

        /// <summary>
        /// Task class for the task list.
        /// </summary>
        public class Task
        {
            public string Name { get; set; }

            public Task(string name)
            {
                Name = name;
            }

            public string GetTaskName()
            {
                string name = Name;
                return name;
            }
        }
        
        /// <summary>
        /// Command for ResizeWindow().
        /// </summary>
        public ICommand ResizeWindowCommand { get; set; }

        /// <summary>
        /// Command for TaskPlus().
        /// </summary>
        public ICommand TaskPlusCommand { get; set; }

        /// <summary>
        /// Command for GetName().
        /// </summary>
        public ICommand GetNameCommand { get; set; }

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
            TaskList = new ObservableCollection<Task>();

            // Commands.
            this.ResizeWindowCommand = new RelayCommand(ResizeWindowPlus);
            this.TaskPlusCommand = new RelayCommand(TaskPlus);
            //this.GetNameCommand = new RelayCommand(GetName);
            this.GetNameCommand = new RelayCommand(param => this.GetName(param));

            ResizeWindow();
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

        public void GetName(object parameter)
        {
            Task task = (Task)parameter;
            MessageBox.Show(task.Name);
        }
    }
}
