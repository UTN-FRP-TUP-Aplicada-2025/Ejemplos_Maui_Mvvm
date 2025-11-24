using BarcodeScanner.Mobile;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace Ejemplo_QR_BarcodeScanner.PageModels;

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

#if ANDROID
        try
        {
            RequestCameraPermission();
            
            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
            BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode |BarcodeScanner.Mobile.BarcodeFormats.Code39);            
            _logger.LogInformation("Barcode scanner initialized");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error initializing barcode scanner");
        }
#elif IOS            
        // Solicitar permisos para iOS
        BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode | BarcodeScanner.Mobile.BarcodeFormats.Code39);
#endif
    }

#if ANDROID
    private async void RequestCameraPermission()
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
                _logger.LogInformation("Camera permission: {status}", status);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error requesting camera permission");
        }
    }
#endif

    //public ICommand AppearingCommand => new Command(OnAppearing);
    //public ICommand TorchButtonCommand => new Command(OnTorchButton);

    [RelayCommand]
    private void Appearing()
    {
        _logger.LogInformation("Appearing command triggered");    
    }

    public ICommand OnDetectedCommand => new Command<BarcodeScanner.Mobile.OnDetectedEventArg>(OnDetectedHandler);

    private async void OnDetectedHandler(BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        try
        {
            List<BarcodeResult> barCodes = e.BarcodeResults;

            if (barCodes == null || barCodes.Count == 0) return;
            
            var firstBarcode = barCodes[0].DisplayValue;

            if (string.IsNullOrEmpty(firstBarcode))
                return;

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                ScannedText = firstBarcode;
                _logger.LogInformation("Barcode detected: {ScannedText}", ScannedText);
            });                       
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
