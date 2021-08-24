using Covid.Controllers;
using Covid.Logica;
using Covid.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace Covid.Tests.Controllers
{

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void FncExportJSONTest()
        {

            HomeController homeController = new HomeController();

            ActionResult result = homeController.FncExport("[]", "JSON", "REGION") as ActionResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(homeController.TempData);
            Assert.AreEqual("[]", homeController.TempData["Data"]);
            Assert.AreEqual("JSON", homeController.TempData["Type"]);

        }

        [TestMethod]
        public void FncExportXMLTest()
        {

            HomeController homeController = new HomeController();

            ActionResult result = homeController.FncExport("[]", "XML", "REGION") as ActionResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(homeController.TempData);
            Assert.AreEqual("<xml></xml>", homeController.TempData["Data"]);
            Assert.AreEqual("XML", homeController.TempData["Type"]);

        }

        [TestMethod]
        public void FncExportCSVTest()
        {

            HomeController homeController = new HomeController();

            ActionResult result = homeController.FncExport("[]", "CSV", "REGION") as ActionResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(homeController.TempData);
            Assert.AreEqual("REGION,CASES,DEATHS\n", homeController.TempData["Data"]);
            Assert.AreEqual("CSV", homeController.TempData["Type"]);

        }

        [TestMethod]
        public void GetRegions()
        {
            Mock<ICovidClient> mockCovidClient = new Mock<ICovidClient>();
            mockCovidClient.Setup(a => a.GetRegion()).Returns(new DataContainer<Region>());

            HomeController homeController = new HomeController(mockCovidClient.Object);
            ActionResult result = homeController.GetRegions() as ActionResult;

            Assert.IsInstanceOfType(result, typeof(JsonResult));
            Assert.IsNotNull(result);
            var jsonResult = (JsonResult)result;
            Assert.AreEqual(JsonRequestBehavior.AllowGet, jsonResult.JsonRequestBehavior);

        }


        [TestMethod]
        public void DownloadFileJSONTest()
        {
            HomeController homeController = new HomeController();
            homeController.TempData["Type"] = "JSON";
            homeController.TempData["Data"] = "[]";


            FileResult result = homeController.DownloadFile() as FileResult;

            Assert.AreEqual("txt/JSON", result.ContentType);
            Assert.AreEqual("Top10Covi.JSON", result.FileDownloadName);
            var fileResult = (FileContentResult)result;
            Assert.IsNotNull(fileResult.FileContents);
        }


    }
}
