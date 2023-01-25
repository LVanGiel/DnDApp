namespace LVG.DND.Views;

public partial class StatButton : ContentView
{
    public static readonly BindableProperty ButtonTitleProperty = BindableProperty.Create(nameof(ButtonTitle), typeof(string), typeof(StatButton), string.Empty);
    public static readonly BindableProperty ButtonStatProperty = BindableProperty.Create(nameof(ButtonStat), typeof(string), typeof(StatButton), string.Empty);
    public static readonly BindableProperty ButtonImageUrlProperty = BindableProperty.Create(nameof(ButtonImageUrl), typeof(string), typeof(StatButton), string.Empty);
    public string ButtonTitle
    {
        get => (string)GetValue(StatButton.ButtonTitleProperty);
        set => SetValue(StatButton.ButtonTitleProperty, value);
    }

    public string ButtonStat
    {
        get => (string)GetValue(StatButton.ButtonStatProperty);
        set => SetValue(StatButton.ButtonStatProperty, value);
    }
    public string ButtonImageUrl
    {
        get => (string)GetValue(StatButton.ButtonImageUrlProperty);
        set => SetValue(StatButton.ButtonImageUrlProperty, value);
    }

    public StatButton()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}