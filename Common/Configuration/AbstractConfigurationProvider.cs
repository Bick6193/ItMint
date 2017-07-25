using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CreditorGuard.Common.Configuration
{
    public abstract class AbstractConfigurationProvider
    {
        protected static readonly string DefaultTimeZone = "Eastern Standard Time";
    }
}