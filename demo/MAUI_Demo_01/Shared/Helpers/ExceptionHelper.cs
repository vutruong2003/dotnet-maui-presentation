namespace MAUI_Demo_01.Shared.Helpers;

public static class ExceptionHelper
{
    public static ExceptionModel ToExceptionModel(this Exception exception)
    {
        var result = new ExceptionModel();

        if (exception != null)
        {
            result.ExceptionMessage = exception.Message;
            result.ExceptionType = exception.GetType().Name;
            result.StackTrace = exception.StackTrace ?? "";
            result.InnerException = exception.InnerException?.ToExceptionModel();
        }

        return result;
    }

    public static ExceptionModel? ToExceptionModel(this string message)
    {
        ExceptionModel? result = null;
        if (string.IsNullOrEmpty(message))
        {
            return result;
        }

        try
        {
            result = JsonSerializer.Deserialize<ExceptionModel>(message, new JsonSerializerOptions(JsonSerializerDefaults.Web) { PropertyNameCaseInsensitive = false });

            return result;
        }
        catch { }

        return result;
    }
}