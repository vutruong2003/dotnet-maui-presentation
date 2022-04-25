using Microsoft.Maui.Platform;

namespace MAUI_Demo_01;

public partial class App : Application
{
    private readonly IAuthService _authService;

    public App(IAuthService authService, AppShell shell, DesktopShell dShell)
    {
        InitializeComponent();

        _authService = authService;

        if (GlobalConfig.Desktop)
        {
            MainPage = dShell;
        }
        else
        {
            MainPage = shell;
        }
    }

    private void InitRenders()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Renderers.BorderLessEntryWithDoneButton), (handler, view) =>
        {
            if (view is Renderers.BorderLessEntryWithDoneButton)
            {
#if ANDROID
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());       
#elif IOS
                handler.PlatformView.BackgroundColor = Colors.Transparent.ToPlatform();
                handler.PlatformView.Layer.BackgroundColor = Colors.Transparent.ToCGColor();
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
 
 
                var toolbar = new UIKit.UIToolbar(new System.Drawing.RectangleF(0.0f, 0.0f, 50.0f, 44.0f));
                toolbar.BackgroundColor = UIKit.UIColor.LightGray;
 
                var doneButton = new UIKit.UIBarButtonItem(UIKit.UIBarButtonSystemItem.Done,delegate
                {
                    handler.PlatformView.ResignFirstResponder();
                });
 
                toolbar.Items = new UIKit.UIBarButtonItem[]{
                    new UIKit.UIBarButtonItem(UIKit.UIBarButtonSystemItem.FlexibleSpace),doneButton
                };
 
                handler.PlatformView.InputAccessoryView = toolbar;
#endif
            }
        });
    }
}
