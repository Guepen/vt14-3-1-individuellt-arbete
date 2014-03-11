using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace IV_Rovers
{
    public static class PageExtensions
    {
        public static object GetTempData(Page page, string key)
        {
            var value = page.Session[key];
            page.Session.Remove(key);

            return value;
        }

        public static object PeekTempData(Page page, string key)
        {
            return page.Session[key];
        }

        public static void SetTempData(Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}