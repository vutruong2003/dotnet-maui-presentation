namespace MAUI_Demo_01.Shared.Models;

public class CountryModel
{
    public string Id { get; set; }
    public string Name { get; set; }

    public string Subregion { get; set; }
    public string Region { get; set; }
    public int Population { get; set; }

    public List<double> latlng { get; set; }

    public double Area { get; set; }

    public string Flag { get; set; }

    public string NativeName { get; set; }
    public string NumericCode { get; set; }
    public List<string> Timezones { get; set; }

    public List<string> CallingCodes { get; set; }

    public string Alpha2Code { get; set; }
    public string Alpha3Code { get; set; }

    public List<CountryCurrencyModel> Currencies { get; set; }

    public CountryFlagModel Flags { get; set; }
}

public class CountryCurrencyModel
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Symbol { get; set; }
}

public class CountryFlagModel
{
    public string svg { get; set; }
    public string png { get; set; }
}