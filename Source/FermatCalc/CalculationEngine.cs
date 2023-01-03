using NiL.JS.BaseLibrary;
using NiL.JS.Core;
using System.Text;

namespace FermatCalc;

public static class CalculationEngine
{
    public static string Result;
    private static StringBuilder buffer = new();
    private static Context context = new();

    static CalculationEngine()
    {
        context.DefineConstructor(typeof(Math));
    }

    public static void AppendToBuffer(string text)
    {
        buffer.Append(text);
    }

    public static void Evaluate()
    {
        Result = context.Eval(buffer.ToString()).ToString();
        buffer = new();
    }
}