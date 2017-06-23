using System;
using System.Windows.Input;

namespace Tasky
{
    /// <summary>
    /// A basic command that runs an Action.
    /// </summary>
    class RelayCommand : ICommand
    {
        /// <summary>
        /// The action to run.
        /// </summary>
        private Action mAction;
        private Action<object> mActionObj;

        /// <summary>
        /// The event fired when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public RelayCommand(Action<object> action)
        {
            mActionObj = action;
        }

        /// <summary>
        /// A relay can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                mAction();
            }
            catch { }
            try
            {
                mActionObj(parameter);
            }
            catch { }
        }
    }
}