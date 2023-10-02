namespace MyTIME.Models
{
    public class Ad_login
    {
        public int id { get; set; }
        public string DAS_ID { get; set; } = "";
        public string Password { get; set; } = "";
        public System.DateTime C_Date { get; set; }
        public string Employee_Name { get; set; } = "";
        public string Report_Manager_ID { get; set; } = "";

        public string Report_Manager_Name { get; set; } = "";
        public string Senior_Manager_ID { get; set; } = "";
        public string Senior_Manager_Name { get; set; } = "";
        public string vertical_Manager_ID { get; set; } = "";
        public string vertical_Manager_Name { get; set; } = "";
        public string SM_One_Level_ID { get; set; } = "";
        public string SM_One_Level_Name { get; set; } = "";
        public string WBS_ID { get; set; } = "";
    }

    public class Role
    {
        public string RoleName { get; set; } = "";
    }
}
