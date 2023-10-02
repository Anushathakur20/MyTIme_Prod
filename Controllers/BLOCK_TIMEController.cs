using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyTIME.Enums;
using MyTIME.Models;
using MyTIME.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyTIME.Controllers
{
    public class BLOCK_TIMEController : Controller
    {
        private IConfiguration Configuration;
        BLOCKtimeAccessLayer blockTime1 = new BLOCKtimeAccessLayer();
        string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
        public BLOCK_TIMEController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
          public IActionResult Index()
        {
            GetBlockTimes();
            GetEmployeeNames();
            return View(); 
        }
        [HttpPost]
        public IActionResult Index([Bind] BLOCKTIME blockTime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = blockTime1.AddBlockTime(blockTime);
                    TempData["msg"] = resp;
                    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Time Blocked Successfully!");

                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "msg");

            }
            //return View(blockTime1);
            return RedirectToAction("Index");
        }
        public void GetEmployeeNames()
        {
            List<NamesModel> namesModels = new List<NamesModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                System.Web.HttpContext curContext = System.Web.HttpContext.Current;
                
                string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
                SqlCommand cmd = new SqlCommand("GetEmployeeNameListForDropdown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Das_ID", DAS_ID);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        namesModels.Add(new NamesModel
                        {
                            DAS_ID = sdr["DAS_ID"].ToString(),
                            Employee_Name = sdr["Employee_Name"].ToString(),
                        });
                    }
                }
                con.Close();
                ViewBag.NamesModels=namesModels;
            }
            //return namesModels;
        }
        public void GetBlockTimes()
        {
            //string connString = Configuration.GetConnectionString("ConStr");
           // string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
            List<getBLOCKTIME> blockTimes = new List<getBLOCKTIME>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string DAS_ID = HttpContext.Request.Cookies["DAS_ID"].ToString();
                //string DAS_ID = HttpContext.Session.GetString("UserID").ToString();
                SqlCommand cmd = new SqlCommand("GetBlockTime", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Das_ID", DAS_ID);
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        blockTimes.Add(new getBLOCKTIME
                        {
                            date = Convert.ToDateTime(sdr["Date"]),
                            activity = sdr["activity"].ToString(),
                            employee_Name = sdr["employee_Name"].ToString(),
                            start_Time = (TimeSpan)sdr["start_Time"],
                            end_Time = (TimeSpan)sdr["end_Time"],
                            total_Time = (TimeSpan)sdr["total_Time"],
                        });
                    }
                }
                con.Close();
                ViewBag.BlockTime = blockTimes;
            }
            
        }
        
    }
   
}
