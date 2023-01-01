using Avalonia.Markup.Xaml.MarkupExtensions;
using FermatCalc.Commands;
using FermatCalc.KeyboardLayout;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FermatCalc.ViewModels.Pages;

public class CalculatorPageViewModel : ViewModelBase
{
    private Layout _keyboardLayout;
    private int _selectedPage;

    private LayoutButton _oldButton;

    private ObservableCollection<LayoutButton> _availableButtons = new();

    private bool _isReplacePopupOpened;

    public CalculatorPageViewModel()
    {
        BackCommand = new BackCommand(this);
        ForwardCommand = new ForwardCommand(this);

        KeyboardLayout = Layout.NewEmptyKeyboard(30, 3);
        KeyboardLayout.ApplyLayoutFrom(Layout.Load("testLayout.xaml"));

        var resources = App.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().SelectMany(_ => _.Loaded);
        foreach (var res in resources)
        {
            var btn = new LayoutButton();
            btn.Display = res.Key.ToString();

            AvailableButtons.Add(btn);
        }

        ShowEditButtonPopupCommand = new ShowButtonPopupCommand(this);
        ApplyNewButtonCommand = new ApplyNewButtonCommand(this);
    }

    public bool IsReplacePopupOpened
    {
        get { return _isReplacePopupOpened; }
        set { this.RaiseAndSetIfChanged(ref _isReplacePopupOpened, value); }
    }

    public ObservableCollection<LayoutButton> AvailableButtons
    {
        get { return _availableButtons; }
        set { this.RaiseAndSetIfChanged(ref _availableButtons, value); }
    }

    public ICommand ShowEditButtonPopupCommand { get; set; }
    public ICommand ApplyNewButtonCommand { get; set; }

    public LayoutButton OldButton
    {
        get { return _oldButton; }
        set
        {
            this.RaiseAndSetIfChanged(ref _oldButton, value);
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