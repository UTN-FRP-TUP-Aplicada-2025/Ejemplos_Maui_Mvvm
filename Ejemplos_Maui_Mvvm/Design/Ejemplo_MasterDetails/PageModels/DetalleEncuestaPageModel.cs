
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejemplo_MasterDetails.Services;

namespace Ejemplo_MasterDetails.PageModels;

public partial class DetalleEncuestaPageModel : ObservableObject
{
    [ObservableProperty]
    public string nombre = string.Empty;

    [ObservableProperty]
    public DateTime fechaNacimiento = DateTime.MinValue;

    [RelayCommand]
    private async Task Help(string url)
    {
        try
        {
            if (!string.IsNullOrEmpty(url))
            {
                await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
            }
        }
        catch (Exception ex)
        {
            await Toast.Make($"Error: {ex.Message}", ToastDuration.Long).Show();
        }
    }

    [RelayCommand]
    private async Task GoBack(object? obj)
    {
        await Shell.Current.Navigation.PopAsync();
    }
}
