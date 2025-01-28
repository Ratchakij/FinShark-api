using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Extensions;

public static class ClaimsExtensions
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        var claim = user.Claims.SingleOrDefault(x => x.Type.Equals(ClaimTypes.GivenName, StringComparison.OrdinalIgnoreCase));
        return claim?.Value;
    }
}