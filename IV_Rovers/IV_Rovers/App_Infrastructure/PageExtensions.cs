using System.Web.UI;

namespace IV_Rovers
{
    public static class PageExtensions
    {
        //används för att hämta ut en session
        public static object GetTempData(this Page page, string key)
        {
            //value tilldelas vald session
            var value = page.Session[key]; 
            //tar bort sessionen 
            page.Session.Remove(key);
            return value;
        }

       //används för att hämta ut vald layout
        public static object GetLayOut(this Page page, string key)
        {
            var value = page.Session[key];

            return value;
        }

        //används för att skapa session
        public static void SetTempData(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}