using FileUploadSpike.ActionFilters;
using FileUploadSpike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadSpike.Controllers
{
    public class UploadController : Controller
    {
        #region Standard HTTP upload

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file1, HttpPostedFileBase file2, string other)
        {
            return View(new
            {
                File1Data = file1 != null ? string.Join(" : ", new object[] { file1.ContentLength.ToString() + " bytes", file1.ContentType, file1.FileName }) : "No file",
                File2Data = file2 != null ? string.Join(" : ", new object[] { file2.ContentLength.ToString() + " bytes", file2.ContentType, file2.FileName }) : "No file",
            });
        }

        #endregion

        #region Upload with FormData

        public ActionResult FormData()
        {
            return this.View();
        }

        [HttpPost, FilterClientDisconnectedRequests]
        public JsonResult FormData(HttpPostedFileBase file1, string other)
        {
            return Json(new AjaxFormPostResponse
            {
                Success = true,
                Message = this.GetFileData(file1)
            });
        }

        #endregion

        #region Upload to missing endpoint

        [HttpGet]
        public ActionResult FormDataServerError()
        {
            return this.View("FormData");
        }

        #endregion

        #region Upload to endpoint with error response

        public ActionResult FormDataServerTrappedError()
        {
            return this.View("FormData");
        }

        [HttpPost, JsonExceptionHandlerAttribute]
        public JsonResult FormDataServerTrappedError(HttpPostedFileBase file1, string other)
        {
            throw new Exception("Generic server error");
        }

        #endregion

        private string GetFileData(HttpPostedFileBase file)
        {
            return string.Join(" : ", new object[] { file.ContentLength.ToString() + " bytes", file.ContentType, file.FileName });
        }
    }
}
