using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTIME.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using ITfoxtec.Identity.Saml2;
using Microsoft.Extensions.Options;
using ITfoxtec.Identity.Saml2.MvcCore;
using ITfoxtec.Identity.Saml2.Schemas;
using System.Threading.Tasks;

namespace MyTIME.Controllers
{
    [AllowAnonymous]
    public class loginController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$");
        List<Ad_login> ADLog = new List<Ad_login>();
        List<getdetails> info = new List<getdetails>();
        List<getSM_id_name> smidnm = new List<getSM_id_name>();
        List<Getrmdasid_rmname> rmidnm = new List<Getrmdasid_rmname>();
        List<Getvhdasid_vhname> vhidnm = new List<Getvhdasid_vhname>();
        List<GetSMOneLevelDown> oldSM = new List<GetSMOneLevelDown>();
        List<Role> role = new List<Role>(); 
        string UserID = string.Empty;
        private readonly IHttpContextAccessor httpContextAccessor;
        //const string relayStateReturnUrl = "https://wacstg.das.myatos.net/sso_ws2fed_idp_mand2fa/prp?wa=wsignin1.0&wtrealm=https://mytime.in.myatos.net&wctx=rm=0&id=passive&ru=/&wreply=https://mytime.in.myatos.net/login/AuthorizationMethod";
        const string relayStateReturnUrl = "https://mytime-uat.in.myatos.net/Login/AuthorizationMethod";
        private readonly Saml2Configuration config;
        public loginController(IHttpContextAccessor _httpContextAccessor, IOptions<Saml2Configuration> configAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
            config = configAccessor.Value;
        }
      
        public IActionResult Index(string returnUrl = null)
        {
            var binding = new Saml2RedirectBinding();
            binding.SetRelayStateQuery(new Dictionary<string, string> { { relayStateReturnUrl, returnUrl ?? Url.Content("~/") } });
            return binding.Bind(new Saml2AuthnRequest(config)).ToActionResult();   
        }
      
        public async Task<IActionResult> AuthorizationMethod()
        {
            var binding = new Saml2PostBinding();
            var saml2AuthnResponse = new Saml2AuthnResponse(config);

            binding.Unbind(Request.ToGenericHttpRequest(), saml2AuthnResponse);
          
            string userid = Convert.ToString(saml2AuthnResponse.NameId.Value);
            HttpContext.Session.SetString("DAS_ID", userid);
            string DAS_ID = HttpContext.Session.GetString("DAS_ID").ToString();
            HttpContext.Response.Cookies.Append("DAS_ID", userid);
            var dasid = HttpContext.Request.Cookies["DAS_ID"];
            var relayStateQuery = binding.GetRelayStateQuery();
            var returnUrl = relayStateQuery.ContainsKey(relayStateReturnUrl) ? relayStateQuery[relayStateReturnUrl] : Url.Content("~/Home/Index");
            GetDetails();
            GetrolebasedMenuVH();
            GetrolebasedMenuSM();
            GetrolebasedMenuRM();
            ViewBag.Logindasid = HttpContext.Session.GetString("DAS_ID").ToString();
            return Redirect("~/Home/Index");
           
        }

      
              //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult Index([Bind] Ad_login ad)
        //{
        //    db dbop = new db();
        //    int res = dbop.LoginCheck(ad);

        //    if (res == 1)
        //    {
        //        dbop.AddLogincred(ad);

        //        ViewBag.LoginCred = ad;
        //        TempData["ad"] = ad.DAS_ID;
        //        HttpContext.Session.SetString("UserID", ad.DAS_ID);
        //        //HttpContext.Response.Cookies.Append("UserId", ad.DAS_ID);
        //        //var dasid = HttpContext.Request.Cookies["UserId"];
        //        GetDetails();
        //        GetrolebasedMenuVH();
        //        GetrolebasedMenuSM();
        //        GetrolebasedMenuRM();
        //        ViewBag.Logindasid = HttpContext.Session.GetString("UserID").ToString();
        //        return Redirect("~/Home/Index");

        //    }
        //    else
        //    {
        //        TempData["msg"] = "DasID or Password is wrong.!";
        //    }
        //    return View();

        //}

        public void GetDetails()
        {
            string DAS_ID = HttpContext.Session.GetString("DAS_ID").ToString();
            SqlCommand com = new SqlCommand("getdetailbydasid", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            com.CommandTimeout = 60 * 30;
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                getdetails gd = new getdetails();
                gd.DAS_ID = dr["DAS_ID"].ToString();
                HttpContext.Response.Cookies.Append("DAS_ID", gd.DAS_ID);
                var dasid = HttpContext.Request.Cookies["DAS_ID"];
                gd.Employee_Name = dr["Employee_Name"].ToString();
                HttpContext.Response.Cookies.Append("Employee_Name", gd.Employee_Name);
                var empnm = HttpContext.Request.Cookies["Employee_Name"];
                gd.Current_Chief_Name = dr["Current_Chief_Name"].ToString();
                HttpContext.Response.Cookies.Append("RM_Name", gd.Current_Chief_Name);
                var rmnm = HttpContext.Request.Cookies["RM_Name"];
                info.Add(gd);
            }
            con.Close();
            SqlCommand cmd1 = new SqlCommand("Getrmdasid_rmname", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            cmd1.CommandTimeout = 60 * 30;
            con.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                Getrmdasid_rmname rm = new Getrmdasid_rmname();
                rm.DAS_ID = sdr1["DAS_ID"].ToString();
                rm.Employee_Name = sdr1["Employee_Name"].ToString();
                TempData["rmdasid"] = rm.DAS_ID;
                TempData["rmnm"] = rm.Employee_Name;
                rmidnm.Add(rm);
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();
            SqlCommand cmd2 = new SqlCommand("Getsmdasid_smname", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            cmd2.CommandTimeout = 60 * 30;
            con.Open();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            while (sdr2.Read())
            {
                getSM_id_name sm = new getSM_id_name();
                sm.DAS_ID = sdr2["DAS_ID"].ToString();
                sm.Employee_Name = sdr2["Employee_Name"].ToString();
                TempData["smdasid"] = sm.DAS_ID;
                TempData["smnm"] = sm.Employee_Name;
                smidnm.Add(sm);
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();
            SqlCommand cmd3 = new SqlCommand("Getvhdasid_vhname", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            cmd3.CommandTimeout = 60 * 30;
            con.Open();
            SqlDataReader sdr3 = cmd3.ExecuteReader();
            while (sdr3.Read())
            {
                Getvhdasid_vhname vh = new Getvhdasid_vhname();
                vh.DAS_ID = sdr3["DAS_ID"].ToString();
                vh.Employee_Name = sdr3["Employee_Name"].ToString();
                TempData["vhdasid"] = vh.DAS_ID;
                TempData["vhnm"] = vh.Employee_Name;
                vhidnm.Add(vh);
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();
            SqlCommand cmd4 = new SqlCommand("SMoneleveldown", con);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            cmd4.CommandTimeout = 60 * 30;
            con.Open();
            SqlDataReader sdr4 = cmd4.ExecuteReader();
            while (sdr4.Read())
            {
                GetSMOneLevelDown ol = new GetSMOneLevelDown();
                ol.DAS_ID = sdr4["DAS_ID"].ToString();
                ol.Employee_Name = sdr4["Employee_Name"].ToString();
                TempData["smolddasid"] = ol.DAS_ID;
                TempData["smoldnm"] = ol.Employee_Name;
                oldSM.Add(ol);
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            try
            {
                SqlCommand cmd5 = new SqlCommand("matchDasIDandGetEmpDetails", con);
                cmd5.CommandType = CommandType.StoredProcedure;
                cmd5.Parameters.AddWithValue("@DAS_ID", DAS_ID);
                if (TempData["rmdasid"] == null)
                {
                    string RM_ID = "";
                    cmd5.Parameters.AddWithValue("@RM_ID", RM_ID).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@RM_ID", TempData["rmdasid"].ToString());
                }
                if (TempData["rmnm"] == null)
                {
                    string RM_Name = "";
                    cmd5.Parameters.AddWithValue("@RM_Name", RM_Name).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@RM_Name", TempData["rmnm"].ToString());
                }
                
                if (TempData["smdasid"] == null)
                {
                    string sm_ID = "";
                    cmd5.Parameters.AddWithValue("@sm_ID", sm_ID).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@sm_ID", TempData["smdasid"].ToString());
                }
                if (TempData["smnm"] == null)
                {
                    string sm_Name = "";
                    cmd5.Parameters.AddWithValue("@sm_Name", sm_Name).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@sm_Name", TempData["smnm"].ToString());
                }
                if (TempData["vhdasid"] == null)
                {
                    string vh_ID = "";
                    cmd5.Parameters.AddWithValue("@vh_ID", vh_ID).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@vh_ID", TempData["vhdasid"].ToString());
                }
                if (TempData["vhnm"] == null)
                {
                    string vh_Name = "";
                    cmd5.Parameters.AddWithValue("@vh_Name", vh_Name).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@vh_Name", TempData["vhnm"].ToString());
                }

                
                if (TempData["smolddasid"] == null)
                {
                    string smid = "";
                    cmd5.Parameters.AddWithValue("@SMOLID", smid).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@SMOLID", TempData["smolddasid"].ToString());
                }
                if (TempData["smoldnm"] == null)
                {
                    string smnm = "";
                    cmd5.Parameters.AddWithValue("@SMOLNM", smnm).ToString();
                }
                else
                {
                    cmd5.Parameters.AddWithValue("@SMOLNM", TempData["smoldnm"].ToString());
                }


                cmd5.CommandTimeout = 60 * 30;
             
                con.Open();
                cmd5.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
            }
        }
        public void GetrolebasedMenuVH()
        {
            //string DAS_ID = HttpContext.Request.Cookies["UserId"].ToString();
            string DAS_ID = HttpContext.Session.GetString("DAS_ID").ToString();
            SqlCommand com = new SqlCommand("CreateRoleVH", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            con.Open();
            SqlDataReader sdr1 = com.ExecuteReader();
            while (sdr1.Read())
            {
                Role r = new Role();

                r.RoleName = sdr1["RoleName"].ToString();
                HttpContext.Response.Cookies.Append("ROLEVH_NAME", r.RoleName);
                var ROLEVH_NAME = HttpContext.Request.Cookies["ROLEVH_NAME"];
                role.Add(r);
            }
            con.Close();
        }
        public void GetrolebasedMenuSM()
        {
            //string DAS_ID = HttpContext.Request.Cookies["UserId"].ToString();
            string DAS_ID = HttpContext.Session.GetString("DAS_ID").ToString();
            SqlCommand com = new SqlCommand("CreateRoleSM", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            con.Open();
            SqlDataReader sdr1 = com.ExecuteReader();
            while (sdr1.Read())
            {
                Role r = new Role();

                r.RoleName = sdr1["RoleName"].ToString();
                HttpContext.Response.Cookies.Append("ROLE_NAME", r.RoleName);
                var ROLE_NAME = HttpContext.Request.Cookies["ROLE_NAME"];
                role.Add(r);
            }
            con.Close();
        }
        public void GetrolebasedMenuRM()
        {
            //string DAS_ID = HttpContext.Request.Cookies["UserId"].ToString();
            string DAS_ID = HttpContext.Session.GetString("DAS_ID").ToString();
            SqlCommand com = new SqlCommand("CreateRoleFOrRM", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DAS_ID", DAS_ID);
            con.Open();
            SqlDataReader sdr1 = com.ExecuteReader();
            while (sdr1.Read())
            {
                Role r = new Role();

                r.RoleName = sdr1["RoleName"].ToString();
                HttpContext.Response.Cookies.Append("ROLERM_NAME", r.RoleName);
                var ROLERM_NAME = HttpContext.Request.Cookies["ROLERM_NAME"];
                role.Add(r);
            }
            con.Close();
        }
       
    }
     
    
}
