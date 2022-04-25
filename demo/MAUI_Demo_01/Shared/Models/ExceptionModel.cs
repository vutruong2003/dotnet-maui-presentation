namespace MAUI_Demo_01.Shared.Models
{
    public class ExceptionModel
    {
        public string ExceptionMessage { get; set; }

        public string ExceptionType { get; set; }

        public string StackTrace { get; set; }

        public ExceptionModel? InnerException { get; set; }
    }
}