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

#pragma warning disable 0067
        /// <summary>
        /// The event fired when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        /// <summary>
        /// Constructor with parameter for CommandParameter.
        /// </summary>
        /// <param name="action"></param>
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

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction?.Invoke();
            mActionObj?.Invoke(parameter);
        }
    }
}