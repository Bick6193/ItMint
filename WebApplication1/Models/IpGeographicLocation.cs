using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Web.Models
{
  public class IpGeographicLocation
  {
    [JsonProperty("ip")]
    public string IP { get; set; }

    [JsonProperty("country_code")]

    public string CountryCode { get; set; }

    [JsonProperty("country_name")]

    public string CountryName { get; set; }

    [JsonProperty("region_code")]

    public string RegionCode { get; set; }

    [JsonProperty("region_name")]

    public string RegionName { get; set; }

    [JsonProperty("city")]

    public string City { get; set; }

    [JsonProperty("zip_code")]

    public string ZipCode { get; set; }

    [JsonProperty("time_zone")]

    public string TimeZone { get; set; }

    [JsonProperty("latitude")]

    public float Latitude { get; set; }

    [JsonProperty("longitude")]

    public float Longitude { get; set; }

    [JsonProperty("metro_code")]

    public int MetroCode { get; set; }

    private IpGeographicLocation() { }

    public static async Task<IpGeographicLocation> QueryGeographicalLocationAsync(string ipAddress)
    {
      HttpClient client = new HttpClient();
      string result = await client.GetStringAsync("http://freegeoip.net/json/" + ipAddress);
      return JsonConvert.DeserializeObject<IpGeographicLocation>(result);
    }

    public static string GetQueryPhoneCode(string country)
    {
      using (StreamReader r = new StreamReader("phonesCode.json"))
      {
        string json = r.ReadToEnd();
        var items = JsonConvert.DeserializeObject<RootObject>(json);
        foreach (var item in items.countries)
        {
          if (item.name.Equals(country))
          {
            return item.code;
          }
        }
        return null;
      }
    }
  }

  public class Country
  {
    public string code { get; set; }
    public string name { get; set; }
  }
  public class RootObject
  {
    public List<Country> countries { get; set; }
  }
}
