using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using skulAPI.Models;
using Newtonsoft.Json;

namespace skulAPI.Institution
{
    public partial class attendance : System.Web.UI.Page
    {
        HttpClient h = new HttpClient();
        string url = "http://kunalsachdeva.azurewebsites.net/api/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            Institute i = JsonConvert.DeserializeObject<Institute>(Session["u"].ToString());
            List<string> dates = new List<string>();
            for (int ii = 0; ii < 10; ii++)
            {
                dates.Add(DateTime.Today.AddDays(-1 * ii).ToString("dd-MMM-yy"));
            }
            string data = await h.GetStringAsync(url + "attendance/"+i.self+"/stu/10");
            List<int> x = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(data);
            data = await h.GetStringAsync(url + "attendance/" + i.self + "/sta/10");
            List<int> x2 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(data);
            Response.Write("<script src=\"../js/jq.js\"></script><script>$(document).ready(function () {var line1 = [['" + dates[0] + "'," + x[0] + "],['" + dates[1] + "'," + x[1] + "],['" + dates[2] + "'," + x[2] + "],['" + dates[3] + "'," + x[3] + "],['" + dates[4] + "'," + x[4] + "],['" + dates[5] + "'," + x[5] + "],['" + dates[6] + "'," + x[6] + "],['" + dates[7] + "'," + x[7] + "],['" + dates[8] + "'," + x[8] + "],['" + dates[9] + "'," + x[9] + "]]; var plot1 = $.jqplot('chart1', [line1], {title: 'Students',axes: {xaxis: {renderer: $.jqplot.DateAxisRenderer}}});});</script>");
            Response.Write("<script>$(document).ready(function () {var line2 = [['" + dates[0] + "'," + x2[0] + "],['" + dates[1] + "'," + x2[1] + "],['" + dates[2] + "'," + x2[2] + "],['" + dates[3] + "'," + x2[3] + "],['" + dates[4] + "'," + x2[4] + "],['" + dates[5] + "'," + x2[5] + "],['" + dates[6] + "'," + x2[6] + "],['" + dates[7] + "'," + x2[7] + "],['" + dates[8] + "'," + x2[8] + "],['" + dates[9] + "'," + x2[9] + "]]; var plot1 = $.jqplot('chart2', [line2], {title: 'Staff',axes: {xaxis: {renderer: $.jqplot.DateAxisRenderer}}});});</script>");
            //Response.Write("<script>$(document).ready(function(){{var e=[[" + x2[0]+","+x2[1]+","+x2[2]+","+x2[3]+","+x2[4] + "]];$.jqplot('chart2',[e],{axes:{xaxis:{renderer:$.jqplot.DateAxisRenderer}}})}});</script>");
        }

        protected void Attendance_Click(object sender, EventArgs e)
        {

        }
    }
}