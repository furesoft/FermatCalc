﻿using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System.ComponentModel;

namespace FermatCalc.KeyboardLayout;

public class LayoutButton : ReactiveObject
{
    private string _display;
    private string _actionID;
    private bool _visible;
    private object _icon;
    private string _hint;
    public int ID { get; set; }

    public string Display
    {
        get { return _display; }
        set
        {
            this.RaiseAndSetIfChanged(ref _display, value);
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
}