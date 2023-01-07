using AuroraModularis.Core;
using FermatCalc.Controls;

namespace FermatCalc.ActionItems;

public class ResultActionItem : DefaultActionItem
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