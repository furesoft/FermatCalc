using FermatCalc.ViewModels;
using System;
using System.Windows.Input;

namespace FermatCalc.Commands;

internal class ForwardCommand : ICommand
{
    private MainViewModel mainViewModel;

    public ForwardCommand(MainViewModel mainViewModel)
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
        mainViewModel.SelectedPage++;
    }
}