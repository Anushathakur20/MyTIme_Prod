using System;

namespace MyTIME.Models
{
    public class VHSCREEN
    {
       public int ID { get; set; }
        public string DasID { get; set; }
        public string Employee_Name { get; set; }
        public string Report_Manager_Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Login { get; set; }
        public DateTime Logout { get; set; }
        public TimeSpan Total_Time { get; set; }
        public TimeSpan Over_Time { get; set; }
        public TimeSpan Works { get; set; }
        public TimeSpan Meeting { get; set; }
        public TimeSpan Training { get; set; }
        public TimeSpan Breaks { get; set; }
        public TimeSpan Auxiliary { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }         
    }
    public class WBS
    {
        public string New_WBS { get; set; }
    }

    public class OvertimeVH
    {
        public string WBS { get; set; }
        public TimeSpan overtime { get; set; }
        public string Daterange { get; set; }
    }

    
}
