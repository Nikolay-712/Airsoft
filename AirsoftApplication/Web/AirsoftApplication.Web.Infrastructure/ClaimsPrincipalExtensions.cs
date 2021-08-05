namespace AirsoftApplication.Web.Infrastructure
{
    using System.Linq;
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            if (user.Claims.Count() == 0)
            {
                return null;
            }

            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
