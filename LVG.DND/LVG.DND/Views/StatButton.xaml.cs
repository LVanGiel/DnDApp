namespace LVG.DND.Views;

public partial class StatButton : ContentView
{
    public static readonly BindableProperty ButtonTitleProperty = BindableProperty.Create(nameof(ButtonTitle), typeof(string), typeof(StatButton), string.Empty);
    public static readonly BindableProperty ButtonStatProperty = BindableProperty.Create(nameof(ButtonStat), typeof(string), typeof(StatButton), string.Empty);
    public static readonly BindableProperty ButtonImageUrlProperty = BindableProperty.Create(nameof(ButtonImageUrl), typeof(string), typeof(StatButton), string.Empty);
    public static readonly BindableProperty ButtonClickedProperty = BindableProperty.Create(nameof(ButtonClicked), typeof(EventHandler), typeof(StatButton), null );
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

    public EventHandler ButtonClicked
    {
        get => (EventHandler)GetValue(StatButton.ButtonClickedProperty);
        set{
            SetValue(StatButton.ButtonClickedProperty, value);
            UpdateClick();
        } 
    }

    public StatButton()
	{
		InitializeComponent();
    }
    private void UpdateClick()
    {
        ThisClicked.Clicked += ButtonClicked;
    }
}