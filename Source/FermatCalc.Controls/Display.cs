using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace FermatCalc.Controls;

public class Display : Control
{
    public static StyledProperty<IBrush> BackgroundProperty = AvaloniaProperty.Register<Display, IBrush>(nameof(Background), Brushes.Beige);
    private readonly Cursor cursor;
    private readonly ResultRenderer resultRenderer;

    public Display()
    {
        cursor = new(this);
        cursor.Position = new(10, 10);

        resultRenderer = new(this);

        var renderTimer = new System.Timers.Timer();
        renderTimer.Interval = 500;
        renderTimer.Elapsed += (s, e) =>
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                InvalidateVisual();
            });
        };
        renderTimer.Start();
    }

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

        resultRenderer.IsVisible = true;
        resultRenderer.Render(context);
    }

    protected override Size MeasureCore(Size availableSize)
    {
        Width = Math.Max(availableSize.Width, MinWidth) - Margin.Left - Margin.Right;

        return base.MeasureCore(availableSize);
    }
}