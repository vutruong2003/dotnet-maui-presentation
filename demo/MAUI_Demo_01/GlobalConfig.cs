namespace MAUI_Demo_01;

public class GlobalConfig
{
    public static bool Desktop
    {
        get
        {
#if WINDOWS || MACCATALYST
            return true;
#else
            return false;
#endif
        }
    }

    const AppTheme theme = AppTheme.Light;

    public static AppTheme Theme
    {
        get => Enum.Parse<AppTheme>(Preferences.Get(nameof(Theme), Enum.GetName(theme)));
        set => Preferences.Set(nameof(Theme), value.ToString());
    }

    public static void SetTheme()
    {
        switch (Theme)
        {
            case AppTheme.Light:
                App.Current.UserAppTheme = AppTheme.Light;
                break;
            case AppTheme.Dark:
                App.Current.UserAppTheme = AppTheme.Dark;
                break;
            default:
                break;
        }

        MessagingCenter.Instance.Send(nameof(GlobalConfig), "ChangeWebTheme");
    }

    public static bool IsWifiOnlyEnabled
    {
        get => Preferences.Get(nameof(IsWifiOnlyEnabled), false);
        set => Preferences.Set(nameof(IsWifiOnlyEnabled), value);
    }

    public static bool IsAppIntroduced
    {
        get => Preferences.Get(nameof(IsAppIntroduced), false);
        set => Preferences.Set(nameof(IsAppIntroduced), value);
    }

    public static string AppToken
    {
        get => Preferences.Get(nameof(AppToken), "");
        set => Preferences.Set(nameof(AppToken), value);
    }
}