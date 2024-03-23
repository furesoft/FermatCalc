using FermatCalc.Controls;

namespace FermatCalc.ActionItems;

public class ClearActionItem : DefaultActionItem
{
    public ClearActionItem()
    {
        Display = "AC";
    }

    public override void Invoke()
    {
        CalculationEngine.ClearBuffer();
        IOC.Resolve<Display>().Result = "";
    }
}