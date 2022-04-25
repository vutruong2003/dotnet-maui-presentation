namespace MAUI_Demo_01;

public partial class AppShell : Shell
{
    private readonly IAuthService _authService;

    public AppShell(IAuthService authService)
    {
        InitializeComponent();

        _authService = authService;
    }

    protected override async void OnAppearing()
    {
        var claims = await _authService.GetClaims();
        if (string.IsNullOrEmpty(claims?.Id) == false)
        {
            await GoToAsync($"//Home");
        }
        else
        {
            if (GlobalConfig.IsAppIntroduced)
            {
                CurrentItem = loginTab;
            }
            else
            {
                CurrentItem = introduceTab;
            }
        }

        base.OnAppearing();
    }
}