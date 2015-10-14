using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skulAPI.Models;
using Newtonsoft.Json;

namespace skulAPI.Institution
{
    public partial class Events : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            List<string> colors = new List<string> { "blue", "red", "teal", "orange" };
            eventsContainer.InnerHtml = "";
            List<Event> v = JsonConvert.DeserializeObject<List<Event>>(await h.GetStringAsync(url + "event/" + i.self));
            foreach (Event w in v)
            {
                w.desc = w.desc.Replace("\n", "<br/>");
                eventsContainer.InnerHtml += "<div class=\"demo-card-event mdl-card mdl-shadow--2dp\">" +
  "<div class=\"mdl-card__title mdl-card--expand\">" +
    "<h4>" +
w.title + "<br/>" + w.date +
    "</h4>" +
  "</div>" + "<div class=\"mdl-card__supporting-text\">" + w.desc + "</div>" +
  "<div class=\"mdl-card__actions mdl-card--border\">" +
    "<div class=\"mdl-layout-spacer\"></div>" +
    "<i class=\"material-icons\">event</i>" +
  "</div>" +
"</div>";
            }
        }

        protected async void createEvent_Click(object sender, EventArgs e)
        {
            string d = dateOfEvent.Value;
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            string yyyy = d[0].ToString() + d[1].ToString() + d[2].ToString() + d[3].ToString();
            string mm = d[5].ToString() + d[6].ToString();
            string dd = d[8].ToString() + d[9].ToString();
            DateTime dw = new DateTime(Int32.Parse(yyyy),Int32.Parse(mm),Int32.Parse(dd));
            Event v = new Event { date = dw.ToString("dd-MMM-yy"), desc = detail.Value.Trim(), title = title.Value.Trim(),school=i.self };
            await h.PostAsync(url + "event/", new StringContent(JsonConvert.SerializeObject(v),System.Text.Encoding.UTF8,"application/json"));
        }
    }
}