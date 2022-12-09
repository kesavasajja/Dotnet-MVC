using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;  
using System.Data.SqlClient; 
using Microsoft.AspNetCore.Mvc;
using CSI_Project.Models;
using Newtonsoft.Json;
using System.Net;    
using System.Net.Mail;  
using System.IO;  
using System.Collections.Generic;
using System.Text;
using EASendMail; //add EASendMail namespace


namespace CSI_Project.Controllers
{
    public class GcommsController : Controller
    {

        
        public List<DbName> getDatasets()
        {
            
            // string val= User.Identity.Name;
            // Console.WriteLine(val);
            DataSet ds = new DataSet();
           // DateTime dt = new DateTime();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from datasets", con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                var lst = new List<DbName>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                   obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                    obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    lst.Add(obj);

                }

                con.Close();
                
                return lst; 
            }
        }

        public UserAccount pageStart()
        {
             //String content = await new StreamReader(Response.Body).ReadToEndAsync();
           UserAccount user = new UserAccount();
            string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            user.Username = Username;
            //Console.WriteLine("Value : "+Username);

           //String content = await new StreamReader(Response.Body).ReadToEndAsync();
             // DbName obj = JsonConvert.DeserializeObject<DbName>(content);
             // string response = "{"

            return user;
            
        }



        public List<DbName> getDatasetsNExTool()
        {
            // string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            // Console.WriteLine("Value : "+Username);
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from datasets where used_by='NExTool'", con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                var lst = new List<DbName>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                   obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   //Console.WriteLine(obj.delivery_date);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                    obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    lst.Add(obj);

                }

                con.Close();
                
                return lst; 
            }
        }


 public List<DbName> getDatasetsGcomms()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from datasets where used_by='Gcomms'", con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                var lst = new List<DbName>();
                //Parallel.ForEach(da, x => )
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                   obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                   obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    lst.Add(obj);

                }

                con.Close();
                
                return lst; 
            }
        }



        // Inprogress datasets
      
 public List<DbName> getDatasetsInProgress()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from datasets where status_ID = 'In Progress';", con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                var lst = new List<DbName>();
                //Parallel.ForEach(da, x => )
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                   obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                   obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    lst.Add(obj);

                }

                con.Close();
                
                return lst; 
            }
        }

        // On hold datasets

             
 public List<DbName> getDatasetsOnHold()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from datasets where status_ID = 'On Hold';", con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                var lst = new List<DbName>();
                //Parallel.ForEach(da, x => )
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                    obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                   obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    lst.Add(obj);

                }

                con.Close();
                
                return lst; 
            }
        }

        // Received datasets

        public List<DbName> getDatasetsReceived()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from datasets where status_ID = 'Received';", con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                var lst = new List<DbName>();
                //Parallel.ForEach(da, x => )
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                    obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                   obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    lst.Add(obj);

                }

                con.Close();
                
                return lst; 
            }
        }
        

        public bool SendMail()
        {

// string to = "dhiliban.gm@prodapt.com"; //To address    
// string from = "fromaddress@gmail.com"; //From address    
// MailMessage message = new MailMessage(from, to);  
  
// string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";  
// message.Subject = "Sending Email Using Asp.Net & C#";  
// message.Body = mailbody;  
// //message.BodyEncoding = Encoding.UTF8;  
// message.IsBodyHtml = true;  
// SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
// System.Net.NetworkCredential basicCredential1 = new  
// System.Net.NetworkCredential("kesavasajja9@gmail.com", "Kesava@123");  
// client.EnableSsl = true;  
// client.UseDefaultCredentials = false;  
// client.Credentials = basicCredential1;  
// try   
// {  
//     client.Send(message);  
// }   
  
// catch (Exception ex)   
// {  
//     throw ex;  
// }

// using (MailMessage mail = new MailMessage())
// {
//     mail.From = new MailAddress("prodaptktest@gmail.com");
//     mail.To.Add("dhiliban.gm@prodapt.com");
//     mail.Subject = "Hello World";
//     mail.Body = "<h1>Hello</h1>";
//     mail.IsBodyHtml = true;
    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

//     using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
//     {
//         smtp.UseDefaultCredentials = false;
//         smtp.Credentials = new NetworkCredential("prodaptktest@gmail.com", "Test@123");
//         smtp.EnableSsl = true;
//         smtp.Send(mail);
//     }
// }
//"kesavasajja9@gmail.com", "Kesava@123"
            return false;
        }

        // Completed datasets

         public List<DbName> getDatasetsCompleted()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select * from datasets where status_ID = 'Completed';", con);  
                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                var lst = new List<DbName>();
                //Parallel.ForEach(da, x => )
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                   obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                   obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    lst.Add(obj);

                }

                con.Close();
                
                return lst; 
            }
        }




 
        [HttpPost]
         public async Task<DbName> postDatasets()
         {
             String content = await new StreamReader(Request.Body).ReadToEndAsync();
              DbName obj = JsonConvert.DeserializeObject<DbName>(content);
              
             
             //DbName obj = new DbName(C);
             string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;";

           // Console.WriteLine("ID Value: "+obj.dataset_id);
        //    Console.WriteLine("Object "+obj.dataset_name);
        //    Console.WriteLine("Object "+obj.age_of_data);
        //    Console.WriteLine("Object "+obj.frequency_Internally);
        //    Console.WriteLine("Object "+obj.supply_format);
        //    Console.WriteLine("ID Value: "+obj.used_by);
        //     Console.WriteLine("ID Value: "+obj.source);
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                string query = "Insert into datasets (dataset_name, Age_of_data, Frequency_Internally, Status, Source, Delivery_method, Delivery_date, Frequency_from_OS,  Next_Update, used_by, supply_format, status_ID) values(@dataset_name, @Age_of_data, @Frequency_Internally, @Status, @Source, @Delivery_method, @Delivery_date, @Frequency_from_OS,  @Next_Update, @used_by, @supply_format, @status_ID)";  
                SqlCommand cmd = new SqlCommand(query, con);  
                cmd.Parameters.AddWithValue("@dataset_id", obj.dataset_id);  
                cmd.Parameters.AddWithValue("@dataset_name", obj.dataset_name);  
                cmd.Parameters.AddWithValue("@Age_of_data", obj.age_of_data); 
                cmd.Parameters.AddWithValue("@Frequency_Internally", obj.frequency_Internally); 
                cmd.Parameters.AddWithValue("@Status", obj.status); 
                cmd.Parameters.AddWithValue("@Source", obj.source); 
                cmd.Parameters.AddWithValue("@Delivery_method", obj.delivery_method); 
                cmd.Parameters.AddWithValue("@Delivery_date", obj.delivery_date); 
                cmd.Parameters.AddWithValue("@Frequency_from_OS", obj.frequency_from_OS); 
                cmd.Parameters.AddWithValue("@Next_Update", obj.next_Update); 
                cmd.Parameters.AddWithValue("@used_by", obj.used_by); 
                cmd.Parameters.AddWithValue("@supply_format", obj.supply_format); 
                cmd.Parameters.AddWithValue("@status_ID", obj.status_ID);
                
                cmd.ExecuteNonQuery(); 
            }  
            return obj;
         }

        [HttpPost]
         public async Task<DbName>updateDatasets()
         {

              String content = await new StreamReader(Request.Body).ReadToEndAsync();
              DbName obj = JsonConvert.DeserializeObject<DbName>(content);
              //get the data from backend-> what is the actual status_Id--->Actual_Id
              try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your yahoo email address
                oMail.From = "kesavasajja@yahoo.com";

                // Set recipient email address
                oMail.To = "lshariprasadp@gmail.com";

                // Set email subject
                oMail.Subject = "test email from yahoo account";

                // Set email body
                oMail.TextBody = "this is a test email sent from c# with yahoo.";

                // Yahoo SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.mail.yahoo.com");

                // For example: your email is "myid@yahoo.com", then the user should be "myid@yahoo.com"
                oServer.User = "kesavasajja@yahoo.com";
                oServer.Password = "6300297818";


                // Because yahoo deploys SMTP server on 465 port with direct SSL connection.
                // So we should change the port to 465. you can also use 25 or 587
                oServer.Port = 465;

                // detect SSL type automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
              //IF(obj.status_ID!=Actual_Id)
                //trigger email
              //else
                    //continue  
             string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;";
             
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();  
                string query = "Update datasets SET  Dataset_Name=@dataset_name, Age_Of_Data=@Age_of_data, Frequency_Internally=@Frequency_Internally, Status=@Status, Source=@Source, Delivery_Method=@Delivery_method, Delivery_Date=@Delivery_date, Frequency_From_OS=@Frequency_from_OS,  Next_Update=@Next_Update,  Used_By=@used_by, Supply_Format=@supply_format, Status_ID=@status_ID where Dataset_Id=@dataset_id";

                SqlCommand cmd = new SqlCommand(query, con);  
               cmd.Parameters.AddWithValue("@dataset_id", obj.dataset_id);  
                cmd.Parameters.AddWithValue("@dataset_name", obj.dataset_name);  
                cmd.Parameters.AddWithValue("@Age_of_data", obj.age_of_data); 
                cmd.Parameters.AddWithValue("@Frequency_Internally", obj.frequency_Internally); 
                cmd.Parameters.AddWithValue("@Status", obj.status); 
                cmd.Parameters.AddWithValue("@Source", obj.source); 
                cmd.Parameters.AddWithValue("@Delivery_method", obj.delivery_method); 
                cmd.Parameters.AddWithValue("@Delivery_date", obj.delivery_date);
                //Console.WriteLine(obj.delivery_date);
                cmd.Parameters.AddWithValue("@Frequency_from_OS", obj.frequency_from_OS); 
                cmd.Parameters.AddWithValue("@Next_Update", obj.next_Update); 
                cmd.Parameters.AddWithValue("@used_by", obj.used_by); 
                cmd.Parameters.AddWithValue("@supply_format", obj.supply_format); 
                 cmd.Parameters.AddWithValue("@status_ID", obj.status_ID);
                cmd.ExecuteNonQuery(); 
                return obj; 
            }  
         }
          [HttpPost] 
          public async Task<DbName> deleteDatasets()
          {
              String content = await new StreamReader(Request.Body).ReadToEndAsync();
              DbName obj = JsonConvert.DeserializeObject<DbName>(content);
              string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;";
             
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();
                 string query = "Delete from datasets where  Dataset_Id=@dataset_id";  
                SqlCommand cmd = new SqlCommand(query, con);  
                cmd.Parameters.AddWithValue("@dataset_id", obj.dataset_id);  
                cmd.ExecuteNonQuery();
               // Console.Write(obj.dataset_id);
              //  Console.Write(query); 
                return new DbName(); 
            }

          }

        [HttpGet]
        public List<SqlData> getBarChartDatasets()
        {
             var today = DateTime.Now;
         var StartDate = new DateTime(today.Year,1,1);
             var EndDate = new DateTime(today.Year,12,31);

             DataSet ds = new DataSet();
             string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
             var lst = new List<SqlData>();
             using(SqlConnection con = new SqlConnection(strConString)) {  
                 con.Open(); 

                  SqlCommand cmd = new SqlCommand("  Select  used_by, Month(Delivery_date) as month,  Count(*) as count from datasets where Delivery_date between @StartDate and @EndDate Group by used_by, Month(Delivery_date) order by month", con); 
                 cmd.Parameters.AddWithValue("@StartDate",StartDate);
                 cmd.Parameters.AddWithValue("@EndDate",EndDate);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);  
                 da.Fill(ds);
                
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                 {
                     SqlData sk = new SqlData();
                     sk.used_by=ds.Tables[0].Rows[i]["used_by"].ToString();
                     sk.month=Convert.ToInt32(ds.Tables[0].Rows[i]["month"].ToString());
                     sk.count=Convert.ToInt64(ds.Tables[0].Rows[i]["count"].ToString());
                     lst.Add(sk);

                 }

                 con.Close();
                return lst; 
                
             }
        }


        // public List<DbName> getBarChartDatasets()
        // {
            

        //      var today = DateTime.Now;
        //      var StartDate = new DateTime(today.Year,1,1);
        //      var EndDate = new DateTime(today.Year,12,31);
        //      DataSet ds = new DataSet();
        //      string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;";
        //     using(SqlConnection con = new SqlConnection(strConString)) {  
        //      con.Open(); 
        //      SqlCommand cmd = new SqlCommand("Sp_DatasetsGraph", con);  
        //         cmd.CommandType = CommandType.StoredProcedure;
        //         cmd.Parameters.AddWithValue("@StartDate", StartDate);
        //         cmd.Parameters.AddWithValue("@EndDate", EndDate);

        //         SqlDataAdapter da = new SqlDataAdapter(cmd);  
        //         da.Fill(ds);
        //           var lst = new List<DbName>();
        //         for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
        //         {
                    
        //             DbName obj = new DbName();
        //             obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
        //             obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
        //             obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
        //             obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
        //             obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
        //             obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
        //             obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
        //            obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
        //            obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
        //             obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
        //             obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
        //             obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
        //             obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
        //             lst.Add(obj);

        //         }

        //         con.Close();
                
        //         return lst;

        //     }


        // }

        [HttpGet]
           public async Task<DbNameModel> getDatasetsPagination(int Currentpage)
        {

             String content = await new StreamReader(Request.Body).ReadToEndAsync();
              DbName obj1 = JsonConvert.DeserializeObject<DbName>(content);
            
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;";
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open(); 
                int maxRows = 5;
               
                SqlCommand cmd = new SqlCommand("Sp_Datasets_Paging", con);  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pageindex", Currentpage);
                cmd.Parameters.AddWithValue("@Pagesize", maxRows);

                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                List<DbName> dbname = new List<DbName>();
                DbNameModel dbnamemodel = new DbNameModel();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                   obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                    obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    dbname.Add(obj);

                }
               
         dbnamemodel.dbNames = dbname;
         dbnamemodel.PageCount = dbnamemodel.dbNames.Count();
         dbnamemodel.CurrentIndex = Currentpage;
              con.Close();
                return dbnamemodel;
                
                 
            }
        }

         [HttpGet]
           public async Task<DbNameModel> getGcommsDatasetsPagination(int Currentpage)
        {
            //Console.WriteLine(Currentpage);
             String content = await new StreamReader(Request.Body).ReadToEndAsync();
              DbName obj1 = JsonConvert.DeserializeObject<DbName>(content);
              //int PageNO = Convert.ToInt64(Currentpage);
              
            
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;";
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open();

                //Need to pass max rows values from UI to API Controller 
                int maxRows = 5;
               
                SqlCommand cmd = new SqlCommand("Sp_Gcomms_Datasets_Paging", con);  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pageindex", Currentpage);
                cmd.Parameters.AddWithValue("@Pagesize", maxRows);

                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                //   var lst = new List<DbNameModel>();
                List<DbName> dbname = new List<DbName>();
                DbNameModel dbnamemodel = new DbNameModel();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                    obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                     obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();

                }
               
         dbnamemodel.dbNames = dbname;
         dbnamemodel.PageCount = dbnamemodel.dbNames.Count();
         dbnamemodel.CurrentIndex = Currentpage;
              con.Close();
                return dbnamemodel;
                
                 
            }
        }


          [HttpGet]
           public async Task<DbNameModel> getNExToolDatasetsPagination(int Currentpage)
        {
           // Console.WriteLine(Currentpage);
             String content = await new StreamReader(Request.Body).ReadToEndAsync();
              DbName obj1 = JsonConvert.DeserializeObject<DbName>(content);
              //int PageNO = Convert.ToInt64(Currentpage);
              
            
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;";
            using(SqlConnection con = new SqlConnection(strConString)) {  
                con.Open(); 
                int maxRows = 5;
               
                SqlCommand cmd = new SqlCommand("Sp_NExTool_Datasets_Paging", con);  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pageindex", Currentpage);
                cmd.Parameters.AddWithValue("@Pagesize", maxRows);

                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                da.Fill(ds);
                //   var lst = new List<DbNameModel>();
                List<DbName> dbname = new List<DbName>();
                DbNameModel dbnamemodel = new DbNameModel();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    DbName obj = new DbName();
                    obj.dataset_id =Convert.ToInt32(ds.Tables[0].Rows[i]["dataset_id"].ToString());
                    obj.dataset_name = ds.Tables[0].Rows[i]["dataset_name"].ToString();
                    obj.age_of_data = ds.Tables[0].Rows[i]["Age_of_data"].ToString();
                    obj.frequency_Internally = ds.Tables[0].Rows[i]["Frequency_Internally"].ToString();
                    obj.status = ds.Tables[0].Rows[i]["Status"].ToString();
                    obj.source = ds.Tables[0].Rows[i]["Source"].ToString();
                    obj.delivery_method = ds.Tables[0].Rows[i]["Delivery_method"].ToString();
                   obj.delivery_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Delivery_date"]);
                   obj.frequency_from_OS = ds.Tables[0].Rows[i]["Frequency_from_OS"].ToString();
                    obj.next_Update = ds.Tables[0].Rows[i]["Next_Update"].ToString();
                    obj.used_by = ds.Tables[0].Rows[i]["used_by"].ToString();
                    obj.supply_format = ds.Tables[0].Rows[i]["supply_format"].ToString();
                     obj.status_ID =ds.Tables[0].Rows[i]["status_ID"].ToString();
                    dbname.Add(obj);

                }
               
         dbnamemodel.dbNames = dbname;
         dbnamemodel.PageCount = dbnamemodel.dbNames.Count();
         dbnamemodel.CurrentIndex = Currentpage;
              con.Close();
                return dbnamemodel;
                
                 
            }
        }




[HttpGet]
public  string getNExToolDatasetsCount()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString))
             {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("select count(*) as count from   [datasets]  where used_by='NExTool'", con);  
                Int32 count = (Int32) cmd .ExecuteScalar();
                con.Close();
                // Console.WriteLine(ds);
                
                return count.ToString() ;
            }
        }

        
[HttpGet]
public  string getGcommsDatasetsCount()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
            using(SqlConnection con = new SqlConnection(strConString))
             {  
                con.Open();  
                SqlCommand cmd = new SqlCommand("select count(*) as count from   [datasets]  where used_by='Gcomms'", con);  
                Int32 count = (Int32) cmd .ExecuteScalar();
                con.Close();
                // Console.WriteLine(ds);
                
                return count.ToString() ;
            }
        }

 


 [HttpGet]
        public List<StatusCount> getDatasetsStatusCount()
        {
           

             DataSet ds = new DataSet();
             string strConString = @"Data Source=CLAP1990\MSSQL;Database=Project;Trusted_Connection=True;" ;
             var lst = new List<StatusCount>();
             using(SqlConnection con = new SqlConnection(strConString)) {  
                 con.Open(); 

                  SqlCommand cmd = new SqlCommand(" select status_ID, count(*) as total from datasets where status_ID in ('Completed', 'Received', 'On Hold', 'In Progress') group by status_ID ", con); 
                
                 SqlDataAdapter da = new SqlDataAdapter(cmd);  
                 da.Fill(ds);
                
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                 {
                     StatusCount sk = new StatusCount();
                     sk.status_ID = ds.Tables[0].Rows[i]["status_ID"].ToString();
                     sk.total=Convert.ToInt32(ds.Tables[0].Rows[i]["total"].ToString());
                   lst.Add(sk);

                 }

                 con.Close();
                return lst; 
                
             }
        }

 

        
    }
}