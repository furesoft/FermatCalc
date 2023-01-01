using FermatCalc.ViewModels;
using System;
using System.Windows.Input;

namespace FermatCalc.Commands;

internal class BackCommand : ICommand
{
    private MainViewModel mainViewModel;

    public BackCommand(MainViewModel mainViewModel)
    {
        this.mainViewModel = mainViewModel;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        mainViewModel.SelectedPage--;
    }
}