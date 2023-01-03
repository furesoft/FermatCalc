using Avalonia;
using Avalonia.Media;
using System.Globalization;

namespace FermatCalc.Controls;

public class ResultRenderer
{
    private readonly Display display;

    public ResultRenderer(Display display)
    {
        this.display = display;
    }

    public bool IsVisible { get; set; }

    public void Render(DrawingContext context)
    {
        if (IsVisible)
        {
            var equalsText = new FormattedText("=", CultureInfo.InvariantCulture, FlowDirection.LeftToRight, Typeface.Default, 30, Brushes.Black);
            context.DrawText(equalsText, new Point(10, display.Bounds.Height - equalsText.Height - 10));

            var resultText = new FormattedText("3", CultureInfo.InvariantCulture, FlowDirection.LeftToRight, Typeface.Default, 30, Brushes.Black);
            context.DrawText(resultText, new Point(display.Bounds.Width - resultText.Width - 10, display.Bounds.Height - resultText.Height - 10));
        }
    }
}