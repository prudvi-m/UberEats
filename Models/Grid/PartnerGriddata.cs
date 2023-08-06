namespace UberEats.Models.Grid
{
    public class PartnerGriddata: GridData
    {
        public PartnerGriddata() 
            => SortField = nameof(Partner.BusinessName);
    }
}
