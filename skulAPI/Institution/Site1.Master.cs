using Newtonsoft.Json;
using skulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skulAPI.Institution
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
           // schoolName.InnerText = i.name;
        }
    }
}