using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;
using skulAPI.Models;
using System.Web.UI.WebControls;

namespace skulAPI.StudentsPage
{
    public partial class _default : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Student s = JsonConvert.DeserializeObject<Student>(Session["s"].ToString());
                attList.InnerHtml = ""; int o = 0;
                int days = 5;
                List<string> dates = new List<string>();
                for (int i = 0; i < days; i++)
                {
                    dates.Add(DateTime.Today.AddDays(-1 * i).ToString("dd-MMM-yy"));
                }
                List<bool> aa = JsonConvert.DeserializeObject<List<bool>>(await h.GetStringAsync(url + "attendance/" + s.self + "/" + days.ToString()));
                foreach (bool a in aa)
                {
                    if (a) { attList.InnerHtml += "<tr><td>" + dates[o] + "</td><td>Present</td></tr>"; }
                    else { attList.InnerHtml += "<tr><td>" + dates[o] + "</td><td>Absent</td></tr>"; }
                    o++;
                }
                Homework hw = JsonConvert.DeserializeObject<Homework>(await h.GetStringAsync(url+"hw/"+s.school_+"/"+s.class_[0]+"/"+s.class_[4]+"/"+DateTime.Today.ToString("dd-MMM-yy")));
                if (hw != null)
                {
                    if (hw.detail != null) hw_txt.InnerText = hw.detail.Trim();
                    else hw_txt.InnerText = "No homework! Go out and play :D";
                }
                else hw_txt.InnerText = "No homework! Go out and play :D";
                List<Event> eves = JsonConvert.DeserializeObject<List<Event>>(await h.GetStringAsync(url + "event/"+s.school_));
                eventsList.InnerHtml = "";
                foreach (Event ev in eves)
                {
                    eventsList.InnerHtml += "<tr><td>"+ev.title+"</td><td>"+ev.date+"</td></tr>";
                }
            }
        }

        protected async void changeDays_Click(object sender, EventArgs e)
        {
            try {
                Student s = JsonConvert.DeserializeObject<Student>(Session["s"].ToString());
                attList.InnerHtml = ""; int days = int.Parse(days_txt.Text); int o = 0;
                List<string> dates = new List<string>();
                for (int i = 0; i < days; i++)
                {
                    dates.Add(DateTime.Today.AddDays(-1 * i).ToString("dd-MMM-yy"));
                }
                List<bool> aa = JsonConvert.DeserializeObject<List<bool>>(await h.GetStringAsync(url + "attendance/" + s.self + "/" + days.ToString()));
                foreach (bool a in aa)
                {
                    if (a) { attList.InnerHtml += "<tr><td>" + dates[o] + "</td><td>Present</td></tr>"; }
                    else { attList.InnerHtml += "<tr><td>" + dates[o] + "</td><td>Absent</td></tr>"; }
                    o++;
                } }
            catch {
                Student s = JsonConvert.DeserializeObject<Student>(Session["s"].ToString());
                attList.InnerHtml = ""; int days = 5; int o = 0;
                List<string> dates = new List<string>();
                for (int i = 0; i < days; i++)
                {
                    dates.Add(DateTime.Today.AddDays(-1 * i).ToString("dd-MMM-yy"));
                }
                List<bool> aa = JsonConvert.DeserializeObject<List<bool>>(await h.GetStringAsync(url + "attendance/" + s.self + "/" + days.ToString()));
                foreach (bool a in aa)
                {
                    if (a) { attList.InnerHtml += "<tr><td>" + dates[o] + "</td><td>Present</td></tr>"; }
                    else { attList.InnerHtml += "<tr><td>" + dates[o] + "</td><td>Absent</td></tr>"; }
                    o++;
                }
            }
        }

        protected async void getHw_Click(object sender, EventArgs e)
        {
                Student s = JsonConvert.DeserializeObject<Student>(Session["s"].ToString());
            DateTime d = DateTime.Parse(getDate.Value);
            Homework hw = JsonConvert.DeserializeObject<Homework>(await h.GetStringAsync(url + "hw/"+s.school_+"/"+s.class_[0]+"/"+s.class_[4]+"/" + d.ToString("dd-MMM-yy")));
            if (hw != null)
            {
                if (hw.detail != null) hw_txt.InnerText = hw.detail.Trim();
                else hw_txt.InnerText = "No homework! Go out and play :D";
            }
            else hw_txt.InnerText = "No homework! Go out and play :D";
        }
    }
}