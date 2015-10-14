using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;
using skulAPI.Models;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace skulAPI
{
    public partial class _default : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addSchool_Click(object sender, EventArgs e)
        {
            try {
                Institute i = new Institute { activated = false, contact = contact.Value.Trim(), email = email.Value.Trim(), location = address.Value.Trim(), name = schoolName.Value.Trim(), pass = "123", services = "~" };
                h.PostAsync(url + "insti", new StringContent(JsonConvert.SerializeObject(i), System.Text.Encoding.UTF8, "application/json"));
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = false;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("user@gmail.com", "password");
                MailMessage mm = new MailMessage("noreply@edjourn.com", email.Value.Trim());
                mm.Subject = "Making " + schoolName.Value.Trim() + " smarter - Edjourn";
                mm.Body = "We have received your request to make " + schoolName.Value.Trim() + " smarter. We will get back to you soon!";
                mm.BodyEncoding = System.Text.UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(mm);
            }
            catch { }
            }
    }
}