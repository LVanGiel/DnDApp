

namespace LVG.DND.Pages;

public partial class testpage : ContentPage
{
	List<string> strings = new List<string>();
	public testpage()
	{
		InitializeComponent();
		for (int i = 0; i < 5; i++)
		{
			strings.Add(i.ToString());
		}

    }
}