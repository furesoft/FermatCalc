using Avalonia.Controls;
using FermatCalc.Commands;
using FermatCalc.KeyboardLayout;
using ReactiveUI;
using System.Windows.Input;

namespace FermatCalc.ViewModels.Pages;

public class CalculatorPageViewModel : ViewModelBase
{
    private Layout _keyboardLayout;
    private int _selectedPage;

    private object _selectedNewFunction;

    public CalculatorPageViewModel()
    {
        BackCommand = new BackCommand(this);
        ForwardCommand = new ForwardCommand(this);

        KeyboardLayout = Layout.NewEmptyKeyboard(30, 3);
        KeyboardLayout.ApplyLayoutFrom(Layout.Load("testLayout.xaml"));
    }

    public object SelectedNewFunction
    {
        get { return _selectedNewFunction; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedNewFunction, value);
            var lbi = (ListBoxItem)value;
            var btn = (LayoutButton)lbi.Tag;
            btn.Display = lbi.Content.ToString();
        }
    }

    public int SelectedPage
    {
        get { return _selectedPage; }
        set { this.RaiseAndSetIfChanged(ref _selectedPage, value); }
    }

    public Layout KeyboardLayout
    {
        get { return _keyboardLayout; }
        set
        {
            this.RaiseAndSetIfChanged(ref _keyboardLayout, value);
        }
    }

    public ICommand BackCommand { get; set; }

    public ICommand ForwardCommand { get; set; }
}