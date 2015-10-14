using Newtonsoft.Json;
using skulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skulAPI.StudentsPage
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Student s = JsonConvert.DeserializeObject<Student>(Session["s"].ToString());
            stuName.InnerText = s.name;
            class_.InnerText = s.class_;
            if (s.rollNo != null) roll.InnerText = s.rollNo;
            else if(s.admissionNo != null) roll.InnerText = s.admissionNo;
            school.InnerText = s.school;
        }
    }
}