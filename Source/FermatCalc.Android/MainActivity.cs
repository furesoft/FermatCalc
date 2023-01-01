using Android.App;
using Android.Content.PM;
using Avalonia.Android;
using Avalonia.Controls.ApplicationLifetimes;
using FermatCalc.ViewModels;

namespace FermatCalc.Android;

[Activity(Label = "FermatCalc.Android", Theme = "@style/MyTheme.NoActionBar", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
public class MainActivity : AvaloniaMainActivity
{
    public override void OnBackPressed()
    {
        if (Avalonia.Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime lifetime)
        {
            if (lifetime?.MainView?.DataContext is MainViewModel vm)
            {
                vm.SelectedPage--;
            }
        }
    }
}