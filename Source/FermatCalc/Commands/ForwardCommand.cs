using FermatCalc.ViewModels.Pages;
using System;
using System.Windows.Input;

namespace FermatCalc.Commands;

internal class ForwardCommand : ICommand
{
    private CalculatorPageViewModel viewModel;

    public ForwardCommand(CalculatorPageViewModel vm)
    {
        this.viewModel = vm;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        viewModel.SelectedPage++;
    }
}