using System.Text.Json;

namespace MAUI_Demo_01.Shared.Helpers
{
    public class JsonHelper
    {
        private static JsonSerializerOptions _webJsonSerializerOption;

        public static JsonSerializerOptions GetWebJsonOptions()
        {
            if (_webJsonSerializerOption is null)
            {
                _webJsonSerializerOption = new JsonSerializerOptions(JsonSerializerDefaults.Web) { PropertyNameCaseInsensitive = false };
            }

            return _webJsonSerializerOption;
        }
    }
}