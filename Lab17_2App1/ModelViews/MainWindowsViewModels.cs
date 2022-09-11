using Lab17_2App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab17_2App1.ModelViews
{
    internal class MainWindowsViewModels:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        void OnPropertyChanged([CallerMemberName] string PropertyName =null)
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
        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Number2 = Ariph.Add(Number1);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (Number1 != 0)
                return true;
            else
                return false;
                
        }
        public MainWindowsViewModels()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }


    }
}
