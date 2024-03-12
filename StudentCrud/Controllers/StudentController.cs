using DinkToPdf;
using DinkToPdf.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrud.Models;
using StudentCrud.Services;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;
//using DinkToPdf;
//using DinkToPdf.Contracts;
//using Microsoft.AspNetCore.Mvc;

using System.IO;

namespace StudentCrud.Controllers
{
    public class StudentController : Controller
    {

        private IConverter converter;

        private readonly IStudentService service;

        public StudentController(IStudentService service, IConverter converter)
        {
            this.service = service;
            this.converter= converter;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var model=service.GetAllStudents();

            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var model=service.GetStudentById(id);

            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
          
            try
            {
                int result = service.AddStudentRecord(student);


                if (result >= 1)
                {


                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    return View();
                
                }
                    

                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = service.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result = service.UpdateStudent(student);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();//regenarate main page
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = service.GetStudentById(id);



            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int  result = service.DeleteStudent(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));


                }
                else 
                {
                    return View();
               
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        public  string GetHTMLString()
        {
            var students = service.GetAllStudents();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>Standard</th>
                                        <th>FeeRecord</th>
                                       
                                    </tr>");
            foreach (var s in students)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                   
                                  </tr>", s.Name, s.Standard, s.FeeRecord );
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }

        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"E:\PDFCreator\Student_Report.pdf"//This Path is belongs from my laptop if you want to check please change path
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            converter.Convert(pdf);
            return Ok("Successfully created PDF document.");
        }
    }



}




