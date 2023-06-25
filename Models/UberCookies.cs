namespace UberEats.Models
{
    public class UberCookies
    {
        private const string PartnersKey = "mypartners";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; } = null!;
        private IResponseCookies responseCookies { get; set; } = null!;

        public UberCookies(IRequestCookieCollection cookies) 
        {
            requestCookies = cookies;
        }
        public UberCookies(IResponseCookies cookies) 
        {
            responseCookies = cookies;
        }

        public void SetMyPartnerIds(List<Partner> mypartners)
        {
            List<int> ids = mypartners.Select(t => t.PartnerID).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions { 
                Expires = DateTime.Now.AddDays(30) 
            };
            RemoveMyPartnerIds();     // delete old cookie first
            responseCookies.Append(PartnersKey, idsString, options);
        }

        public string[] GetMyPartnerIds()
        {
            string cookie = requestCookies[PartnersKey] ?? String.Empty;
            if (string.IsNullOrEmpty(cookie))
                return Array.Empty<string>();   // empty string array
            else
                return cookie.Split(Delimiter);
        }      

        public void RemoveMyPartnerIds()
        {
            responseCookies.Delete(PartnersKey);
        }
    }
}
