using Avalonia.Controls;
using FermatCalc.Commands;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FermatCalc.ViewModels;

public class MainViewModel : ViewModelBase
{
    private int _selectedPage;

    public MainViewModel()
    {
        BackCommand = new BackCommand(this);
        ForwardCommand = new ForwardCommand(this);

        Pages.Add(new TextBlock { Text = "Page 1" });
        Pages.Add(new TextBlock { Text = "Page 2" });
        Pages.Add(new TextBlock { Text = "Page 3" });
    }

    public ObservableCollection<object> Pages { get; set; } = new();

    public int SelectedPage
    {
        get { return _selectedPage; }
        set { this.RaiseAndSetIfChanged(ref _selectedPage, value); }
    }

    public ICommand BackCommand { get; set; }
    public ICommand ForwardCommand { get; set; }
}