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
        var oldButton = calculatorPageViewModel.OldButton;
        var oldButtonActionID = calculatorPageViewModel.OldButton.ActionID;

        if (btn.Hint == "Remove")
        {
            oldButton.ActionID = null;
            oldButton.Hint = null;
            oldButton.Display = null;

            var navBtn = calculatorPageViewModel.AvailableButtons.First(_ => _.ActionID == oldButtonActionID);
            navBtn.IsVisible = true;

            calculatorPageViewModel.SortAvailableButtons();

            return;
        }

        calculatorPageViewModel.OldButton.Display = btn.Display;
        calculatorPageViewModel.OldButton.ActionID = btn.ActionID;
        calculatorPageViewModel.OldButton.Hint = btn.Hint;

        if (!string.IsNullOrEmpty(oldButtonActionID))
        {
            var avBtn = calculatorPageViewModel.AvailableButtons.First(_ => _.ActionID == btn.ActionID);
            avBtn.IsVisible = false;

            var navBtn = calculatorPageViewModel.AvailableButtons.First(_ => _.ActionID == oldButtonActionID);
            navBtn.IsVisible = true;
        }
        else
        {
            var avBtn = calculatorPageViewModel.AvailableButtons.First(_ => _.ActionID == btn.ActionID);
            avBtn.IsVisible = false;
        }
    }
}