using FermatCalc.Commands;
using FermatCalc.KeyboardLayout;
using ReactiveUI;
using System.Windows.Input;

namespace FermatCalc.ViewModels.Pages;

public class CalculatorPageViewModel : ViewModelBase
{
    private Layout _keyboardLayout;
    private int _selectedPage;

    public CalculatorPageViewModel()
    {
        BackCommand = new BackCommand(this);
        ForwardCommand = new ForwardCommand(this);

        InitKeyboard();
        //KeyboardLayout.ApplyLayoutFrom(Layout.Load("testLayout.xaml"));
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

    private void InitKeyboard()
    {
        KeyboardLayout = new();

        var page = new LayoutPage();

        for (int i = 0; i < 30; i++)
        {
            var btn = new LayoutButton();
            btn.ID = i;

            page.Add(btn);
        }

        KeyboardLayout.Pages.Add(page);
    }
}