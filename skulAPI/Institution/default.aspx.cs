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
    public partial class _default1 : System.Web.UI.Page
    {

        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["u"] != null) {
                //Session["u"];
                Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
                string insti1 = await h.GetStringAsync(url + "insti/inception/" + i.self);
                instiStartup Startup = JsonConvert.DeserializeObject<instiStartup>(insti1);
                stuAtt.InnerText = Startup.stuAtt;
                staAtt.InnerText = Startup.staAtt;
                eventsCount.InnerText = Startup.eventCount;
            }
            else {
                try { Response.Redirect("http://kunalsachdeva.azurewebsites.net/default.aspx",false);return; } catch(Exception es) { }
        } }
    }
}