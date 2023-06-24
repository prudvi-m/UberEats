namespace UberEats.Models
{
    public class PartnersViewModel
    {
        public string ActiveConf { get; set; } = "all";
        public string ActiveDiv { get; set; } = "all";
        public Partner Partner { get; set; } = new Partner();
        public List<Partner> Partners { get; set; } = new List<Partner>();

        // methods to help view determine active link
        public string CheckActiveConf(string c) =>
            c.ToLower() == ActiveConf.ToLower() ? "active" : "";

        public string CheckActiveDiv(string d) =>
            d.ToLower() == ActiveDiv.ToLower() ? "active" : "";
    }
}
