using System.Security.Claims;
using Furlan.dev.Models;

namespace Furlan.dev.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user){
            var result = new List<Claim>
            {
                new(type:ClaimTypes.Name, value: user.Email),
            };

            result.AddRange(collection: user.Roles.Select(role => new Claim(type: ClaimTypes.Role, value:role.Slug)));

            return result;
        }
    }
}