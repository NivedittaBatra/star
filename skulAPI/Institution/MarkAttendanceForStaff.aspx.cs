using Newtonsoft.Json;
using skulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skulAPI.Institution
{
    public partial class MarkAttendanceForStaff : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Institute ii = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
                List<Staff> ss = JsonConvert.DeserializeObject<List<Staff>>(await h.GetStringAsync(url + "staff/" + ii.self));
                stuTable.InnerHtml = "";
                foreach (Staff s in ss)
                {
                    stuTable.InnerHtml = stuTable.InnerHtml +
                        "<tr name='" + s.self + "'>" +
                        "<td>" + s.name + "</td>" +
                        "<td>" + s.contact + "</td>" +
                        "<td>" + s.subject + "</td></tr>";
                }
            }
        }

        protected async void calcAtt_Click(object sender, EventArgs e)
        {
            Institute ii = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            List<Staff> sss = JsonConvert.DeserializeObject<List<Staff>>(await h.GetStringAsync(url + "staff/" + ii.self));
            List<string> IDs = new List<string>();
            foreach (Staff o in sss)
            {
                IDs.Add(o.self);
            }
            string sTest = Request.Form["ctl00$body$KonKonPresent"];
            string q = KonKonPresent.Value;
            List<string> ss = q.Split('~').ToList();
            ss = ss.Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
            List<Attendance> a = new List<Attendance>();
            foreach (string s in IDs)
            {
                if (ss.Contains(s)) a.Add(new Attendance { of = s, on = DateTime.Today.ToString("dd-MMM-yy"), present = true });
                else a.Add(new Attendance { of = s, on = DateTime.Today.ToString("dd-MMM-yy"), present = false });
            }
            await h.PostAsync(url + "attendance", new StringContent(JsonConvert.SerializeObject(a), System.Text.Encoding.UTF8, "application/json"));
        }
    }
}