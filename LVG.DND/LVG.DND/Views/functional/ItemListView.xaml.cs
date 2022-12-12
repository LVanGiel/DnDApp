namespace LVG.DND.Views.functional;

public partial class ItemListView : ContentView
{
	public List<object> ItemList { get; set; }
    public List<object> SelectedItemList { get; set; }
    public ItemListView()
	{
		InitializeComponent();
	}
    public ItemListView(List<object> itemList)
    {
        InitializeComponent();
        ItemList = itemList;
    }
    void Init()
	{
        FillItemStack();

    }
    private void FillItemStack()
    {
        foreach (var item in ItemList)
        {
            var itemButton = new Button();
            itemButton.Text = item.ToString();
            itemButton.Clicked += btnSelection_Clicked;
        }
    }
    private void btnSelection_Clicked(object sender, EventArgs e)
    {
        var selectedButton = sender as Button;
        IsEnableButtons(true);
        if (SelectedItemList.Count == 3)
        {
            SelectedItemList.RemoveAt(0);
        }

        SelectedItemList.Add(selectedButton.Text);

        IsEnableButtons(false);
    }
    private void IsEnableButtons(bool isEnabled)
    {
        foreach (var button in ItemListStack.Children)
        {
            (button as Button).IsEnabled = isEnabled;
        }
    }
}