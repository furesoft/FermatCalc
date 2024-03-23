using DryIoc;
using FermatCalc.Controls;
using NiL.JS.BaseLibrary;
using NiL.JS.Core;

namespace FermatCalc;

public static class CalculationEngine
{
    public static string Result;
    private static readonly Context context = new();

    static CalculationEngine()
    {
        context.DefineConstructor(typeof(Math));
    }

    public static void AppendToBuffer(string text)
    {
        IOC.Current.Resolve<Display>().Input += text;
    }

    public static void Evaluate()
    {
        Result = context.Eval(IOC.Current.Resolve<Display>().Input).ToString();
    }

    public static void ClearBuffer()
    {
        IOC.Current.Resolve<Display>().Input = "";
        IOC.Current.Resolve<Cursor>().Position = new(10, 10);
    }
}