namespace MAUI_Demo_01.Pages;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        settingBox.IsVisible = !GlobalConfig.Desktop;

        base.OnAppearing();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";

        SemanticScreenReader.Announce(CounterLabel.Text);
    }

    private async void OnSettingClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(Pages.Setting)}");
    }
}