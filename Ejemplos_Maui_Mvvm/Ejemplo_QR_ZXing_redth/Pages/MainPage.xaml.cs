using System.Net.NetworkInformation;

namespace Ejemplo_QR_ZXing_redth.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;

        barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate=true,
            Multiple=true,
            TryInverted=true
        };  
    }

    private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        var first = e.Results?.FirstOrDefault();
        if (first is null) return;

        Dispatcher.Dispatch(() =>
        {
            var model = BindingContext as MainPageModel;
            model.OnDetectedHandler(e);
        });
    }

}
