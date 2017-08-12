using JetBrains.Annotations;

namespace Common
{
  public static class StringExtensions
  {
    [Pure]
    [CanBeNull]
    [ContractAnnotation("null=>null")]
    public static string ToPascalCase([CanBeNull] this string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        return value;
      }

      return value[0].ToString().ToUpper() + value.Substring(1);
    }
  }
}
