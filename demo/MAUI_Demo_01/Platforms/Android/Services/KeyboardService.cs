using Android.Content;
using Android.Views.InputMethods;

namespace MAUI_Demo_01.Services.Platforms;

public partial class KeyboardService
{
    public partial void HideKeyboard()
    {

        var context = Android.App.Application.Context;
        var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;

        if (inputMethodManager != null)
        {
            var activity = Platform.CurrentActivity;

            var token = activity.CurrentFocus?.WindowToken;
            inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

            activity.Window.DecorView.ClearFocus();
        }
    }
}