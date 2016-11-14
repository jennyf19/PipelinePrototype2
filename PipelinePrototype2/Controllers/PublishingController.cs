using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace PipelinePrototype2.Controllers
{
    public class PublishingController : Controller
    {
        // GET: Publishing
        public ActionResult Index()
        {
            return View();
        }

        //Post: /FileUpLoad/

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string folderPath = Server.MapPath(("~/Files/"));

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));

                    file.SaveAs(path);

                    ViewBag.Message = "File uploaded successfully";

                    //ViewBag.Message(System.IO.File.OpenRead(path));
                    //ViewBag.ToString(System.IO.File.OpenRead(path));
                    /*Response.ContentType = "text/msword";
                    Response.WriteFile(path);
                    Response.End();*/
                    //Response.Write(path);
                    //Response.Output.Write(file);
                    //Response.Write(file);
                    //Response.End();

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR: " + ex.Message;
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View();
        }
    }
}