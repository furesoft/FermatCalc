using AuroraModularis.Core;
using FermatCalc.Controls;
using NiL.JS.BaseLibrary;
using NiL.JS.Core;

namespace FermatCalc;

public static class CalculationEngine
{
    public static string Result;
    private static Context context = new();

    static CalculationEngine()
    {
        context.DefineConstructor(typeof(Math));
    }

    public static void AppendToBuffer(string text)
    {
        Container.Current.Resolve<Display>().Input += text;
    }

    public static void Evaluate()
    {
        Result = context.Eval(Container.Current.Resolve<Display>().Input).ToString();
    }

    public static void ClearBuffer()
    {
        Container.Current.Resolve<Display>().Input = "";
        Container.Current.Resolve<Cursor>().Position = new(10, 10);
    }
}