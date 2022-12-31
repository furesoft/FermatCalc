using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace FermatCalc.Controls;

public class Display : Control
{
    public override void Render(DrawingContext context)
    {
        context.DrawRectangle(Brushes.Red, new Pen(Brushes.Black), new(0, 0, Width, Height), 5, 5);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        Width = availableSize.Width;
        Height = availableSize.Height;

        return base.MeasureOverride(availableSize);
    }
}