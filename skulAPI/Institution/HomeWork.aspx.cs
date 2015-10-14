using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using skulAPI.Models;
using Neo4jClient;

namespace skulAPI.Institution
{
    public partial class HomeWork : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
                List<Class> cc = JsonConvert.DeserializeObject<List<Class>>(await h.GetStringAsync(url + "class/"+i.self));
                foreach (Class c in cc)
                {
                    classes.Items.Add(new ListItem { Enabled = true, Selected = false, Text = c.standard + " - " + c.section, Value = c.standard + " - " + c.section });
                }
                Homework hw = JsonConvert.DeserializeObject<Homework>(await h.GetStringAsync(url + "hw/"+i.self+"/"+cc[0].standard+"/"+ cc[0].section+ "/"+DateTime.Today.ToString("dd-MMM-yy")));
                homeWork.InnerText = hw.detail;
                class_.InnerText = cc[0].standard+" - "+cc[0].section;
                date_.InnerText = DateTime.Today.ToString("dd-MMM-yy");
        }

        protected async void classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            DropDownList d = sender as DropDownList;
            string cc = d.SelectedValue;
            Homework hw = JsonConvert.DeserializeObject<Homework>(await h.GetStringAsync(url + "hw/"+i.self+"/" + cc[0] + "/" + cc[4] + "/" + DateTime.Today.ToString("dd-MMM-yy")));
            homeWork.InnerText = hw.detail;
            class_.InnerText = cc;
        }

        protected async void setHW_Click(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            GraphClient g = new GraphClient(new Uri("http://neo4jvm1.cloudapp.net:7474/db/data"));
            g.Connect();
            string cc = class_.InnerText;
            string c= (g.Cypher.Match("(i:`institute`)--(n:`class` {school:\""+i.self+"\",standard:\""+cc[0]+"\",section:\""+cc[4]+"\"})").Where("id(i)="+i.self).Return<string>("id(n)").Results.ToList())[0];
            Homework hw = new Homework { detail = detail.InnerText, class_ = c, on = DateTime.Today.ToString("dd-MMM-yy"), subject = "" };
            await h.PostAsync(url+"hw/",new StringContent(JsonConvert.SerializeObject(hw),System.Text.Encoding.UTF8,"application/json"));
        }
    }
}