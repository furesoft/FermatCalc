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

    private bool _isAlpha;

    private bool _isShift;

    public CalculatorPageViewModel()
    {
        BackCommand = new BackCommand(this);
        ForwardCommand = new ForwardCommand(this);

        KeyboardLayout = Layout.NewEmptyKeyboard(96, 4);
        KeyboardLayout.ApplyLayoutFrom(Layout.Load("testLayout.xaml"));

        var layoutButtons = KeyboardLayout.Pages.SelectMany(_ => _);
        var resources = App.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().SelectMany(_ => _.Loaded);

        ActionRepository.Register("number:0", "number0", null, null);
        ActionRepository.Register("number:1", "number1", null, null);
        ActionRepository.Register("number:2", "number2", null, null);
        ActionRepository.Register("number:3", "number3", null, null);
        ActionRepository.Register("number:4", "number4", null, null);

        foreach (var action in ActionRepository.Actions)
        {
            var btn = new LayoutButton();
            btn.Display = action.Value.Display;
            btn.ActionID = action.Key;
            btn.Hint = action.Value.Hint;

            btn.PropertyChanged += (s, e) =>
            {
                SortAvailableButtons();
            };

            btn.IsVisible = !layoutButtons.Any(_ => _.ActionID == btn.ActionID);

            AvailableButtons.Add(btn);
        }

        AvailableButtons.Add(new LayoutButton() { Hint = "Remove", Display = "Remove", IsVisible = true });

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

    public bool IsAlpha
    {
        get { return _isAlpha; }
        set
        {
            this.RaiseAndSetIfChanged(ref _isAlpha, value);

            if (value)
            {
                SelectedPage += 1;
            }
            else
            {
                SelectedPage -= 1;
            }
        }
    }

    public bool IsShift
    {
        get { return _isShift; }
        set
        {
            this.RaiseAndSetIfChanged(ref _isShift, value);

            if (value)
            {
                SelectedPage += 2;
            }
            else
            {
                SelectedPage -= 2;
            }
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

    public override void OnLoad()
    {
        foreach (var btn in KeyboardLayout.Pages[0])
        {
            btn.Command = new DelegateCommand(_ =>
            {
                ActionRepository.Invoke(btn.ActionID);
            });
        }
    }

    public void SortAvailableButtons()
    {
        AvailableButtons = new(AvailableButtons.OrderByDescending(_ => _.IsVisible).OrderBy(_ => _.Hint == "Remove"));
    }
}