using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System;
using HttpContext = Microsoft.AspNetCore.Http.HttpContext;
using Microsoft.Extensions.Configuration;

namespace MyTIME.Models
{
    public class RMscreenAccessLayer : RMscreenAccessLayerBase
    {
       // string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";

        string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
        private IConfiguration Configuration;

        public RMscreenAccessLayer()
        {
        }

        public RMscreenAccessLayer(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IEnumerable<RMSCREEN> GetRMscreens(HttpContext httpContext, HttpContext httpContext1)
    {
        List<RMSCREEN> rMscreens = new List<RMSCREEN>();
            //string connString = Configuration.GetConnectionString("ConStr");
            using (SqlConnection con = new SqlConnection(constr))
        {
                string DAS_ID = httpContext.Request.Cookies["DAS_ID"].ToString();
                //string DAS_ID = httpContext.Session.GetString("UserID").ToString();
                //string DAS_ID = "A722576";
                SqlCommand cmd = new SqlCommand("GetRMscreen", con);
            cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DAS_ID", DAS_ID);   
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                RMSCREEN rMscreen = new RMSCREEN();

                rMscreen.ID = Convert.ToInt32(sdr["id"]);
                rMscreen.DasID = sdr["DasID"].ToString();
                rMscreen.Employee_Name = sdr["Employee_Name"].ToString();
                rMscreen.Report_Manager_Name = sdr["Report_Manager_Name"].ToString(); 
                
                    if (!sdr.IsDBNull("Date"))
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

                rMscreens.Add(rMscreen);
            }
            con.Close();
        }
        return rMscreens;
    }
}

    public class RMscreenAccessLayerBase
    {
    }
}