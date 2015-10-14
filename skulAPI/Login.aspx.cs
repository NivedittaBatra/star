using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skulAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace skulAPI
{
    public partial class Login : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected async void loginStudent_Click(object sender, EventArgs e)
        {
            Student s = (JsonConvert.DeserializeObject<Student>(await h.GetStringAsync(url + "login/" + u1.Value.Trim() + "/" + p1.Value.Trim() + "/" +"stu")));
            if (s.name != "N")
            {
                ViewState.Add("s", JsonConvert.SerializeObject(s));
                Session["s"] = JsonConvert.SerializeObject(s);
                Response.Redirect("/StudentsPage/default.aspx",false);
            }
        }
        protected async void teacherLogin_Click(object sender, EventArgs e)
        {
            Institute s = (JsonConvert.DeserializeObject<Institute>(await h.GetStringAsync(url + "login/" + u2.Value.Trim() + "/" + p2.Value.Trim() + "/" + "sta")));
            if (s.name != "N")
            {
                if (s.activated==true || s.email == "s" || s.name == "ABC School" || s.contact == "99986687987")
                {
                    Session["u"] = JsonConvert.SerializeObject(s);
                    Session.Timeout = 1000;
                    Response.Redirect("/Institution/default.aspx", false); 
                }
            }
        }
    }
}