namespace MAUI_Demo_01.Pages;

public partial class Document : ContentPage
{
	public Document()
	{
		InitializeComponent();
	}

    private async void OnClicked(object sender, EventArgs e)
    {
        var result = await PickAndShow(PickOptions.Images);
    }

	private async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.PickAsync(options);
            if (result != null)
            {
                text.Text = $"File Name: {result.FileName}";
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    // var stream = await result.OpenReadAsync();
                    image.Source = ImageSource.FromFile(result.FullPath);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
}