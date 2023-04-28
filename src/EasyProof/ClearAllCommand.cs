using System;
using System.Windows.Input;

namespace EasyProof
{
    public class ClearAllCommand : ICommand
    {
        private readonly Action _execute;

        public ClearAllCommand(Action execute) => _execute = execute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
