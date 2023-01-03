using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using SkiaSharp;

namespace FermatCalc.Controls;

public class Display : Control
{
    public static StyledProperty<IBrush> BackgroundProperty = AvaloniaProperty.Register<Display, IBrush>(nameof(Background), Brushes.Beige);
    private readonly Cursor cursor;
    private readonly ResultRenderer resultRenderer;

    private bool rendered = false;

    public Display()
    {
        cursor = new(this);
        cursor.Position = new(10, 10);
        cursor.Position += new Point(140 + 10, 0);

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

        RenderInput(context);
        cursor.Render(context);

        resultRenderer.IsVisible = true;
        resultRenderer.Render(context);
    }

    protected override Size MeasureCore(Size availableSize)
    {
        Width = Math.Max(availableSize.Width, MinWidth) - Margin.Left - Margin.Right;

        return base.MeasureCore(availableSize);
    }

    private void RenderInput(DrawingContext context)
    {
        var painter = new CSharpMath.SkiaSharp.MathPainter();
        painter.LaTeX = @"\lfloor(log(420))\rfloor+1";
        painter.TextColor = SKColors.Black;
        painter.AntiAlias = true;
        painter.FontSize = 30;
        //painter.Magnification = 0.4f;

        var latexMeasured = painter.Measure();

        var renderTarget = new WriteableBitmap(new PixelSize((int)latexMeasured.Width + 10, (int)latexMeasured.Height + 10), new Vector(128, 128));

        using var framebuffer = renderTarget.Lock();

        var info = new SKImageInfo(framebuffer.Size.Width, framebuffer.Size.Height);
        using var surface = SKSurface.Create(info, framebuffer.Address, framebuffer.RowBytes);

        var canvas = surface.Canvas;

        painter.Draw(canvas);

        context.DrawImage(renderTarget, new Rect(0, 0, info.Width, info.Height), new Rect(10, 10, info.Width, info.Height), BitmapInterpolationMode.HighQuality);
    }
}