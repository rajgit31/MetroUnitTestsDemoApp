using System;
using System.Linq;
using System.Windows.Input;

namespace FileAccessDemo
{
    public class CalculateCommand : ICommand
    {
        public CalculateCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var model = (FileDataViewModel)parameter;

            if (!string.IsNullOrEmpty(model.FileContent))
                model.TotalValue = model.FileContent.Split(',').Sum(num => int.Parse(num)).ToString();
        }


        public event EventHandler CanExecuteChanged;

    }
}