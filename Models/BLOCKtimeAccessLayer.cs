using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MyTIME.Models
{
    public class BLOCKtimeAccessLayer: BLOCKtimeAccessLayerBase
    {
        //string constr = @"Data Source=DESKTOP-J262VFN\SQLEXPRESS;Initial Catalog = MyTime_DB; Integrated Security = True";
        string constr = @"Data Source=VPS2D4SPL02;Initial Catalog=MyTime_DB;User ID=sa;Password=Atos123$";
        private IConfiguration Configuration;

        public BLOCKtimeAccessLayer()
        {
        }

        public BLOCKtimeAccessLayer(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public string AddBlockTime(BLOCKTIME blockTime)
        {
          //  string connString = Configuration.GetConnectionString("ConStr");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("BlockTimeRM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < blockTime.Memployee_Name.Count; i++)
                    {
                        try
                        {
                            string ct = blockTime.Memployee_Name[i];
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Date", blockTime.date);
                            cmd.Parameters.AddWithValue("@activity", blockTime.activity);
                            cmd.Parameters.AddWithValue("@das_Id", ct);
                            cmd.Parameters.AddWithValue("@start_Time", blockTime.start_Time);
                            cmd.Parameters.AddWithValue("@end_Time", blockTime.end_Time);
                            cmd.Parameters.AddWithValue("@total_Time", blockTime.total_Time);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        catch (Exception ex)
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            return (ex.Message.ToString());
                        }
                    }
                }
            }
            return ("data saved successfully");
        }

        }

    public class BLOCKtimeAccessLayerBase
    {
    }
}
