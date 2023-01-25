using FermatCalc.ActionItems;
using System.Collections.Generic;

namespace FermatCalc;

public static class ActionRepository
{
    public static readonly Dictionary<string, DefaultActionItem> Actions = new();

    static ActionRepository()
    {
        Actions.Add("=", new ResultActionItem());
        Actions.Add("ac", new ClearActionItem());
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