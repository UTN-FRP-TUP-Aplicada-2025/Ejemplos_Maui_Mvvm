namespace Ejemplo_Views.Pages.CustomViews;

public partial class CardView : ContentView
{
    public static readonly BindableProperty CardTitleProperty =
         BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardView), string.Empty);

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CardView), Colors.Gray);

    public static readonly BindableProperty CardDescriptionProperty =
        BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CardView), string.Empty);

    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(CardView), Colors.LightGray);

    //public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create( nameof(IconImageSource), typeof(string), typeof(CardView), string.Empty, propertyChanged: OnIconImageSourceChanged);
    public static readonly BindableProperty IconImageSourceProperty =  BindableProperty.Create(nameof(IconImageSource), typeof(string), typeof(CardView), null);

    public static readonly BindableProperty CardBackgroundColorProperty = BindableProperty.Create(nameof(CardBackgroundColor), typeof(Color), typeof(CardView), Colors.White);

    //// Propiedad interna para la ImageSource convertida
    //public static readonly BindableProperty ConvertedImageSourceProperty =
    //    BindableProperty.Create(nameof(ConvertedImageSource), typeof(ImageSource), typeof(CardView), null);

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public string CardDescription
    {
        get => (string)GetValue(CardDescriptionProperty);
        set => SetValue(CardDescriptionProperty, value);
    }

    public Color IconBackgroundColor
    {
        get => (Color)GetValue(IconBackgroundColorProperty);
        set => SetValue(IconBackgroundColorProperty, value);
    }

    public string IconImageSource
    {
        get => (string) GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }

    //public ImageSource ConvertedImageSource
    //{
    //    get => (ImageSource)GetValue(ConvertedImageSourceProperty);
    //    set => SetValue(ConvertedImageSourceProperty, value);
    //}

    public Color CardBackgroundColor
    {
        get => (Color)GetValue(CardBackgroundColorProperty);
        set => SetValue(CardBackgroundColorProperty, value);
    }

    public CardView()
    {
        InitializeComponent();
        this.BindingContext = this;
    }

    //private static void OnIconImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    //{
    //    if (bindable is CardView cardView && newValue is string imageFileName && !string.IsNullOrEmpty(imageFileName))
    //    {
    //        // Convertir el string a ImageSource
    //        cardView.ConvertedImageSource = ImageSource.FromFile(imageFileName);
    //    }
    //}
}

