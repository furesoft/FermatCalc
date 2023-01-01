using FermatCalc.KeyboardLayout;
using FermatCalc.ViewModels.Pages;
using System;
using System.Windows.Input;

namespace FermatCalc.Commands;

internal class ShowButtonPopupCommand : ICommand
{
    private CalculatorPageViewModel calculatorPageViewModel;

    public ShowButtonPopupCommand(CalculatorPageViewModel calculatorPageViewModel)
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
        calculatorPageViewModel.OldButton = (LayoutButton)parameter;
    }
}