using Lab19App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19App1.ViewModels
{
    internal class MainWindowsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int number1;
        public int Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }
        private int number2;
        public int Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }
        private int number3;
        public int Number3
        {
            get => number3;
            set
            {
                number3 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Number3 = Ariph.Add(number1, number2);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (number1 != 0 || number2 != 0)
                return true;
            else
                return false;
        }

        public MainWindowsViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}
