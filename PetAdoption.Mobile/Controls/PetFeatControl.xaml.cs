namespace PetAdoption.Mobile.Controls;

public partial class PetFeatControl : ContentView
{
	public PetFeatControl()
	{
		InitializeComponent();
	}
    // BindableProperty for Icon
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(string), typeof(PetFeatControl), string.Empty);

    // BindableProperty for Lable
    public static readonly BindableProperty LableProperty =
        BindableProperty.Create(nameof(Lable), typeof(string), typeof(PetFeatControl), string.Empty);

    // BindableProperty for Value
    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(string), typeof(PetFeatControl), string.Empty);

    // Property for Icon
    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    // Property for Lable
    public string Lable
    {
        get => (string)GetValue(LableProperty);
        set => SetValue(LableProperty, value);
    }

    // Property for Value
    public string Value
    {
        get => (string)GetValue(ValueProperty); // Sử dụng đúng ValueProperty
        set => SetValue(ValueProperty, value);  // Sử dụng đúng ValueProperty
    }
}