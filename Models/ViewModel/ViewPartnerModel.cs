using UberEats.Models.Grid;

namespace UberEats.Models.ViewModel
{
    public class ViewPartnerModel
    {

        public IEnumerable<Partner> Partners { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int TotalPages { get; set; }
        public PartnerGriddata CurrentRoute { get;set; }

    }
}
