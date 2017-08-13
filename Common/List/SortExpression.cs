using JetBrains.Annotations;

namespace Common.List
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SortExpression
    {
        public string Column { get; set; }

        public  ListSortDirection Direction { get; set; }

        public string Key => $"{Column}_{(Direction == ListSortDirection.Ascending ? "ASC" : "DESC")}";
    }

    public enum ListSortDirection
    {
      Ascending,
      Descending
    }
}