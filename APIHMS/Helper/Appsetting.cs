namespace APIHMS.Helper
{
    public class Appsetting
    {
        public string secret { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public double accessExpiration { get; set; }
        public double refreshExpiration { get; set; }
    }
}
