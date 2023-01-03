using FermatCalc.KeyboardLayout;
using FermatCalc.ViewModels.Pages;
using System;
using System.Linq;
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
        var oldButton = calculatorPageViewModel.OldButton.Display;

        calculatorPageViewModel.OldButton.Display = btn.Display;
        calculatorPageViewModel.OldButton.ActionID = btn.ActionID;

        if (btn.Hint == "Remove")
        {
            var navBtn = calculatorPageViewModel.AvailableButtons.First(_ => _.Display == oldButton);
            navBtn.IsVisible = true;
            return;
        }

        if (!string.IsNullOrEmpty(btn.Display))
        {
            var avBtn = calculatorPageViewModel.AvailableButtons.First(_ => _.Display == btn.Display);
            avBtn.IsVisible = false;

            var navBtn = calculatorPageViewModel.AvailableButtons.First(_ => _.Display == oldButton);
            navBtn.IsVisible = true;
        }
    }
}