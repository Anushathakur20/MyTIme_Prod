using System.Security.Claims;

namespace System.Web
{
    internal class HttpContext
    {
        public static HttpContext Current { get; internal set; }
        public static object Session { get; internal set; }
        public ClaimsPrincipal User { get; internal set; }
        public object Response { get; internal set; }
    }
}