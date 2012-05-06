using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MedicalLocator.WebFront.CommandsData;
using MedicalLocator.WebFront.Infrastructure;

namespace MedicalLocator.WebFront.Controllers
{
    public class SearchingController : CommandsController
    {
        public ActionResult FindNearby(double longitude, double latitude)
        {
            var findNearbyData = new FindNearbyData(longitude, latitude);
            return ProcessCommandData(
                findNearbyData,
                () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }
    }
}
