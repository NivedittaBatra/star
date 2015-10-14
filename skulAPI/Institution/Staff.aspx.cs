using skulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;

namespace skulAPI.Institution
{
    public partial class staff : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        private Institute i;

        protected async void Page_Load(object sender, EventArgs e)
        {
                Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
                List<Staff> ss = JsonConvert.DeserializeObject<List<Staff>>(await h.GetStringAsync(url + "staff/" + i.self));
                foreach (Staff s in ss)
                {
                    stuTable.InnerHtml = stuTable.InnerHtml +
                    "<tr>" +
                    "<td>" + s.name + "</td>" +
                    "<td>" + s.subject + "</td>" +
                    "<td>" + s.contact + "</td></tr>";
                } 
        }

        protected async void addStaff_Click(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            await h.PostAsync(url + "staff/", new StringContent(
                JsonConvert.SerializeObject(new Staff { address = address.Value.Trim(), contact = contact.Value.Trim(), DOB = DOB.Value.Trim(), email = email.Value.Trim(), name = name.Value.Trim(), pass = "123", school = i.name, school_ = i.self, subject = subject.Value.Trim() }), System.Text.Encoding.UTF8, "application/json"));
        }
    }
}