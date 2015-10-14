using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skulAPI.Models;
using System.IO;
using Newtonsoft.Json;

namespace skulAPI.Institution
{
    public partial class MarkAttendance : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            Institute ii = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            if (!IsPostBack)
            {
                string d = await h.GetStringAsync(url + "classWithAtt/" + ii.self);
                List<ClassWithAtt> sss = JsonConvert.DeserializeObject<List<ClassWithAtt>>(d);
                foreach (ClassWithAtt s in sss)
                {
                    classTable.InnerHtml = classTable.InnerHtml +
                        "<tr>" +
                        "<td>" + s.class_ + "</td>" +
                        "<td>" + s.done + "</td></tr>";
                    classList.Items.Add(new ListItem { Text = s.class_, Value = s.class_, Enabled = true, Selected = false });
                }
                Class initClass = JsonConvert.DeserializeObject<List<Class>>(await h.GetStringAsync(url + "class/" + ii.self))[0];
                string data = await h.GetStringAsync(url + "student/"+ii.self+"/"+sss[0].class_[0]+"/"+ sss[0].class_[4]);
                StudentOfClassWithId ss = JsonConvert.DeserializeObject<StudentOfClassWithId>(data);
                int i = 0; stuTable.InnerHtml = "";
                foreach (Student s in ss.a)
                {
                    stuTable.InnerHtml = stuTable.InnerHtml +
                        "<tr name='" + ss.IDs[i] + "'>" +
                        "<td>" + s.name + "</td>" +
                        "<td>" + s.class_ + "</td>" +
                        "<td>" + s.rollNo + "</td>" +
                        "<td>" + s.admissionNo + "</td></tr>";
                    ++i;
                }
            }
        }
        protected async void Unnamed_Click(object sender, EventArgs e)
        {
            Institute ii = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            string c = classList.SelectedItem.Text;
            string data = await h.GetStringAsync(url + "student/" + ii.self + "/" + c[0] + "/" + c[4]);
            StudentOfClassWithId swi = JsonConvert.DeserializeObject<StudentOfClassWithId>(data);
            List<string> IDs = new List<string>();
            foreach (int x in swi.IDs)
            {
                IDs.Add(x.ToString());
            }
            string sTest = Request.Form["ctl00$body$KonKonPresent"];
            string q = KonKonPresent.Value;
            List<string> ss = q.Split('~').ToList();
            ss = ss.Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
            List<Attendance> a = new List<Attendance>();
            foreach (string s in IDs)
            {
                Response.Write(DateTime.Today.ToString("dd-MMM-yy"));
                if(ss.Contains(s)) a.Add(new Attendance { of = s, on = DateTime.Today.ToString("dd-MMM-yy"), present = true });
                else a.Add(new Attendance { of = s, on = DateTime.Today.ToString("dd-MMM-yy"), present = false });
            }
            string yu = JsonConvert.SerializeObject(a);
            var t = await h.PostAsync(url + "attendance", new StringContent(JsonConvert.SerializeObject(a), System.Text.Encoding.UTF8, "application/json"));
        }

        protected async void classList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Institute ii = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            DropDownList d = sender as DropDownList;
            string x = d.SelectedValue;
            string data = await h.GetStringAsync(url + "student/"+ii.self+"/" + x[0] + "/" + x[4] + "");
            StudentOfClassWithId ss = JsonConvert.DeserializeObject<StudentOfClassWithId>(data);
            int i = 0; stuTable.InnerHtml = "";
            foreach (Student s in ss.a)
            {
                stuTable.InnerHtml = stuTable.InnerHtml +
                    "<tr name='" + ss.IDs[i] + "'>" +
                    "<td>" + s.name + "</td>" +
                    "<td>" + s.class_ + "</td>" +
                    "<td>" + s.rollNo + "</td>" +
                    "<td>" + s.admissionNo + "</td></tr>";
                ++i;
            }
        }
    }
}