using ReactiveUI;

namespace FermatCalc.ViewModels;

public class MainViewModel : ViewModelBase
{
    private bool _isEditMode;

    public bool IsEditMode
    {
        get { return _isEditMode; }
        set { this.RaiseAndSetIfChanged(ref _isEditMode, value); }
    }
}