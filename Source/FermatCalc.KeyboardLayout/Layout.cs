using Portable.Xaml;
using Portable.Xaml.Markup;
using ReactiveUI;
using System.IO;
using System.Runtime.InteropServices;

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
    public string Platform { get; set; }

    public static Layout NewEmptyKeyboard(int buttonsPerPage, int pageCount = 1)
    {
        var layout = new Layout();

        int id = 0;
        for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
        {
            var page = new LayoutPage();

            for (int i = 0; i < buttonsPerPage; i++)
            {
                var btn = new LayoutButton();
                btn.ID = id++;

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
        if (string.IsNullOrEmpty(Platform))
        {
            var architectur = RuntimeInformation.OSArchitecture.ToString();
            Platform = RuntimeInformation.RuntimeIdentifier[..^(architectur.Length + 1)];
        }

        var serialized = XamlServices.Save(this);

        File.WriteAllText(path, serialized);
    }

    public void SaveTidy(string path)
    {
        var layout = new Layout();

        foreach (var page in Pages)
        {
            var p = new LayoutPage();

            foreach (var btn in page)
            {
                if (!string.IsNullOrEmpty(btn.Display))
                {
                    p.Add(btn);
                }
            }

            layout.Pages.Add(p);
        }

        layout.Save(path);
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