namespace MAUI_Demo_01.ViewModels;

public partial class ShellViewModel : BaseViewModel
{
    [ICommand]
    private async Task GoToOfficial()
    {
        await Browser.OpenAsync("https://dot.net/maui");
    }

    [ICommand]
    private async Task GoToHome()
    {
        await Shell.Current.GoToAsync($"//Home");
    }
}