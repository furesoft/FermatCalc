using System.Drawing;
using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using CSharpMath.SkiaSharp;
using DryIoc;
using SkiaSharp;
using Point = Avalonia.Point;
using Registrator = DryIoc.Registrator;
using Size = Avalonia.Size;

namespace FermatCalc.Controls;

public class Display : Control
{
    public static StyledProperty<IBrush> BackgroundProperty =
        AvaloniaProperty.Register<Display, IBrush>(nameof(Background), Brushes.Beige);

    private readonly Cursor cursor;
    private readonly ResultRenderer resultRenderer;

    public Display()
    {
        cursor = new(this);
        cursor.Position = new(10, 10);
        cursor.Position += new Point(140 + 10, 0);

        resultRenderer = new(this);

        Timer renderTimer = new();
        renderTimer.Interval = 500;
        renderTimer.Elapsed += (s, e) => { Dispatcher.UIThread.InvokeAsync(() => { InvalidateVisual(); }); };
        renderTimer.Start();

        IOC.Current.RegisterInstance(this);
        IOC.Current.RegisterInstance(Cursor);
    }

    public string Result
    {
        get => resultRenderer.Result;
        set
        {
            resultRenderer.Result = value;
            resultRenderer.IsVisible = !string.IsNullOrEmpty(value);
        }
    }

    public string Input { get; set; }

    public IBrush Background
    {
        get => GetValue(BackgroundProperty);
        set => SetValue(BackgroundProperty, value);
    }

    public override void Render(DrawingContext context)
    {
        context.DrawRectangle(Background, new Pen(Brushes.Black), new(0, 0, Width, Height), 5, 5);

        RenderInput(context);
        cursor.Render(context);

        resultRenderer.Render(context);
    }

    protected override Size MeasureCore(Size availableSize)
    {
        Width = System.Math.Max(availableSize.Width, MinWidth) - Margin.Left - Margin.Right;

        return base.MeasureCore(availableSize);
    }

    private void RenderInput(DrawingContext context)
    {
        MathPainter painter = new();
        painter.LaTeX = Input;
        painter.TextColor = SKColors.Black;
        painter.AntiAlias = true;
        painter.FontSize = 30;
        //painter.Magnification = 0.4f;

        RectangleF latexMeasured = painter.Measure();

        WriteableBitmap renderTarget =
            new(new((int) latexMeasured.Width + 10, (int) latexMeasured.Height + 10), new(128, 128));

        using ILockedFramebuffer framebuffer = renderTarget.Lock();

        SKImageInfo info = new(framebuffer.Size.Width, framebuffer.Size.Height);
        using SKSurface? surface = SKSurface.Create(info, framebuffer.Address, framebuffer.RowBytes);

        SKCanvas? canvas = surface.Canvas;

        painter.Draw(canvas);

        context.DrawImage(renderTarget, new Rect(0, 0, info.Width, info.Height),
            new Rect(10, 10, info.Width, info.Height));
    }
}