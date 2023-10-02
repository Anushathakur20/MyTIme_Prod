using Microsoft.AspNetCore.Mvc;
using MyTIME.Models;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MyTIMEAPP.Models;

namespace MyTIME.Controllers
{
    
    public class VH_SCREENController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$");
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J262VFN\\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True");

        public IActionResult Index()
        {
            //ViewBag.Daterange = GetDaterange();
            GetDaterange();
            //string DAS_ID = HttpContext.Request.Cookies["DAS_ID"];
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            GetOvertime();
            DataSet ds = new DataSet();
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            using (SqlConnection con = new SqlConnection(constr))
            {

                SqlCommand cmd3 = new SqlCommand("GetFinalPivotForVH", con);
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd3))
                {
                    sda.Fill(ds);
                }
            }
            //    DataSet ds = new DataSet();
            //    SqlCommand com = new SqlCommand("GetRawDataForVH", con);
            //    com.CommandType = CommandType.StoredProcedure;
            //    com.Parameters.AddWithValue("@Das_id", DAS_ID);
            //    con.Open();
            //    com.ExecuteNonQuery();
            //    con.Close();
            //    using (SqlDataAdapter sda = new SqlDataAdapter(com))
            //    {
            //        sda.Fill(ds);
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            getrawdata();
            
            return View(ds);
                
            
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
                com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
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
        public void GetOvertime()
        {
            List<WBS> wBs = new List<WBS>(); 
            List<OvertimeVH> overtimeVHs = new List<OvertimeVH>();
            //string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            //string connString = Configuration.GetConnectionString("ConStr");
            using (SqlConnection con = new SqlConnection(constr))
            {
                string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
                //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
                SqlCommand cmd = new SqlCommand("GetWBSIDbyVH_DasID", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Das_ID", DAS_ID);

                con.Open(); SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    WBS wBS = new WBS();

                    wBS.New_WBS = sdr["New_WBS"].ToString(); wBs.Add(wBS);
                }
                con.Close();

                if (wBs.Count > 0)
                {
                    foreach (var item in wBs)
                    {
                        int weekNum = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now,
                            System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                        for (int i = 1; i <= 5; i++)
                        {
                            con.Open(); 
                            SqlCommand cmd1 = new SqlCommand("GetOvertimeForVHscreen", con);
                            cmd1.CommandType = CommandType.StoredProcedure; 
                            cmd1.Parameters.Add("@New_WBS", SqlDbType.VarChar).Value = item.New_WBS;
                            cmd1.Parameters.Add("@WeekNum", SqlDbType.VarChar).Value = weekNum - i;

                            SqlDataReader sdr1 = cmd1.ExecuteReader();
                            while (sdr1.Read())
                            {
                                OvertimeVH overtimes = new OvertimeVH();
                                overtimes.WBS = sdr1["WBS"].ToString();
                                if (!sdr1.IsDBNull("overtime"))
                                {
                                    overtimes.overtime = (TimeSpan)sdr1["overtime"];
                                }
                                else
                                {
                                    overtimes.overtime = TimeSpan.Zero;
                                }
                                overtimes.Daterange = sdr1["Daterange"].ToString();
                                overtimeVHs.Add(overtimes);
                            }
                            con.Close();
                        }
                        
                        ViewBag.GetVHOvertime = overtimeVHs;
                    }
                }
                foreach (var item in overtimeVHs)
                {
                    SqlCommand cmd2 = new SqlCommand("GetPivotForVH", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@WBS", item.WBS);
                    cmd2.Parameters.AddWithValue("@Overtime", item.overtime);
                    cmd2.Parameters.AddWithValue("@Daterange", item.Daterange);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }
            //var d = (from f in overtimeVHs
            //         group f by new { f.WBS}
            //                        into myGroup
            //         where myGroup.Count() > 0
            //         select new
            //         {
            //             myGroup.Key.WBS,
            //             drange = myGroup.GroupBy(f => f.Daterange).Select
            //                  (m => new { Sub = m.Key, Overtime = new TimeSpan(m.Sum(c => c.overtime.Ticks)) })
            //         }).ToList();
            //ViewBag.getVHOT = d;
            //var getdrange = (from s in overtimeVHs
            //                where s.Daterange.Count() > 0
            //                select s.Daterange).Take(5);
            //ViewBag.getDateRangForDropDown = getdrange;
        }
        public IActionResult Reject([FromBody] string[] checkedInputs)
        {
            //string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";

            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            //string connString = Configuration.GetConnectionString("constr");
            using (SqlConnection con2 = new SqlConnection(constr))
            {
                using (SqlCommand sql = new SqlCommand("RejectTimeByVH", con2))
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
            return RedirectToAction("Index");
        }
        public IActionResult Approve([FromBody] string[] checkedInputs)
        {
            //string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";

            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            //string connString = Configuration.GetConnectionString("ConStr");
            using (SqlConnection con2 = new SqlConnection(constr))
            {
                using (SqlCommand sql = new SqlCommand("ApproveTimeByVH", con2))
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
            getrawdata();
            return RedirectToAction("Index");
            


        }
        public void getrawdata()
        {
            List<VHSCREEN> vhscreen = new List<VHSCREEN>();
            //string connString = Configuration.GetConnectionString("ConStr");
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("GetRawDataForVH", con);
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
                vhscreen.Add(screen);
            }
            con.Close();
            ViewBag.rawdata = vhscreen;

        }
        public void GetDaterange()
        {
           // string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";

            //string connString = Configuration.GetConnectionString("ConStr");
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

            ViewBag.Daterange = drangeModels;
        }
        [HttpPost]
        public IActionResult updatestatusapprovebydrangeSM()
        {
            

                string Daterange = HttpContext.Request.Form["Daterange"];
            string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
            //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
            SqlCommand cmd = new SqlCommand("ApproveVHDataByWeek", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                cmd.Parameters.AddWithValue("@Date", Daterange);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            
        }
    }
}

