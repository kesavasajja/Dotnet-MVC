
using Microsoft.AspNetCore.Mvc;
using CSI_Project.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;




using System.Net;


namespace CSI_Project.Controllers;


          public class HomeController : Controller
         {
            //GET:Email
        //     public ActionResult Index()
        //     {
        //         return View();
        //     }


        // [HttpGet("SendEmailTest/{Email_id}")]

        // public IActionResult SendEmailTest(string Email_id)

        // {

        //     try

        //     {

        //         using (MailMessage mail = new MailMessage())

        //         {

        //             mail.From = new MailAddress("kesava.s@prodapt.com");

        //             mail.To.Add(Email_id);

        //             mail.Subject = "Hello World";

        //             mail.Body = "<h1>Hello</h1>";

        //             mail.IsBodyHtml = true;

        //             using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("chx-smtp.systems.private", 25))

        //             {

        //                 smtp.UseDefaultCredentials = false;

        //                 smtp.Credentials = new NetworkCredential("kesava.s@prodapt.com", "Icantsay@20");

        //                 smtp.EnableSsl = false;

        //                 smtp.Send(mail);                       

        //             }

        //         }

        //     }

        //     catch (Exception ex)

        //     {

        //         string error = Convert.ToString(ex);

        //     }

 

 

        //     return Ok("Access Provided");

 
  [HttpGet("SendEmailTest/{Email_id}")]

        public IActionResult SendEmailTest(string Email_id)

        {

            try

            {

                using (MailMessage mail = new MailMessage())

                {

                    mail.From = new MailAddress("kesava.s@prodapt.com");

                    mail.To.Add(Email_id);

                    mail.Subject = "Hello World";

                    mail.Body = "<h1>Hello</h1>";

                    mail.IsBodyHtml = true;

                    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.office365.com", 587))

                    {

                        smtp.UseDefaultCredentials = false;

                        smtp.Credentials = new NetworkCredential("kesava.s@prodapt.com", "123");

                        smtp.EnableSsl = false;

                        smtp.Send(mail);                       

                    }

                }

            }

            catch (Exception ex)

            {

                string error = Convert.ToString(ex);

            }

 

 

            return Ok("Access Provided");

 

 

        }

       

 
 

        }

       

 

            
          



        


