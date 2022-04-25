namespace MAUI_Demo_01.Shared.Constants;

public class Routes
{
    public const string Auth = "auth";
    public const string User = "user";
    public const string Currency = "currency";

    public const string Get = "{id}";
    public const string Login = "login";
    public const string ResetPassword = "reset-password";
    public const string Sync = "sync";

    public const string Auth_Login = Auth + "/" + Login;
    public const string Auth_ResetPass = Auth + "/" + ResetPassword;
    
    public const string User_Get = User + "/" + Get;
    public const string Currency_Sync = Currency + "/" + Sync;

    public const string Ext_Currency_Rate = "{key}/latest/USD";
    public const string Ext_Currency_Code = "{key}/codes";
}