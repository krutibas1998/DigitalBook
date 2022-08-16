namespace TokenBaseAuth.Services
{
    public interface ITokenService
    {
        string BuidToken(string Key, string issuer, IEnumerable<string> audience, string userName);
        //string BuidToken(string key, string issuer, IEnumerable<string> audience, string userName);
    }
}