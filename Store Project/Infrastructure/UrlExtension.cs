using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Infrastructure
{
    public static class UrlExtension
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            
            return request.QueryString.HasValue ? String.Format($"{request.Path}{request.QueryString}") : request.Path.ToString();
        }
    }
}