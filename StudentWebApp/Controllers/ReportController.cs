using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using StudentWebApp.Models.Database;
using System.Text;
using System.IO;

namespace StudentWebApp.Controllers
{
    public class ReportController : Controller
    {
        Repository dbRepo = new Repository();
        // GET: Report
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult Index()
        //{
        //   StringBuilder csv = new StringBuilder();
        //    string filename = "";
        //    filename = "StudentsData_" + System.DateTime.Now.ToString() + ".csv";

        //    var data = dbRepo.GetStudents();

        //    // Header Line
        //    csv.AppendLine(string.Join(",", new string[] { "StudentID", "FirstName", "LastName" }));
        //    //Data lines
        //    foreach (var item in data)
        //    {
        //        csv.AppendLine(string.Join(",", new string[] { item.StudentID.ToString(), item.FirstName, item.LastName }));
        //    }

        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", "attachment;filename=" + filename);
        //    //Response.ContentType = "application/octet-stream";
        //    Response.ContentType = "text/csv";
        //    Response.Write(csv.ToString());
        //    Response.End();

        //    return null;
        //}

        public ActionResult Index()

        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("StudentID", "FirstName", "LastName" );

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=student.xls" );
            //Response.ContentType = "application/octet-stream";
            Response.ContentType = "text/excel";

            var data = dbRepo.GetStudents();

            foreach (var item in data)
            {
                sw.WriteLine(item.StudentID.ToString(), item.FirstName, item.LastName);
            }
            Response.Write(sw.ToString());
            Response.End();
            return null;

        }
    }
}