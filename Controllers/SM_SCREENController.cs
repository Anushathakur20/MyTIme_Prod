using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTIME.Enums;
using MyTIME.Models;
using MyTIME.Services;
using MyTIMEAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace MyTIMEAPP.Controllers
{
    public class SM_SCREENController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$");
        List<TotalOvertime> totalOvertimes = new List<TotalOvertime>();
        List<getfinaldasidfromsmid> Dasidlist = new List<getfinaldasidfromsmid>();
        public IActionResult Index()
        {
            ViewBag.Daterange = GetDaterange();
            GetSMSCREENHIERARCHY();
            DataSet ds = new DataSet();
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            using (SqlConnection con = new SqlConnection(constr))
            {

                SqlCommand cmd3 = new SqlCommand("GetFinalPivotForSM", con);
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd3))
                {
                    sda.Fill(ds);
                }
            }
            getrawdata();
            return View(ds);
        }
        public void GetSMSCREENHIERARCHY()
        {
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            SqlCommand com = new SqlCommand("GetdasidbySMID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            con.Open();
            SqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                getfinaldasidfromsmid tot = new getfinaldasidfromsmid();
                tot.DAS_ID = sdr["DAS_ID"].ToString();
                Dasidlist.Add(tot);
            }
            con.Close();

            if (Dasidlist.Count > 0)
            {
                foreach (var item in Dasidlist)
                {
                    int weekNum = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                    for (int i = 1; i <= 5; i++)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("GetSMscreenData", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DAS_ID", SqlDbType.VarChar).Value = item.DAS_ID;
                        cmd.Parameters.Add("@WeekNum", SqlDbType.VarChar).Value = weekNum - i;
                        SqlDataReader sdr1 = cmd.ExecuteReader();
                        while (sdr1.Read())
                        {
                            TotalOvertime RMot = new TotalOvertime();
                            RMot.DAS_ID = sdr1["DAS_ID"].ToString();
                            RMot.RM_NAME = sdr1["RM_NAME"].ToString();
                            if (!sdr1.IsDBNull("Overtime"))
                            {
                                RMot.Overtime = (TimeSpan)sdr1["Overtime"];
                            }
                            else
                            {
                                RMot.Overtime = TimeSpan.Zero;
                            }
                            RMot.Daterange = sdr1["Daterange"].ToString();
                            totalOvertimes.Add(RMot);
                        }
                        con.Close();
                        ViewBag.getTotalOvertime = totalOvertimes;
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }

                }

            }
            foreach (var item in totalOvertimes)
            {
                SqlCommand cmd2 = new SqlCommand("GetPivotForSM", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@DAS_ID", item.DAS_ID);
                cmd2.Parameters.AddWithValue("@RM_NAME", item.RM_NAME);
                cmd2.Parameters.AddWithValue("@Overtime", item.Overtime);
                cmd2.Parameters.AddWithValue("@Daterange", item.Daterange);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            //var d = (from f in totalOvertimes
            //         group f by new { f.DAS_ID, f.RM_NAME }
            //                         into myGroup
            //         where myGroup.Count() > 0
            //         select new
            //         {
            //             myGroup.Key.DAS_ID,
            //             myGroup.Key.RM_NAME,

            //             drange = myGroup.GroupBy(f => f.Daterange).Select
            //                          (m => new { Sub = m.Key, Overtime = new TimeSpan(m.Sum(c => c.Overtime.Ticks)) })
            //         }).ToList();

            //ViewBag.getot = d;
            //var getdrange = (from s in totalOvertimes
            //                 where s.Daterange.Count() > 0
            //                 select s.Daterange).Take(5);
            //ViewBag.getDateRangForDropDown = getdrange;
            //string json = JsonConvert.SerializeObject(getdrange);
            //ViewBag.linqlisttojson = json;
            //ViewBag.list = new SelectList(totalOvertimes.Daterange, "DAS_ID", "Daterange");
        }
        [HttpGet]
        public IActionResult Viewlog(int id)
        {
            List<Activity_tbl> Atbl = new List<Activity_tbl>();
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
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

                    Atbl.Add(AT);
                }
                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                ViewBag.GetViewLog = Atbl;
                con.Close();
            }
            return View(Atbl);

        }
        [HttpPost]
        public IActionResult Approve([FromBody] string[] checkedInputs)
        {
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            using (SqlConnection con2 = new SqlConnection(constr))
            {
                using (SqlCommand sql = new SqlCommand("ApproveROWDATATimeBySM", con2))
                {
                    sql.Connection = con2;
                    sql.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < checkedInputs.Length; i++)
                    {
                        sql.Parameters.Clear();
                        sql.Parameters.Add(new SqlParameter("@id", checkedInputs[i]));
                        try
                        {
                            con2.Open();
                            sql.ExecuteNonQuery();
                            con2.Close();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }

            return RedirectToAction("Index", "SM_SCREEN");
        }
        [HttpPost]
        public IActionResult Reject([FromBody] string[] checkedInputs)
        {
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            using (SqlConnection con2 = new SqlConnection(constr))
            {
                using (SqlCommand sql = new SqlCommand("RejectROWDATATimeBySM", con2))
                {
                    sql.Connection = con2;
                    sql.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < checkedInputs.Length; i++)
                    {
                        sql.Parameters.Clear();
                        sql.Parameters.Add(new SqlParameter("@id", checkedInputs[i]));
                        try
                        {
                            con2.Open();
                            sql.ExecuteNonQuery();
                            con2.Close();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }

            return RedirectToAction("Index", "SM_SCREEN");
        }
        public static List<DaterangeModel> GetDaterange()
        {
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            List<DaterangeModel> drangeModels = new List<DaterangeModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {

                int weekNum = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                for (int i = 1; i <= 5; i++)
                {
                    SqlCommand cmd = new SqlCommand("GetDaterangeForDropdown", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WeekNum", weekNum - i);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            drangeModels.Add(new DaterangeModel
                            {
                                Date = sdr["Date"].ToString(),
                                Daterange = sdr["Daterange"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return drangeModels;
        }
       
        [HttpPost]
        public IActionResult updatestatusapprovebydrange()
        {
            string Daterange = HttpContext.Request.Form["Daterange"];
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            SqlCommand cmd = new SqlCommand("ApproveSMDataByWeek", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            cmd.Parameters.AddWithValue("@Date", Daterange);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, DAS_ID + Daterange + "your data has been Approved!");
            ViewBag.msg = "Dear" + DAS_ID + "Data Approved of" + Daterange + "DateRange";
            return RedirectToAction("Index");
        }
        public void getrawdata()
        {
            List<VHSCREEN> smscreen = new List<VHSCREEN>();
            //string connString = Configuration.GetConnectionString("ConStr");
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("GetRawDataForSMscreen", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Das_id", DAS_ID);
            con.Open();
            //com.ExecuteNonQuery();
            SqlDataReader sdr1 = com.ExecuteReader();
            while (sdr1.Read())
            {
                VHSCREEN screen = new VHSCREEN();
                screen.ID = Convert.ToInt32(sdr1["ID"]);
                screen.DasID = sdr1["DasID"].ToString();
                screen.Employee_Name = sdr1["Employee_Name"].ToString();
                screen.Report_Manager_Name = sdr1["Report_Manager_Name"].ToString();
               
                if (!sdr1.IsDBNull("Date"))
                {
                    screen.Date = Convert.ToDateTime(sdr1["Date"]);
                }
                else
                {
                    screen.Date = new DateTime();
                }
                if (!sdr1.IsDBNull("Login"))
                {
                    screen.Login = Convert.ToDateTime(sdr1["Login"]);
                }
                else
                {
                    screen.Login = new DateTime();
                }
                if (!sdr1.IsDBNull("Logout"))
                {
                    screen.Logout = Convert.ToDateTime(sdr1["Logout"]);
                }
                else
                {
                    screen.Logout = new DateTime();
                }
                if (!sdr1.IsDBNull("Logout"))
                {
                    screen.Logout = Convert.ToDateTime(sdr1["Logout"]);
                }
                else
                {
                    screen.Logout = new DateTime();
                }
                if (!sdr1.IsDBNull("Total_Time"))
                {
                    screen.Total_Time = (TimeSpan)sdr1["Total_Time"];
                }
                else
                {
                    screen.Total_Time = TimeSpan.Zero;
                }
                if (!sdr1.IsDBNull("Over_Time"))
                {
                    screen.Over_Time = (TimeSpan)sdr1["Over_Time"];
                }
                else
                {
                    screen.Over_Time = TimeSpan.Zero;
                }
                if (!sdr1.IsDBNull("Works"))
                {
                    screen.Works = (TimeSpan)sdr1["Works"];
                }
                else
                {
                    screen.Works = TimeSpan.Zero;
                }
                if (!sdr1.IsDBNull("Meeting"))
                {
                    screen.Meeting = (TimeSpan)sdr1["Meeting"];
                }
                else
                {
                    screen.Meeting = TimeSpan.Zero;
                }
                if (!sdr1.IsDBNull("Training"))
                {
                    screen.Training = (TimeSpan)sdr1["Training"];
                }
                else
                {
                    screen.Training = TimeSpan.Zero;
                }
                if (!sdr1.IsDBNull("Breaks"))
                {
                    screen.Breaks = (TimeSpan)sdr1["Breaks"];
                }
                else
                {
                    screen.Breaks = TimeSpan.Zero;
                }
                if (!sdr1.IsDBNull("Auxiliary"))
                {
                    screen.Auxiliary = (TimeSpan)sdr1["Auxiliary"];
                }
                else
                {
                    screen.Auxiliary = TimeSpan.Zero;
                }
                screen.Comment = sdr1["Comment"].ToString();
                screen.Status = sdr1["Status"].ToString();
                smscreen.Add(screen);
            }
            con.Close();
            ViewBag.rawdata = smscreen;

        }
    }
}
