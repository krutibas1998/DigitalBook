using System.Security.Claims;

namespace DigitalBook.Model
{
    public class AppClaims
    {
        public string? userName { get; set; }    
        public string? password { get; set; }    
        public string? userType { get; set; }  
        
        public AppClaims (ClaimsIdentity claimsIdentity)
        {
            userName = Convert.ToString(claimsIdentity.FindFirst("userName").Value);
            password = Convert.ToString(claimsIdentity.FindFirst("password").Value);
            userType = Convert.ToString(claimsIdentity.FindFirst("userType").Value);
        }
    }

}
