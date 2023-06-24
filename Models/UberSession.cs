namespace UberEats.Models
{
    public class UberSession
    {
        private const string PartnersKey = "mypartners";
        private const string CountKey = "partnercount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";

        private ISession session { get; set; }
        public UberSession(ISession session) => this.session = session;

        public void SetMyPartners(List<Partner> partners) {
            session.SetObject(PartnersKey, partners);
            session.SetInt32(CountKey, partners.Count);
        }
        public List<Partner> GetMyPartners() =>
            session.GetObject<List<Partner>>(PartnersKey) ?? new List<Partner>();
        public int? GetMyPartnerCount() => session.GetInt32(CountKey);

        public void SetActiveConf(string activeConf) =>
            session.SetString(ConfKey, activeConf);
        public string GetActiveConf() => 
            session.GetString(ConfKey) ?? string.Empty;

        public void SetActiveDiv(string activeDiv) =>
            session.SetString(DivKey, activeDiv);
        public string GetActiveDiv() => 
            session.GetString(DivKey) ?? string.Empty;

        public void RemoveMyPartners() {
            session.Remove(PartnersKey);
            session.Remove(CountKey);
        }
    }
}