using FermatCalc.KeyboardLayout;
using FermatCalc.ViewModels.Pages;
using System;
using System.Windows.Input;

namespace FermatCalc.Commands;

internal class ApplyNewButtonCommand : ICommand
{
    private CalculatorPageViewModel calculatorPageViewModel;

    public ApplyNewButtonCommand(CalculatorPageViewModel calculatorPageViewModel)
    {
        this.calculatorPageViewModel = calculatorPageViewModel;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var btn = (LayoutButton)parameter;

        calculatorPageViewModel.OldButton.Display = btn.Display;
        calculatorPageViewModel.OldButton.ActionID = btn.ActionID;
    }
}