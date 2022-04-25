namespace MAUI_Demo_01.Shared.Models;

public class CurrencyCodeModel
{
    public List<List<string>> supported_codes { get; set; }
}

public class CurrencyRateModel
{
    public Dictionary<string, double> conversion_rates { get; set; }
}

public class CurrencyResponseModel
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string NativeName { get; set; }
    public string Flag { get; set; }
}

public class CurrenyRateResponseModel
{
    public string Code { get; set; }
    public double Rate { get; set; }
}

public class CurrencyDataModel
{
    public List<CurrencyResponseModel> Currencies { get; set; }
    public List<CurrenyRateResponseModel> Rates { get; set; }
}

public class CurrencyConvertRequestModel
{
    public string Source { get; set; }

    public string Target { get; set; }

    public double Amount { get; set; }
}