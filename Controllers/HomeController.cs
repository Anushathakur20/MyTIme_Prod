using ITfoxtec.Identity.Saml2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyTIME.Models;
using MyTIMEAPP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace MyTIME.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Activity_tbl> activitylog = new List<Activity_tbl>();
        List<Activity_tbl> viewlog = new List<Activity_tbl>();
        List<MyTime_TB> mytime_tb = new List<MyTime_TB>();
        List<MyTime_TB> getdataLLTT = new List<MyTime_TB>();
       
        List<getDiff> diff_tm = new List<getDiff>();
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly Saml2Configuration config;
        SqlConnection con = new SqlConnection(@"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$");

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor _httpContextAccessor, IOptions<Saml2Configuration> configAccessor)
        {
            _logger = logger;
            httpContextAccessor = _httpContextAccessor;
            config = configAccessor.Value;
        }
        [HttpGet]
        public IActionResult Index()
        {
          
            GetActivityLog();
            ViewBag.GetActivityLog = activitylog;

            GetTodaysLoginLogout();
            ViewBag.getdataLLTT = getdataLLTT;

            ViewBag.GetViewLog = viewlog;

            return View();
        }
        [HttpPost]
        //Insert Login and Other Activity into Activity_tbl Start
        public IActionResult InsertActivity([FromBody] string checkedInputs)
        {
            try
            {
                //string DAS_ID = HttpContext.Request.Cookies["DAS_ID"];
                string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
                DateTime dt = DateTime.Now;
                //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
                SqlCommand cmd = new SqlCommand("AddActivity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                cmd.Parameters.AddWithValue("@Date", dt);
                cmd.Parameters.AddWithValue("@Activity", checkedInputs);
                cmd.Parameters.AddWithValue("@Start_Time", dt);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    getDiff diff = new getDiff();
                    diff.Diff = Convert.ToInt32(sdr["Diff"]);
                    diff_tm.Add(diff);
                }
                con.Close();
                foreach (var r in diff_tm)
                {
                    SqlCommand cmd1 = new SqlCommand("SetActivityDate", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                    if (r.Diff != 0)
                    {
                        cmd1.Parameters.AddWithValue("@Diff", r.Diff);
                    }
                    else
                    {
                        r.Diff = 09;
                        cmd1.Parameters.AddWithValue("@Diff", r.Diff);
                    }
                    
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            GetTodaysLoginLogout();
            return RedirectToAction("Index", "Home");
        }
     
        //Get Log File by ID Of all Activity Start
        [HttpGet]
        public IActionResult Viewlog(int id)
        {
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            SqlCommand com = new SqlCommand("GetDataByID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            //com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            con.Open();

            SqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                Activity_tbl AT = new Activity_tbl();
                AT.id = Convert.ToInt32(sdr["id"]);
                AT.DAS_ID = sdr["DAS_ID"].ToString();
                AT.Date = Convert.ToDateTime(sdr["Date"].ToString());
                AT.Activity = sdr["Activity"].ToString();
                AT.Start_Time = Convert.ToDateTime(sdr["Start_Time"].ToString());
                if (!sdr.IsDBNull("End_Time"))
                {
                    AT.End_Time = Convert.ToDateTime(sdr["End_Time"].ToString());
                }
                if (!sdr.IsDBNull("Total_Time"))
                {
                    AT.Total_Time = (TimeSpan)sdr["Total_Time"];
                }
                if (!sdr.IsDBNull("Comment"))
                {
                    AT.Comment = sdr["Comment"].ToString();
                }

                viewlog.Add(AT);
            }
            con.Close();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            ViewBag.GetViewLog = viewlog;
            con.Close();
            return View(viewlog);
        }
       

        //Insert Logout and Other Activity into MyTime_TB Start
        [HttpPost]
        public IActionResult LogoutActivity()
        {
            try
            {
                string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
                SqlCommand com = new SqlCommand("LogoutActivity_First", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                con.Open();
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    getDiff diff = new getDiff();
                    diff.Diff = Convert.ToInt32(sdr["Diff"]);


                    diff_tm.Add(diff);
                }
                con.Close();
                foreach (var r in diff_tm)
                {
                    SqlCommand cmd1 = new SqlCommand("SetActivityDate", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                    cmd1.Parameters.AddWithValue("@Diff", r.Diff);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
                SqlCommand com1 = new SqlCommand("Final_Logout", con);
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                con.Open();
                com1.ExecuteNonQuery();
                con.Close();
                //foreach (var cookie in Request.Cookies.Keys)
                //{
                //    Response.Cookies.Delete(cookie);
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
    
            return Redirect("~/Home/Index");
        }
       
        public IActionResult GetTodaysLoginLogout()
        {
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            SqlCommand com = new SqlCommand("Gettodaysloginlogouttime", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            con.Open();
            SqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                MyTime_TB AT = new MyTime_TB();
                if (!sdr.IsDBNull("Login"))
                {
                    AT.Login = Convert.ToDateTime(sdr["Login"].ToString());
                }
                if (!sdr.IsDBNull("Total_Time"))
                {
                    AT.Total_Time = (TimeSpan)sdr["Total_Time"];
                }
                if (!sdr.IsDBNull("Logout"))
                {
                    AT.Logout = Convert.ToDateTime(sdr["Logout"].ToString());
                }

                getdataLLTT.Add(AT);
            }

            ViewBag.getdataLLTT = getdataLLTT;
            con.Close();
            return RedirectToAction("Index", "Home");
        }
       

        //Get Activity Log of current Data Start
        public void GetActivityLog()
        {
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            SqlCommand com = new SqlCommand("GetActivity_Data", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            con.Open();
            SqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                Activity_tbl AT = new Activity_tbl();
                AT.id = Convert.ToInt32(sdr["id"]);
                AT.DAS_ID = sdr["DAS_ID"].ToString();

                if (!sdr.IsDBNull("Date"))
                {
                    AT.Date = Convert.ToDateTime(sdr["Date"].ToString());
                }
                if (!sdr.IsDBNull("Activity"))
                {
                    AT.Activity = sdr["Activity"].ToString();
                }
                if (!sdr.IsDBNull("Start_Time"))
                {
                    AT.Start_Time = Convert.ToDateTime(sdr["Start_Time"].ToString());
                }

                if (!sdr.IsDBNull("End_Time"))
                {
                    AT.End_Time = Convert.ToDateTime(sdr["End_Time"].ToString());
                }
                if (!sdr.IsDBNull("Total_Time"))
                {
                    AT.Total_Time = (TimeSpan)sdr["Total_Time"];
                }
                if (!sdr.IsDBNull("Comment"))
                {
                    AT.Comment = sdr["Comment"].ToString();
                }

                activitylog.Add(AT);
            }
            con.Close();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            ViewBag.GetActivityLog = activitylog;
        }


        [HttpGet]
        public JsonResult CalendarData()
        {
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            List<Calendar> calendars = new List<Calendar>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("getdataforCalendar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        calendars.Add(new Calendar
                        {

                            start = Convert.ToDateTime(sdr["start"].ToString().PadRight(10)),
                            title = sdr["title"].ToString(),

                            description = sdr["Status"].ToString()
                         + " , " + sdr["Works"].ToString()
                          + " , " + sdr["Meeting"].ToString()
                         + " , " + sdr["Training"].ToString()
                         + " , " + sdr["Breaks"].ToString()
                         + " , " + sdr["Auxiliary"].ToString()
                         + " , " + sdr["date"].ToString()
                         + " , " + sdr["login"].ToString()
                         + " , " + sdr["logout"].ToString()
                         + " , " + sdr["over_time"].ToString()
                           + " , " + sdr["id"].ToString(),
                           color = sdr["bgcolor"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return Json(calendars);
        }
        public IActionResult Privacy()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
  
       
    }
}


   


