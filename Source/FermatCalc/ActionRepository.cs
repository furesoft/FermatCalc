using AuroraModularis.Core;
using FermatCalc.Controls;
using System.Collections.Generic;

namespace FermatCalc;

public static class ActionRepository
{
    public static readonly Dictionary<string, ActionItem> Actions = new();

    static ActionRepository()
    {
        Actions.Add("=", new ResultActionItem());
    }

    public static void Invoke(string actionID)
    {
        Actions[actionID].Invoke();
    }

    public static void Register(string actionID, string display, string hint, object renderer)
    {
        Actions.TryAdd(actionID, new() { Display = display, Renderer = renderer, Hint = hint });
    }
}

public class ActionItem
{
    public object Renderer { get; set; }
    public string Display { get; set; }
    public string Hint { get; set; }

    public virtual void Invoke()
    {
    }
}

public class ResultActionItem : ActionItem
{
    public ResultActionItem()
    {
        Display = "equals";
    }

    public override void Invoke()
    {
        CalculationEngine.AppendToBuffer("1+2");

        CalculationEngine.Evaluate();
        Container.Current.Resolve<Display>().Result = CalculationEngine.Result;
    }
}