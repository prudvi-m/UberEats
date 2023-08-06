using System.Collections.Generic;

namespace UberEats.Models.Grid
{
    public abstract class GridData
    {
        public int PageSize { get; set; } = 5;
        public int PageNumber { get; set; } = 1;
        public string SortDirection { get; set; } = "asc";
        public string SortField { get; set; } = string.Empty;

        public int GetTotalPages(int count) => 
            (count + PageSize - 1) / PageSize;

        public virtual GridData Clone() => (GridData)MemberwiseClone();
        public void SetSortAndDirection(string newSortField, GridData current)
        {
            SortField = newSortField;

            if (current.SortField.Equals(newSortField) && current.SortDirection == "asc")
            {
                SortDirection = "desc";
            }
            else
            {
                SortDirection = "asc";
            }
        }


        public virtual Dictionary<string, string> ToDictionary() =>
            new Dictionary<string, string> {
                { nameof(PageNumber), PageNumber.ToString() },
                { nameof(PageSize), PageSize.ToString() },
                { nameof(SortField), SortField },
                { nameof(SortDirection), SortDirection },
            };
    }

}
