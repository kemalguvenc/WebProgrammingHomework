using System.Security.Claims;

namespace WebProgrammingHomework.Extension
{
	public static class ClaimsExtension
	{
		public static string GetSpecificClaim(this IEnumerable<Claim> claims, string claimType)
		{
			var claim = claims.FirstOrDefault(x => x.Type == claimType);

			return (claim != null) ? claim.Value : string.Empty;
		}
	}
}
