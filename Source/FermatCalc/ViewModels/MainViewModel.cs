using FermatCalc.Commands;
using ReactiveUI;
using System.Windows.Input;

namespace FermatCalc.ViewModels;

public class MainViewModel : ViewModelBase
{
    private bool _isEditMode;

    public MainViewModel()
    {
        ChangeEditModeCommand = new ChangeEditModeCommand(this);
    }

    public bool IsEditMode
    {
        get { return _isEditMode; }
        set { this.RaiseAndSetIfChanged(ref _isEditMode, value); }
    }

    public ICommand ChangeEditModeCommand { get; set; }
}