using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skulAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace skulAPI.Institution
{
    public partial class Edit : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void updateInsti_Click(object sender, EventArgs e)
        {
            Institute ii = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            Institute i = new Institute { contact = contact.Value.Trim(), email = email.Value.Trim(), location = location.Value.Trim(), name = name.Value.Trim(), pass = pass.Value.Trim(), self = ii.self };
            var r = await h.PutAsync(url + "/insti", new StringContent(JsonConvert.SerializeObject(i), System.Text.Encoding.UTF8, "application/json"));
            if (r.IsSuccessStatusCode) Session["u"] = JsonConvert.SerializeObject(i);
        }
    }
}