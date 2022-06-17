using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadingDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                StudentEntities db = new StudentEntities();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);
                file.SaveAs(physicalPath);
                tblStudent student = new tblStudent();
                student.FirstName = Request.Form["firstname"];
                student.LastName = Request.Form["lastname"];
                student.ImageUrl = ImageName;
                db.tblStudents.Add(student);
                db.SaveChanges();
            }
            return RedirectToAction("../home/DisplayImage/");
        }
        public ActionResult DisplayImage()
        {
            return View();
        } 

    }
}