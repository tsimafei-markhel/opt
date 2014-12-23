using System;
using opt.DataModel;

// TODO: Add XML comments

namespace opt.UI.Helpers.DataModel
{
    public static class SortDirectionManager
    {
        public static string GetSortDirectionName(SortDirection sortDirection)
        {
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    return "По возрастанию";

                case SortDirection.Descending:
                    return "По убыванию";

                default:
                    throw new ArgumentException("Sort direction " + sortDirection + " is not supported", "sortDirection");
            }
        }
    }
}