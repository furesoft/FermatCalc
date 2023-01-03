using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace FermatCalc.Controls;

public class Display : Control
{
    public static StyledProperty<IBrush> BackgroundProperty = AvaloniaProperty.Register<Display, IBrush>(nameof(Background), Brushes.Beige);
    private readonly Cursor cursor = new();

        cursor.Position = new(10, 10);
        cursor.Display = this;

        var renderTimer = new Timer();
        renderTimer.Interval = 500;
        renderTimer.Elapsed += (s, e) =>
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                InvalidateVisual();
            });
        };
        renderTimer.Start();
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
            cursor.Render(context);
    }

    protected override Size MeasureCore(Size availableSize)
    {
        Width = Math.Max(availableSize.Width, MinWidth) - Margin.Left - Margin.Right;

        return base.MeasureCore(availableSize);
    }
}