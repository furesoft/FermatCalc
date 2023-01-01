using Avalonia;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace FermatCalc.Controls;

public class NavigationButtonGroup : TemplatedControl
{
    public static StyledProperty<ICommand> TopCommandProperty = AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(TopCommand));
    public static StyledProperty<ICommand> LeftCommandProperty = AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(LeftCommand));
    public static StyledProperty<ICommand> RightCommandProperty = AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(RightCommand));
    public static StyledProperty<ICommand> BottomCommandProperty = AvaloniaProperty.Register<NavigationButtonGroup, ICommand>(nameof(BottomCommand));

    public ICommand TopCommand
    {
        get { return GetValue(TopCommandProperty); }
        set { SetValue(TopCommandProperty, value); }
    }

    public ICommand LeftCommand
    {
        get { return GetValue(LeftCommandProperty); }
        set { SetValue(LeftCommandProperty, value); }
    }

    public ICommand RightCommand
    {
        get { return GetValue(RightCommandProperty); }
        set { SetValue(RightCommandProperty, value); }
    }

    public ICommand BottomCommand
    {
        get { return GetValue(BottomCommandProperty); }
        set { SetValue(BottomCommandProperty, value); }
    }
}