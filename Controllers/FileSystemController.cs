using TestFileApi.Model;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TestFileApi.Controllers
{
    [Route("api/[controller]")]
    public class FileSystemController : ControllerBase
    {
        [HttpGet]
        public IActionResult Readfile(List<Student> students = null)
        {
            students = students == null ? new List<Student>() : students;
            return Ok(students);

        }
        [Route("readfile")]
        [HttpPost]

        public async Task<IActionResult> Readfile(IFormFile files)
        {
            var fileName = "";
            // foreach (var formFile in files)
            // {
            //     if (formFile.Length > 0)
            //     {
                    fileName = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(fileName))
                    {
                        await files.CopyToAsync(stream);
                        stream.Flush();
                    }
                // }
            // }

            List<Student> students = new List<Student>();
            // var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            // System.Console.WriteLine(fileName);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // using(ExcelWorksheet  ws = new ExcelWorksheet.)
                    while (reader.Read())
                    {
                        students.Add(new Student()
                        {
                            // RollNo = reader.GetInt32(0),
                            EnrollmentNo = reader.GetValue(1).ToString(),
                            Name = reader.GetValue(1).ToString(),
                            Branch = reader.GetValue(2).ToString(),
                            University = reader.GetValue(3).ToString(),
                        });
                        
                    }
                }
            }
            return Ok(students);
        }
        
        // private List<Student> GetStudentList(string fName)
        // {
     
        // }




        //     private readonly IHttpContextAccessor Accessor;
        //    public FileSystemController( IHttpContextAccessor _accessor){
        //     this.Accessor = _accessor;
        //    }
        //     [Route("ReadFile")]
        //     [HttpPost]
        //     public string ReadFile( )
        //     {

        //         try
        //         {
        //             #region Variable Declaration
        //             string message = "";
        //             HttpResponseMessage ResponseMessage = null; 
        //             // HttpContext.Current.Request;
        //             HttpContext context = this.Accessor.HttpContext;
        //             var httpRequest = Microsoft.AspNetCore.Http.HttpContext.Current.Request;
        //             DataSet dsexcelRecords = new DataSet();
        //             IExcelDataReader reader = null;
        //             IFormFile Inputfile = null;
        //             Stream FileStream = null;
        //             #endregion

        //             #region Save Student Detail From Excel
        //             using (ApplicationDbContext objEntity = new ApplicationDbContext())
        //             {
        //                 if (httpRequest.File.Count > 0)
        //                 {
        //                     Inputfile = httpRequest.Files[0];
        //                     FileStream = Inputfile.InputStream;

        //                     if (Inputfile != null && FileStream != null)
        //                     {
        //                         if (Inputfile.FileName.EndsWith(".xls"))
        //                             reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
        //                         else if (Inputfile.FileName.EndsWith(".xlsx"))
        //                             reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
        //                         else
        //                             message = "The file format is not supported.";

        //                         dsexcelRecords = reader.AsDataSet();
        //                         reader.Close();

        //                         if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
        //                         {
        //                             DataTable dtStudentRecords = dsexcelRecords.Tables[0];
        //                             for (int i = 0; i < dtStudentRecords.Rows.Count; i++)
        //                             {
        //                                 Student objStudent = new Student();
        //                                 objStudent.RollNo = Convert.ToInt32(dtStudentRecords.Rows[i][0]);
        //                                 objStudent.EnrollmentNo = Convert.ToString(dtStudentRecords.Rows[i][1]);
        //                                 objStudent.Name = Convert.ToString(dtStudentRecords.Rows[i][2]);
        //                                 objStudent.Branch = Convert.ToString(dtStudentRecords.Rows[i][3]);
        //                                 objStudent.University = Convert.ToString(dtStudentRecords.Rows[i][4]);
        //                                 objEntity.Students.Add(objStudent);
        //                             }

        //                             int output = objEntity.SaveChanges();
        //                             if (output > 0)
        //                                 message = "The Excel file has been successfully uploaded.";
        //                             else
        //                                 message = "Something Went Wrong!, The Excel file uploaded has fiald.";
        //                         }
        //                         else
        //                             message = "Selected file is empty.";
        //                     }
        //                     else
        //                         message = "Invalid File.";
        //                 }
        //                 else
        //                     ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
        //                     // return ControllerBase.BadRequest();
        //             }
        //             return message;
        //             #endregion
        //         }
        //         catch (Exception)
        //         {
        //             throw;
        //         }
        //     }


    }
}