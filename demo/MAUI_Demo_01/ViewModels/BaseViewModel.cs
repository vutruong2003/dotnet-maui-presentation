namespace MAUI_Demo_01.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    protected bool isBusy;

    [ObservableProperty]
    protected bool title;

    public BaseViewModel()
    {
        isBusy = false;
    }

    public async void OnAppearing() { await OnModelAppearing(); }

    public async void OnDisappearing() { await OnModelDisappearing(); }

    public Task OnAppearingAsync() { return OnModelAppearing(); }

    public Task OnDisappearingAsync() { return OnModelAppearing(); }

    protected virtual Task OnModelAppearing()
    {
        return Task.CompletedTask;
    }

    protected virtual Task OnModelDisappearing()
    {
        return Task.CompletedTask;
    }
}