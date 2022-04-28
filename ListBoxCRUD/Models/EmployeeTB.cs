using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListBoxCRUD.Models
{
    public class EmployeeTB
    {
        public int employeeid { get; set; }
        public string name { get; set; }
        public Nullable<int> designationid { get; set; }
        public Nullable<int> salary { get; set; }
        public string address { get; set; }
        public string designation { get; set; }
    }
}