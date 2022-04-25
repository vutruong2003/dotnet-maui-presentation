using MAUI_Demo_01.Pages;

namespace MAUI_Demo_01.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private UserSignInModel _model;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    private const string _validEmail = "vu@gmail.com";

    public LoginViewModel()
    {
        _model = new UserSignInModel();
    }

    [ICommand]
    private async Task GotoRegister()
    {
        await Shell.Current.GoToAsync($"//{nameof(Register)}");
    }

    [ICommand]
    private async Task GotoForgotPassword()
    {
        await Shell.Current.GoToAsync($"//{nameof(ForgotPassword)}");
    }

    [ICommand]
    private async Task Login()
    {
        if (_email != _validEmail)
        {
            await Shell.Current.DisplayAlert("Failed", "Wrong email or password. Please try again!", "Ok");
            return;
        }

        // fake token
        GlobalConfig.AppToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImYwNTk2ZGQ4LTkzNjUtNDBlNi05NmVhLTg0N2FmN2FiNTU3ZSIsImVtYWlsIjoidHJ1b25ncGh1b2N2dTIwMDNAZ21haWwuY29tIiwibmFtZSI6IlZ1IFRydW9uZyIsImdpdmVuX25hbWUiOiJWdSIsImZhbWlseV9uYW1lIjoiVHJ1b25nIiwibmJmIjoxNjQ5ODM2MjEyLCJleHAiOjE2NTA3MDAyMTIsImlhdCI6MTY0OTgzNjIxMiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIxMSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcyMTEifQ.8toPoPScHfALZexHRPKenEMdb4rMDjXTh62AV2G8mUM";

        await Shell.Current.GoToAsync($"//Home");
    }
}