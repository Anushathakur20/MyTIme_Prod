using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyTIME.Models;
using MyTIMEAPP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyTIME.Controllers
{
    public class RM_SCREENController : Controller
    {
        RMscreenAccessLayer rMscreen1 = new RMscreenAccessLayer();
        public IActionResult Index()
        {
            List<RMSCREEN> rMscreens = new List<RMSCREEN>();
           
            rMscreens = rMscreen1.GetRMscreens(HttpContext, HttpContext).ToList();
            return View(rMscreens);
            
        }
        [HttpPost]
        public ActionResult GoToReconcile([FromBody] string[] checkedInputs)
        {
            return RedirectToAction("Reconcile", "RMscreen", new { checkedInputs = checkedInputs });
        }

        [HttpGet]
        public ActionResult Reconcile(string[] checkedInputs)
        {
            //string connString = Configuration.GetConnectionString("ConStr");
            //string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
                List<MyTime_TB> reconciles = new List<MyTime_TB>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("GetReconcile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < checkedInputs.Length; i++)
                {
                    try
                    {
                        string id = checkedInputs[i];
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            MyTime_TB rMscreen = new MyTime_TB();

                            rMscreen.ID = Convert.ToInt32(sdr["ID"]);
                            rMscreen.DasID = sdr["DasID"].ToString();
                           
                            if (!sdr.IsDBNull("Employee_Name"))
                            {
                                rMscreen.Employee_Name = sdr["Employee_Name"].ToString();
                            }
                            else
                            {
                                rMscreen.Employee_Name = "";
                            }
                            if (!sdr.IsDBNull("Report_Manager_Name"))
                            {
                                rMscreen.Report_Manager_Name = sdr["Report_Manager_Name"].ToString();
                            }
                            else
                            {
                                rMscreen.Report_Manager_Name = "";
                            }
                            
                            if (!sdr.IsDBNull("date"))
                            {
                                rMscreen.Report_Manager_Name = sdr["Report_Manager_Name"].ToString();
                            }
                            else
                            {
                                rMscreen.Report_Manager_Name = "";
                            }
                            if (!sdr.IsDBNull("date"))
                            {
                                rMscreen.Date = Convert.ToDateTime(sdr["date"]);
                            }
                            else
                            {
                                rMscreen.Date = new DateTime();
                            }
                            if (!sdr.IsDBNull("Login"))
                            {
                                rMscreen.Login = Convert.ToDateTime(sdr["Login"]);
                            }
                            else
                            {
                                rMscreen.Login = new DateTime();
                            }
                            if (!sdr.IsDBNull("Logout"))
                            {
                                rMscreen.Logout = Convert.ToDateTime(sdr["Logout"]);
                            }
                            else
                            {
                                rMscreen.Logout = new DateTime();
                            }
                            if (!sdr.IsDBNull("Total_Time"))
                            {
                                rMscreen.Total_Time = (TimeSpan)sdr["Total_Time"];
                            }
                            else
                            {
                                rMscreen.Total_Time = TimeSpan.Zero;
                            }
                            if (!sdr.IsDBNull("Over_Time"))
                            {
                                rMscreen.Over_Time = (TimeSpan)sdr["Over_Time"];
                            }
                            else
                            {
                                rMscreen.Over_Time = TimeSpan.Zero;
                            }
                            if (!sdr.IsDBNull("Works"))
                            {
                                rMscreen.Works = (TimeSpan)sdr["Works"];
                            }
                            else
                            {
                                rMscreen.Works = TimeSpan.Zero;
                            }
                            if (!sdr.IsDBNull("Meeting"))
                            {
                                rMscreen.Meeting = (TimeSpan)sdr["Meeting"];
                            }
                            else
                            {
                                rMscreen.Meeting = TimeSpan.Zero;
                            }
                            if (!sdr.IsDBNull("Training"))
                            {
                                rMscreen.Training = (TimeSpan)sdr["Training"];
                            }
                            else
                            {
                                rMscreen.Training = TimeSpan.Zero;
                            }
                            if (!sdr.IsDBNull("Breaks"))
                            {
                                rMscreen.Breaks = (TimeSpan)sdr["Breaks"];
                            }
                            else
                            {
                                rMscreen.Breaks = TimeSpan.Zero;
                            }
                            if (!sdr.IsDBNull("Auxiliary"))
                            {
                                rMscreen.Auxiliary = (TimeSpan)sdr["Auxiliary"];
                            }
                            else
                            {
                                rMscreen.Auxiliary = TimeSpan.Zero;
                            }    
                            rMscreen.Comment = sdr["Comment"].ToString();
                            rMscreen.Status = sdr["Status"].ToString();
                            rMscreen.Match = sdr["Match"].ToString();
                            reconciles.Add(rMscreen);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    con.Close();
                }
            }

            ViewBag.Recon = reconciles;
            //return View();
            return View("Reconcile");
            //TempData["NewReconcile"] = reconciles;
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
        public IActionResult Reject([FromBody] string[] checkedInputs)
        {
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            //string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";

            using (SqlConnection con2 = new SqlConnection(constr))
            {
                using (SqlCommand sql = new SqlCommand("RejectTimeByRM", con2))
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
            //string connString = Configuration.GetConnectionString("ConStr");
            string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            //string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";

            using (SqlConnection con2 = new SqlConnection(constr))
            {
                using (SqlCommand sql = new SqlCommand("ApproveTimeByRM", con2))
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
    }

}
