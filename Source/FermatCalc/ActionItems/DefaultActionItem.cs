namespace FermatCalc.ActionItems;

public class DefaultActionItem
{
    public object Renderer { get; set; }
    public string Display { get; set; }
    public string Hint { get; set; }

    public virtual void Invoke()
    {
    }
}