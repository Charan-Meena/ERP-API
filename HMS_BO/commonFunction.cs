using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_BO
{
    public class commonFunction
    {
        public static string GetHeaderValue(IHttpContextAccessor httpContextAccessor, string headerKey)
        {
            if (httpContextAccessor.HttpContext.Request.Headers.TryGetValue(headerKey, out var headerValue))
            {
                return headerValue.ToString();
            }
            return null; // Return null if the header is not found
        }
    }
}
