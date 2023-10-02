using System;

namespace MyTIME.Models
{
    public class SMSCREEN
    {
        public string EmpID { get; set; } = "";
        public string EmployeeName { get; set; } = "";
        public string GCM { get; set; } = "";
        public string ManagerID { get; set; } = "";
        public string ManagerName { get; set; } = "";
        public string ManagerGCM { get; set; } = "";
        public int level { get; set; }
    }
    public class NessieID
    {
        public string NessieID_SAPID { get; set; } = "";
    }

    public class TotalOvertime
    {
        public string DAS_ID { get; set; } = "";
        public string RM_NAME { get; set; } = "";
        public TimeSpan Overtime { get; set; }
        public string Daterange { get; set; } = "";
        public string drange { get; set; }
        public string Sub{get; set; }
      

    }
    public class getfinaldasidfromsmid
    {
        public string DAS_ID { get; set; } = "";
    }
    public class getdetails
    {
        public string DAS_ID { get; set; } = "";
        public string NessieID_SAPID { get; set; } = "";
        public string Employee_Name { get; set; } = "";
        public string GCM_Level { get; set; } = "";
        public string Current_Chief_ID { get; set; } = "";
        public string Current_Chief_Name { get; set; } = "";
        public int level { get; set; } = 0;
    }
    public class getSM_id_name
    {
        public string DAS_ID { get; set; } = "";
       
        public string Employee_Name { get; set; } = "";
        
    }

    public class Getrmdasid_rmname
    {
        public string DAS_ID { get; set; } = "";

        public string Employee_Name { get; set; } = "";

    }

    public class Getvhdasid_vhname
    {
        public string DAS_ID { get; set; } = "";

        public string Employee_Name { get; set; } = "";

    }
    public class GetSMOneLevelDown
    {
        public string DAS_ID { get; set; } = "";

        public string Employee_Name { get; set; } = "";

    }
    public class DaterangeModel
    {
        public string Daterange { get; set; }
        public string Date { get; set; }
    }
}
