using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Common;
using Newtonsoft.Json;

namespace Web.Identity
{
  public class ChallangeModel
  {

    [Required]
    [JsonProperty(PropertyName = "grant_type")]
    public string GrantType { get;  set; }

    [JsonProperty(PropertyName = "refresh_token")]
    public string RefreshToken { get;  set; }

    [Required]
    [JsonProperty(PropertyName = "client_id")]
    public string ClientId { get;  set; }

    public string ClientSecret { get;  set; }

    [JsonProperty(PropertyName = "username")]
    public string UserName { get;  set; }

    public string Password { get;  set; }

    public static ChallangeModel FronRequest(HttpRequest request)
    {
      try
      {
        return request.ReadJson<ChallangeModel>();
      }
      catch (Exception e)
      {
        Log.Logger().Error(e, "Exception while parsing Challange Model");

        return new ChallangeModel();
      }
    }
  }
}
