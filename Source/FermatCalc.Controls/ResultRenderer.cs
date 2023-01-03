using Avalonia;
using Avalonia.Media;

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
            var equalsText = new FormattedText();
            equalsText.Text = "=";
            equalsText.FontSize = 30;
            equalsText.Typeface = Typeface.Default;

            context.DrawText(Brushes.Black, new Point(10, display.Bounds.Height - equalsText.Bounds.Height - 10), equalsText);

            var resultText = new FormattedText();

            resultText.Text = "42";
            resultText.FontSize = 30;
            resultText.Typeface = Typeface.Default;

            context.DrawText(Brushes.Black, new Point(display.Bounds.Width - resultText.Bounds.Width - 10, display.Bounds.Height - resultText.Bounds.Height - 10), resultText);
        }
    }
}