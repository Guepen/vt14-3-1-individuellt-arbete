﻿using System.Web.UI;

namespace IV_Rovers
{
    public static class PageExtensions
    {
        public static object GetTempData(this Page page, string key)
        {
            var value = page.Session[key];
            page.Session.Remove(key);

            return value;
        }

       

        public static void SetTempData(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}