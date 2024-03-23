using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace FermatCalc.Controls;

public class NavigationButtonGroup : TemplatedControl
{
    public static readonly StyledProperty<ICommand> TopCommandProperty =
        AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(TopCommand));

    public static readonly StyledProperty<ICommand> LeftCommandProperty =
        AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(LeftCommand));

    public static readonly StyledProperty<ICommand> RightCommandProperty =
        AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(RightCommand));

    public static readonly StyledProperty<ICommand> BottomCommandProperty =
        AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(BottomCommand));

    public ICommand TopCommand
    {
        get => GetValue(TopCommandProperty);
        set => SetValue(TopCommandProperty, value);
    }

    public ICommand LeftCommand
    {
        get => GetValue(LeftCommandProperty);
        set => SetValue(LeftCommandProperty, value);
    }

    public ICommand RightCommand
    {
        get => GetValue(RightCommandProperty);
        set => SetValue(RightCommandProperty, value);
    }

    public ICommand BottomCommand
    {
        get => GetValue(BottomCommandProperty);
        set => SetValue(BottomCommandProperty, value);
    }
}