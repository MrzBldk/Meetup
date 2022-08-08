using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "Adress",
                    locality = "Locality",
                    postal_code = 69118,
                    country = "Country"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "username",
                        Password = "password",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Name Surname"),
                            new Claim(JwtClaimTypes.GivenName, "GivenName"),
                            new Claim(JwtClaimTypes.FamilyName, "FamilyName"),
                            new Claim(JwtClaimTypes.Email, "Email@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://example.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}