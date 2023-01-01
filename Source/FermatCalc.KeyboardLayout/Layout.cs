using Portable.Xaml;
using Portable.Xaml.Markup;
using System.IO;

[assembly: XmlnsDefinition("http://schemas.furesoft.org/FermatCalc", "FermatCalc.KeyboardLayout")]

namespace FermatCalc.KeyboardLayout;

[ContentProperty("Pages")]
public class Layout
{
    private LayoutPageCollection pages = new();

    public LayoutPageCollection Pages
    {
        get { return pages; }
        set { this.RaiseAndSetIfChanged(ref pages, value); }
    }

    public string? Name { get; set; }

    public static Layout Parse(string src)
    {
        return (Layout)XamlServices.Parse(src);
    }

    public static Layout Load(string path)
    {
        return Parse(File.ReadAllText(path));
    }

    public void Save(string path)
    {
        var serialized = XamlServices.Save(this);

        File.WriteAllText(path, serialized);
    }
}