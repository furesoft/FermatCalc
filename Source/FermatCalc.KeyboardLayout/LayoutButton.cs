using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System.ComponentModel;
using System.Windows.Input;

namespace FermatCalc.KeyboardLayout;

public class LayoutButton : ReactiveObject
{
    private string _display;
    private string _actionID;
    private bool _visible;
    private object _icon;
    private string _hint;
    private bool _isShift;
    private bool _isAlpha;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ID { get; set; }

    public bool IsShift
    {
        get { return _isShift; }
        set { this.RaiseAndSetIfChanged(ref _isShift, value); }
    }

    public bool IsAlpha
    {
        get { return _isAlpha; }
        set { this.RaiseAndSetIfChanged(ref _isAlpha, value); }
    }

    public string Display
    {
        get { return _display; }
        set
        {
            this.RaiseAndSetIfChanged(ref _display, value);

            if (string.IsNullOrEmpty(value))
            {
                _display = null;
                IsVisible = false;
                Icon = null;

                return;
            }

            IsVisible = true;
            Icon = Application.Current.FindResource(value);
        }
    }

    public string Hint
    {
        get { return _hint; }
        set { this.RaiseAndSetIfChanged(ref _hint, value); }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object Icon
    {
        get { return _icon; }
        set { this.RaiseAndSetIfChanged(ref _icon, value); }
    }

    public string ActionID
    {
        get { return _actionID; }
        set { this.RaiseAndSetIfChanged(ref _actionID, value); }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsVisible
    {
        get { return _visible; }
        set { this.RaiseAndSetIfChanged(ref _visible, value); }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ICommand Command { get; set; }
}