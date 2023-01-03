using Avalonia;
using Avalonia.Media;
using FermatCalc.Controls;
using System.Timers;
using Timer = System.Timers.Timer;

namespace FermatCalc;

public class Cursor
{
    public readonly int Height = 40;
    private readonly Timer timer;

    public Cursor()
    {
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }

    public Display Display { get; set; }

    public bool IsVisible { get; set; } = true;
    public Point Position { get; set; }

    public void Render(DrawingContext context)
    {
        if (!IsVisible)
        {
            return;
        }

        context.DrawLine(new Pen(Brushes.Black), new(Position.X, Position.Y), new Point(Position.X, Position.Y + Height));
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        IsVisible = !IsVisible;
    }
}