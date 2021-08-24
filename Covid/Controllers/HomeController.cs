using Covid.Logica;
using Covid.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Covid.Controllers
{
    public class HomeController : Controller
    {
        private ICovidClient client = null;

        public HomeController()
        {
            client = new CovidClient();
        }

        public HomeController(ICovidClient covidClient)
        {
            client = covidClient;
        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetRegions()
        {
            return Json(client.GetRegion().Data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCovidCases([DataSourceRequest] DataSourceRequest request, String StrIso = null)
        {
            List<CaseCovid> List = null;

            if (String.IsNullOrEmpty(StrIso))
            {
                List = client.GetReportRegion().Data.OrderByDescending(x => x.Confirmed).Take(10).ToList();
            }
            else
            {
                List = client.GetReportByRegion(StrIso).Data.OrderByDescending(x => x.Confirmed).Take(10).ToList();
            }

            return Json(List.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult FncExport(string Lst, string TypeExport, string TypeSearch)
        {

            TempData["Data"] = FncDatosExport(Lst, TypeExport, TypeSearch);
            TempData["Type"] = TypeExport;

            return Json("", JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public FileResult DownloadFile()
        {
            string StrType = TempData["Type"].ToString();
            byte[] bytedata = System.Text.Encoding.Default.GetBytes(TempData["Data"].ToString());

            return File(bytedata, "txt/" + StrType, "Top10Covi." + StrType);
        }



        private String FncDatosExport(string Lst, string TypeExport, string TypeSearch)
        {

            var Model = JsonConvert.DeserializeObject<List<CaseCovid>>(Lst);

            switch (TypeExport)
            {
                case "JSON":
                    return new ExportJson().DataToExport(Model, TypeSearch);
                case "XML":
                    return new ExportXml().DataToExport(Model, TypeSearch);
                case "CSV":
                    return new ExportCSV().DataToExport(Model, TypeSearch);
                default:
                    return "";
            }
        }


    }
}