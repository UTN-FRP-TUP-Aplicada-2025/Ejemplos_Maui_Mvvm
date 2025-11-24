using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace Ejemplo_QR_ZXing_redth.PageModels;

public partial class MainPageModel : ObservableObject
{
    ILogger<MainPageModel> _logger = default!;

    [ObservableProperty]
    private string scannedText = string.Empty;

    [ObservableProperty]
    private bool isScanning = true;

    [ObservableProperty]
    private bool torchEnabled = false;

    public MainPageModel(ILogger<MainPageModel> logger)
    {
        _logger = logger;
    }

    [RelayCommand]
    private void Appearing()
    {
        _logger.LogInformation("Appearing command triggered");    
    }

    //public ICommand OnDetectedCommand => new Command<ZXing.Net.Maui.BarcodeDetectionEventArgs>(OnDetectedHandler);

    public async void OnDetectedHandler(ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        try
        {
            var first = e.Results?.FirstOrDefault();

            if (first is null) return;
            
            ScannedText = first.Value;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error en OnDetected: {ex.Message}");
        }

    }

    [RelayCommand]
    private void Clear()
    {
        ScannedText = string.Empty;
        IsScanning = true;
        _logger.LogInformation("Cleared scan data");
    }


    [RelayCommand]
    private void TorchButton()
    {
        try
        {
            TorchEnabled = !TorchEnabled;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling torch");
        }
    }
}
