using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EasyProof
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _rawText;
        public string RawText
        {
            get => _rawText;
            set
            {
                _rawText = value;

                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(nameof(RawText)));
            }
        }

        private string _proofedText;
        public string ProofedText
        {
            get => _proofedText;
            set
            {
                _proofedText = value;

                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(nameof(ProofedText)));
            }
        }

        private Visibility _processing = Visibility.Collapsed;
        public Visibility Processing
        {
            get => _processing;
            set
            {
                _processing = value;

                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(nameof(Processing)));
            }
        }

        public ICommand ProofCommand { get; }
        public ICommand ClearAllCommand { get; }

        public Model(Func<Task> Proof, Action ClearAll)
        {
            ProofCommand = new ProofCommand(Proof);
            ClearAllCommand = new ClearAllCommand(ClearAll);
        }
    }
}
