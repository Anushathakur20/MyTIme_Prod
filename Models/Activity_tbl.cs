using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTIMEAPP.Models
{
    public class Activity_tbl
    {
        public int id { get; set; }
        public string DAS_ID { get; set; }
        public DateTime Date { get; set; }
        public string Activity { get; set; }
        public DateTime? Start_Time { get; set; }
        public DateTime? End_Time { get; set; }
        public TimeSpan Total_Time { get; set; }
        public string Comment { get; set; }

    }

    public class getDiff
    {
        public int Diff { get; set; }
    }

    public class Calendar
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime start { get; set; }
        public String title { get; set; }

        public String description { get; set; }

        public string color { get; set; }

    }
}

