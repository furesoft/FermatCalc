using Portable.Xaml;
using Portable.Xaml.Markup;
using ReactiveUI;
using System.IO;

[assembly: XmlnsDefinition("http://schemas.furesoft.org/FermatCalc", "FermatCalc.KeyboardLayout")]

namespace FermatCalc.KeyboardLayout;

[ContentProperty("Pages")]
public class Layout : ReactiveObject
{
    private LayoutPageCollection pages = new();

    public LayoutPageCollection Pages
    {
        get { return pages; }
        set { this.RaiseAndSetIfChanged(ref pages, value); }
    }

    public string? Name { get; set; }

    public static Layout NewEmptyKeyboard(int buttonsPerPage, int pageCount = 1)
    {
        var layout = new Layout();

        for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
        {
            var page = new LayoutPage();

            for (int i = 0; i < buttonsPerPage; i++)
            {
                var btn = new LayoutButton();
                btn.ID = i;

                page.Add(btn);
            }

            layout.Pages.Add(page);
        }

        return layout;
    }

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

    public void ApplyLayoutFrom(Layout layout)
    {
        for (int i = 0; i < layout.Pages.Count; i++)
        {
            var page = layout.Pages[i];

            foreach (var btn in page)
            {
                Pages[i][btn.ID].Display = btn.Display;
            }
        }
    }
}