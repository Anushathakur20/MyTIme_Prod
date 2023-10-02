using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTIME.Models
{
    public class BLOCKTIME
    {
       
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        
        public DateTime date { get; set; }
      
        public string activity { get; set; }

        //public string employee_Name { get; set; }
       
        public List<string> Memployee_Name { get; set; }
     
        public TimeSpan start_Time { get; set; }
      
        public TimeSpan end_Time { get; set; }
       
        public TimeSpan total_Time { get; set; }
    }
    public class NamesModel
    {
        public string Employee_Name { get; set; }
        public string DAS_ID { get; set; }
    }
    public class getBLOCKTIME
    {
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime date { get; set; }

        public string activity { get; set; }

        public string employee_Name { get; set; }

       // public List<string> Memployee_Name { get; set; }

        public TimeSpan start_Time { get; set; }

        public TimeSpan end_Time { get; set; }

        public TimeSpan total_Time { get; set; }
    }
}
