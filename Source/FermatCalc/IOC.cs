using DryIoc;

namespace FermatCalc;

public class IOC
{
    public static Container Current = new();

    public static T Resolve<T>()
    {
        return Current.Resolve<T>();
    }
}