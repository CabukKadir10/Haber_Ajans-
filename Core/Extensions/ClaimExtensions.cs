using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddNameIdentityfier(this ICollection<Claim> appRoles, string nameIdentityfier)
        {
            appRoles.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentityfier));
        }

        public static void AddEmail(this ICollection<Claim> appRoles, string email)
        {
            appRoles.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> appRoles, string name)
        {
            appRoles.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddRoles(this ICollection<Claim> appRoles, string roles)
        {
            appRoles.Add(new Claim(ClaimTypes.Name, roles));
        }
        //public static void AddRoles(this IList<Claim> claims, string[] roles)
        //{
        //    roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        //}

        public static void AddNews(this ICollection<Claim> appRoles, string news)
        {
            appRoles.Add(new Claim(ClaimTypes.Anonymous, news));
        }
    }
}
