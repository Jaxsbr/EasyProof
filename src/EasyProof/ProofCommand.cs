using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasyProof
{
    public class ProofCommand : ICommand
    {
        private readonly Func<Task> _execute;

        public ProofCommand(Func<Task> execute) => _execute = execute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
