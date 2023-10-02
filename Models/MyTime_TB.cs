using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTIME.Models
{
    public class MyTime_TB
    {
        
        public int ID { get; set; }
        public string DasID { get; set; } = "";
        public string Employee_Name { get; set; } = "";
        public string Report_Manager_ID { get; set; } = "";
        public string Report_Manager_Name { get; set; } = "";

        public string Senior_Manager_ID { get; set; } = "";

        public string Senior_Manager_Name { get; set; } = "";

        public string Vertical_Head_ID { get; set; } = "";

        public string Vertical_Head_Name { get; set; } = "";
        public string SM_One_Level_ID { get; set; } = "";
        public string SM_One_Level_Name { get; set; } = "";
        public string WBS_ID { get; set; } = "";


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public DateTime? Login { get; set; }
        public DateTime? Logout { get; set; }
        public TimeSpan Total_Time { get; set; }
        public TimeSpan Over_Time { get; set; }
        public TimeSpan Works { get; set; }
        public TimeSpan Meeting { get; set; }
        public TimeSpan Training { get; set; }
        public TimeSpan Breaks { get; set; }
        public TimeSpan Auxiliary { get; set; }
        public string Comment { get; set; } = "";
        public string Status { get; set; } = "";
        public string Match { get; set; } = "";
    }
}
