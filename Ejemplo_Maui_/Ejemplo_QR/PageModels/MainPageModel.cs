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

    public MainPageModel(ILogger<MainPageModel> logger)
    {
        _logger = logger;
    }

    public ICommand AppearingCommand => new Command(OnAppearing);
   public ICommand DetectedCommand => new Command<OnDetectedEventArg>(OnDetected);

    public ICommand TorchButtonCommand => new Command<EventArgs>(OnTorchButton);

    void OnAppearing()
    {
#if ANDROID
        BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode | BarcodeScanner.Mobile.BarcodeFormats.Code39);
        BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
#endif
    }

    [RelayCommand]
    private void OnDetected(BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        List<BarcodeResult> obj = e.BarcodeResults;

        string result = string.Empty;
        for (int i = 0; i < obj.Count; i++)
        {
            result += $"Type : {obj[i].BarcodeType}, Value : {obj[i].DisplayValue}{Environment.NewLine} ";
        }


        ScannedText = result;

          
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

    void OnTorchButton(EventArgs e)
    {
        Camera.TorchOn = Camera.TorchOn == false;
    }

}
