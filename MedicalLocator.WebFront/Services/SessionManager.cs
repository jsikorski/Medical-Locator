using System.Web;
using MedicalLocator.WebFront.Models.CommandsData;

namespace MedicalLocator.WebFront.Services
{
    public static class SessionManager
    {
        private const string LastSearchDataSessionKey = "LastSearchData";

        public static SearchData LastSearchData
        {
            get { return HttpContext.Current.Session[LastSearchDataSessionKey] as SearchData; }
            set { HttpContext.Current.Session[LastSearchDataSessionKey] = value; }
        }
    }
}