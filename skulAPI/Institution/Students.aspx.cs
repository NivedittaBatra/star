using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using skulAPI.Models;
namespace skulAPI.Institution
{
    public partial class Students : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
                List<Class> cc = JsonConvert.DeserializeObject<List<Class>>(await h.GetStringAsync(url + "class/"+i.self));
                foreach(Class c in cc)
                {
                    classList.Items.Add(new ListItem {Enabled=true,Selected=false,Text=c.standard + " - " + c.section, Value=c.self });
                }
                stuTable.InnerHtml = "";
                StudentOfClassWithId socwi= JsonConvert.DeserializeObject<StudentOfClassWithId>(await h.GetStringAsync(url + "student/"+i.self+"/"+cc[0].standard+"/"+cc[0].section));
                List<Student> ss = socwi.a;
                foreach(Student s in ss)
                {
                    stuTable.InnerHtml = stuTable.InnerHtml +
                    "<tr>" +
                    "<td>" + s.name + "</td>" +
                    "<td>" + s.class_ + "</td>" +
                    "<td>" + s.rollNo + "</td>" +
                    "<td>" + s.admissionNo + "</td></tr>";
                }
        }
        protected async void classList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList d = sender as DropDownList;
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            string c=d.SelectedItem.Text; stuTable.InnerHtml = "";
            StudentOfClassWithId socwi = JsonConvert.DeserializeObject<StudentOfClassWithId>(await h.GetStringAsync(url + "student/"+i.self+"/"+c[0]+"/"+c[4]));
            List<Student> ss = socwi.a;
            foreach (Student s in ss)
            {
                stuTable.InnerHtml = stuTable.InnerHtml +
                "<tr>" +
                "<td>" + s.name + "</td>" +
                "<td>" + s.class_ + "</td>" +
                "<td>" + s.rollNo + "</td>" +
                "<td>" + s.admissionNo + "</td></tr>";
            }
        }

        protected async void addStudent_Click(object sender, EventArgs e)
        {
            string c = classList.SelectedItem.Text;
            string c_ = classList.SelectedValue;
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            await h.PostAsync(url + "student", new StringContent(JsonConvert.SerializeObject(new Student {address=address.Value.Trim(),admissionNo=admnNo.Value.Trim(),blood=blood.Value.Trim(),contact=contact.Value.Trim(),DOB=DOB.Value.Trim(),email=email.Value.Trim(),name=name.Value.Trim(),pass="123",rollNo=rollNo.Value.Trim(),class_=c,class__=c_,school=i.name,school_=i.self }),System.Text.Encoding.UTF8,"application/json"));
        }
    }
}