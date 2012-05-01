using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalLocator.WebFront.Controllers
{
    public class SearchingController : Controller
    {
        public string FindNearby(double longitude, double latitude)
        {
            return (longitude + latitude).ToString(CultureInfo.InvariantCulture);
        }
    }
}
