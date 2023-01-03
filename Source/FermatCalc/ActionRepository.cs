using System.Collections.Generic;

namespace FermatCalc;

public static class ActionRepository
{
    public static readonly Dictionary<string, ActionItem> Actions = new();

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

    public void Invoke()
    {
    }
}