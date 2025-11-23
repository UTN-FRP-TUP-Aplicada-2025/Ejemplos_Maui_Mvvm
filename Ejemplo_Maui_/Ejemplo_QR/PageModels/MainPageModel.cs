using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using BarcodeScanner.Mobile;

namespace Ejemplo_QR.PageModels;

public partial class MainPageModel : ObservableObject
{
    ILogger<MainPageModel> _logger = default!;

    [ObservableProperty]
    private string scannedText = string.Empty;

    [ObservableProperty]
    private bool isScanning = false;

    [ObservableProperty]
    private bool torchEnabled = false;

    public MainPageModel(ILogger<MainPageModel> logger)
    {
        _logger = logger;

#if ANDROID
        try
        {
            BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode | BarcodeScanner.Mobile.BarcodeFormats.Code39);
            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error initializing barcode scanner");
        }
#endif
    }

    public ICommand AppearingCommand => new Command(OnAppearing);
 //   public ICommand DetectedCommand => new Command<OnDetectedEventArg>(OnDetected);

    public ICommand TorchButtonCommand => new Command(OnTorchButton);

    void OnAppearing()
    {

    }

    [RelayCommand]
    private void OnDetected(BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        try
        {
            List<BarcodeResult> obj = e.BarcodeResults;

            string result = string.Empty;
            for (int i = 0; i < obj.Count; i++)
            {
                result += $"Type : {obj[i].BarcodeType}, Value : {obj[i].DisplayValue}{Environment.NewLine} ";
            }


            ScannedText = result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error detecting barcode");
        }

    }

    [RelayCommand]
    private void BarcodeDetected(BarcodeResult result)
    {
    }

    [RelayCommand]
    private void Clear()
    {
        ScannedText = string.Empty;
    }

    void OnTorchButton()
    {
        try
        {
            //Camera.TorchOn = Camera.TorchOn == false;
            TorchEnabled = !TorchEnabled;
            //BarcodeScanner.Mobile.tor SetTorchOn(TorchEnabled);
            //CameraView.TorchOn = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling torch");
        }
    }

}
