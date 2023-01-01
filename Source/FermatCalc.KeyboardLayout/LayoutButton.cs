using ReactiveUI;

namespace FermatCalc.KeyboardLayout;

public class LayoutButton : ReactiveObject
{
    private string _display;
    private string _actionID;
    private bool _visible;
    public int ID { get; set; }

    public string Display
    {
        get { return _display; }
        set
        {
            this.RaiseAndSetIfChanged(ref _display, value);
            IsVisible = true;
        }
    }

    public string ActionID
    {
        get { return _actionID; }
        set { this.RaiseAndSetIfChanged(ref _actionID, value); }
    }

    public bool IsVisible
    {
        get { return _visible; }
        set { this.RaiseAndSetIfChanged(ref _visible, value); }
    }
}