namespace MAUI_Demo_01.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly IKeyboardService _keyboardService;

    public RegisterViewModel(IKeyboardService keyboardService)
    {
        _keyboardService = keyboardService;
    }

    [ICommand]
    private async Task Back()
    {
        _keyboardService?.HideKeyboard();

        await Shell.Current.GoToAsync($"//{nameof(Pages.Login)}");
    }

    [ICommand]
    private async Task Submit()
    {
        _keyboardService?.HideKeyboard();

        await Shell.Current.GoToAsync($"//{nameof(Pages.Login)}");

        await Shell.Current.DisplayAlert("Success", "Your account has been registered", "Ok");
    }
}