using FermatCalc.ViewModels;
using System;
using System.Windows.Input;

namespace FermatCalc.Commands;

internal class ChangeEditModeCommand : ICommand
{
    private MainViewModel mainViewModel;

    public ChangeEditModeCommand(MainViewModel mainViewModel)
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
        mainViewModel.IsEditMode = !mainViewModel.IsEditMode;
    }
}