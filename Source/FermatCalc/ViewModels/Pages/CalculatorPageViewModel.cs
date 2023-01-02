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
    private bool _isEditMode;

    public CalculatorPageViewModel()
    {
        BackCommand = new BackCommand(this);
        ForwardCommand = new ForwardCommand(this);

        KeyboardLayout = Layout.NewEmptyKeyboard(96, 1);
        KeyboardLayout.ApplyLayoutFrom(Layout.Load("testLayout.xaml"));

        var layoutButtons = KeyboardLayout.Pages.SelectMany(_ => _);
        var resources = App.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().SelectMany(_ => _.Loaded);
        foreach (var res in resources)
        {
            var btn = new LayoutButton();
            btn.Display = res.Key.ToString();
            btn.PropertyChanged += (s, e) =>
            {
                SortAvailableButtons();
            };

            btn.IsVisible = !layoutButtons.Any(_ => _.Display == btn.Display);

            AvailableButtons.Add(btn);
        }

        AvailableButtons.Add(new LayoutButton() { Hint = "Remove" });

        ShowEditButtonPopupCommand = new ShowButtonPopupCommand(this);
        ApplyNewButtonCommand = new ApplyNewButtonCommand(this);
        ChangeEditModeCommand = new ChangeEditModeCommand(this);
    }

    public bool IsEditMode
    {
        get { return _isEditMode; }
        set
        {
            this.RaiseAndSetIfChanged(ref _isEditMode, value);
            if (!value)
            {
                KeyboardLayout.SaveTidy("testLayout.xaml");
            }
        }
    }

    public ICommand ChangeEditModeCommand { get; set; }

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

    private void SortAvailableButtons()
    {
        AvailableButtons = new(AvailableButtons.OrderByDescending(_ => _.IsVisible).OrderBy(_ => string.IsNullOrEmpty(_.Display)));
    }
}