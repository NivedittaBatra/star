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
    public partial class Classes : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            List<Class> cc= JsonConvert.DeserializeObject<List<Class>>(await h.GetStringAsync(url + "class/"+ i.self));
            classTable.InnerHtml = "";
            foreach (Class c in cc)
            {
                classTable.InnerHtml = classTable.InnerHtml +
                "<tr>" +
                "<td>" + c.standard + "</td>" +
                "<td>" + c.section + "</td></tr>";
            }
        }

        protected async void addClass_Click(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            await h.PostAsync(url + "class", new StringContent(JsonConvert.SerializeObject(new Class {school=i.self,standard=standard.Value.Trim(),section=section.Value.Trim()}), System.Text.Encoding.UTF8, "application/json"));
        }
    }
}