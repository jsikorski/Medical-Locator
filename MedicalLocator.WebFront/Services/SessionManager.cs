using System.Web;
using MedicalLocator.WebFront.Models.CommandsData;

namespace MedicalLocator.WebFront.Services
{
    public static class SessionManager
    {
        private const string CurrentUserLoginKey = "CurrentUserLogin";
        public static string CurrentUserLogin
        {
            get { return HttpContext.Current.Session[CurrentUserLoginKey] as string; }
            set { HttpContext.Current.Session[CurrentUserLoginKey] = value; }
        }

        private const string IsAnonymousKey = "IsAnonymousUser";
        public static bool IsAnonymous
        {
            get { return (HttpContext.Current.Session[IsAnonymousKey] as bool?) != false; }
            set { HttpContext.Current.Session[IsAnonymousKey] = value; }
        }

        private const string LastSearchDataSessionKey = "LastSearchData";
        public static SearchData LastSearchData
        {
            get { return HttpContext.Current.Session[LastSearchDataSessionKey] as SearchData; }
            set { HttpContext.Current.Session[LastSearchDataSessionKey] = value; }
        }
    }
}