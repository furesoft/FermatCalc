using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace FermatCalc.Controls;

public class Display : Control
{
    public static StyledProperty<IBrush> BackgroundProperty = AvaloniaProperty.Register<Display, IBrush>(nameof(Background), Brushes.Beige);

    public IBrush Background
    {
        get
        {
            return GetValue(BackgroundProperty);
        }
        set
        {
            SetValue(BackgroundProperty, value);
        }
    }

    public override void Render(DrawingContext context)
    {
        context.DrawRectangle(Background, new Pen(Brushes.Black), new(0, 0, Width, Height), 5, 5);
    }

    protected override Size MeasureCore(Size availableSize)
    {
        Width = Math.Max(availableSize.Width, MinWidth) - Margin.Left - Margin.Right;

        return base.MeasureCore(availableSize);
    }
}