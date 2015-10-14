using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Neo4jClient.ApiModels;
using System.Security.Cryptography;
using skulAPI.Models;
using System.Web.Http;
using Neo4jClient;
using System.Threading.Tasks;
using System.Text;

namespace skulAPI.Controllers
{
    public class SchoolController : ApiController
    {
        HttpClient h = new HttpClient();
        GraphClient g = new GraphClient(new Uri("http://neo4jvm1.cloudapp.net:7474/db/data"));
        string uri = "http://neo4jvm1.cloudapp.net:7474/db/data/";
        [HttpGet]
        [Route("api/login/{u}/{p}/{type}")]
        public IHttpActionResult Login(string u, string p, string type)
        {
            p = password(p);
            g.Connect();
            List<Institute> ii = g.Cypher.Match("(user:`institute` {email:\"" + u + "\",pass:\"" + p + "\"})").ReturnDistinct<Institute>("user").Results.ToList();
            List<Student> ss = g.Cypher.Match("(user:`student` {email:\"" + u + "\",pass:\"" + p + "\"})").ReturnDistinct<Student>("user").Results.ToList();
            if (type == "sta")
            {
                if (ii.Count() > 0) return Ok(ii[0]);
                else return Ok(new Institute { name = "N" });
            }
            else if (type == "stu")
            {
                if (ss.Count() > 0) return Ok(ss[0]);
                else return Ok(new Student { name = "N" });
            }
            else return Ok();
        }
        [HttpGet]
        [Route("api/insti/inception/{id}")]
        public IHttpActionResult InstiStartup(string id)
        {
            g.Connect();
            IEnumerable<Attendance> a = g.Cypher.Match("(n:`institute` )--(s:`student`)--(a:`attendance` {present:true,on:\"" + DateTime.Today.ToString("dd-MMM-yy") + "\"})").Where("id(n)=" + id).ReturnDistinct<Attendance>("a").Results;
            string studentAtt = a.Count().ToString();
            string totalStu = (g.Cypher.Match("(n:`institute` )--(s:`student`)").Where("id(n)=" + id).ReturnDistinct<int>("count(distinct(s))").Results.ToList())[0].ToString();
            a = g.Cypher.Match("(n:`institute` )--(s:`staff`)--(a:`attendance` {present:true,on:\"" + DateTime.Today.ToString("dd-MMM-yy") + "\"})").Where("id(n)=" + id).ReturnDistinct<Attendance>("a").Results;
            string staffAtt = a.Count().ToString();
            string totalStaff = (g.Cypher.Match("(n:`institute` )--(s:`staff`)").Where("id(n)=" + id).ReturnDistinct<int>("count(distinct(s))").Results.ToList())[0].ToString();
            IEnumerable<Event> e = g.Cypher.Match("(n:`event`)--(m:`institute`)").Where("id(m)=" + id).ReturnDistinct<Event>("n").Results;
            string eventCount = e.Count().ToString();
            return Ok(new instiStartup { eventCount = eventCount, staAtt = staffAtt + "/" + totalStaff, stuAtt = studentAtt + "/" + totalStu });
        }
        [HttpPost]
        [Route("api/insti/")]
        public async Task<IHttpActionResult> createSchoo(Institute a)
        {
            a.pass = password(a.pass);
            g.Connect();
            NodeReference<Institute> node = g.Create(a);
            long x = node.Id;
            a.self = x.ToString();
            g.Update<Institute>(node, a);
            await h.PostAsync(uri + "node/" + x + "/labels", new StringContent("\"institute\""));
            return Ok(a);
        }
        [HttpPut]
        [Route("api/insti/")]
        public IHttpActionResult UpdateSchool(Institute a)
        {
            a.pass = password(a.pass);
            g.Connect();
            NodeReference<Institute> node = new NodeReference<Institute>(long.Parse(a.self), g);
            g.Update<Institute>(node, a);
            return Ok();
        }
        [HttpPost]
        [Route("api/student/")]
        public async Task<IHttpActionResult> createStu(Student a)
        {
            a.pass = password(a.pass);
            g.Connect();
            NodeReference<Student> node = g.Create(a);
            string x = node.Id.ToString();
            a.self = x;
            g.Update<Student>(node, a);
            await h.PostAsync(uri + "node/" + x + "/labels", new StringContent("\"student\""));
            createRelationship(x, a.school_, "school");
            createRelationship(a.school_, x, "student");
            createRelationship(x, a.class__, "class");
            createRelationship(a.class__, x, "student_c");
            return Ok(a);
        }
        [HttpPost]
        [Route("api/staff/")]
        public async Task<IHttpActionResult> createSta(Staff a)
        {
            a.pass = password(a.pass);
            g.Connect();
            NodeReference<Staff> node = g.Create(a);
            string x = node.Id.ToString();
            a.self = x.ToString();
            g.Update<Staff>(node, a);
            await h.PostAsync(uri + "node/" + x + "/labels", new StringContent("\"staff\""));
            createRelationship(x, a.school_, "school");
            createRelationship(a.school_, x, "staff");
            return Ok(a);
        }
        [HttpPost]
        [Route("api/class/")]
        public async Task<IHttpActionResult> createClass(Class a)
        {
            a.standard = a.standard.ToUpper();
            g.Connect();
            NodeReference<Class> node = g.Create(a);
            long x = node.Id;
            a.self = x.ToString();
            g.Update<Class>(node, a);
            await h.PostAsync(uri + "node/" + x + "/labels", new StringContent("\"class\""));

            Relation r = new Relation { to = uri + "node/" + a.school, type = "institute" };
            await h.PostAsync(uri + "node/" + x + "/relationships", new StringContent(JsonConvert.SerializeObject(r).ToString(), Encoding.UTF8, "application/json"));

            r = new Relation { to = uri + "node/" + x, type = "class" };
            await h.PostAsync(uri + "node/" + a.school + "/relationships", new StringContent(JsonConvert.SerializeObject(r).ToString(), Encoding.UTF8, "application/json"));
            return Ok(a);
        }
        [HttpPost]
        [Route("api/event/")]
        public async Task<IHttpActionResult> createEvent(Event a)
        {
            g.Connect();
            NodeReference<Event> node = g.Create(a);
            string x = node.Id.ToString();
            a.self = x.ToString();
            g.Update<Event>(node, a);
            await h.PostAsync(uri + "node/" + x + "/labels", new StringContent("\"event\""));

            createRelationship(x, a.school, "event");
            createRelationship(a.school, x, "school_event");

            return Ok(a);
        }
        [HttpPost]
        [Route("api/hw/")]
        public async Task<IHttpActionResult> createHW(Homework a)
        {
            g.Connect();
            NodeReference<Homework> node = g.Create(a);
            string x = node.Id.ToString();
            a.self = x.ToString();
            g.Update<Homework>(node, a);
            await h.PostAsync(uri + "node/" + x + "/labels", new StringContent("\"homework\""));

            createRelationship(x, a.class_, "homework");
            createRelationship(a.class_, x, "class_hw");

            return Ok(a);
        }
        [HttpPost]
        [Route("api/attendance/")]
        public async Task<IHttpActionResult> markAttendance(List<Attendance> ap)
        {
            g.Connect();
            foreach (Attendance a in ap)
            {
                List<Attendance> q = g.Cypher.Match("(n:`attendance` {of:\"" + a.of + "\",on:\"" + a.on + "\"})").ReturnDistinct<Attendance>("n").Results.ToList();
                if (q.Count == 0)
                {
                    NodeReference<Attendance> node = g.Create(a);
                    string x = node.Id.ToString();
                    a.self = x;
                    g.Update<Attendance>(node, a);
                    await h.PostAsync(uri + "node/" + x + "/labels", new StringContent("\"attendance\""));
                    createRelationship(x, a.of, "attendance");
                    createRelationship(a.of, x, "attendance");
                }
                else
                {
                    g.Cypher.Match("(n:`attendance` {of:\"" + a.of + "\",on:\"" + a.on + "\"})").Set("n.present=" + a.present.ToString()).ExecuteWithoutResults();
                }
            }
            return Ok();
        }
        [HttpGet]
        [Route("api/attendance/{id}/{type}/{days}")]
        public IHttpActionResult AttendanceCall(string id, string type, string days)
        {
            g.Connect();
            List<int> count = new List<int>();
            List<string> dates = new List<string>();
            for (int i = 0; i < Int32.Parse(days); i++)
            {
                dates.Add(DateTime.Today.AddDays(-1 * i).ToString("dd-MMM-yy"));
            }
            if (type == "stu")
            {
                foreach (string date in dates)
                {
                    count.Add(g.Cypher.Match("(n:`attendance` {present:true,on:\"" + date + "\"})--(m:`student`)--(i:`institute`) ").Where("id(i)=" + id).ReturnDistinct<Attendance>("n").Results.Count());
                }
            }
            else if (type == "sta")
            {
                foreach (string date in dates)
                {
                    count.Add(g.Cypher.Match("(n:`attendance` {present:true,on:\"" + date + "\"})--(m:`staff`)--(i:`institute`) ").Where("id(i)=" + id).ReturnDistinct<Attendance>("n").Results.Count());
                }
            }
            return Ok(count);
        }
        [HttpGet]
        [Route("api/attendance/{id}/{days}")]
        public IHttpActionResult AttendanceCall1(string id,string days)
        {
            g.Connect();
            List<bool> att = new List<bool>();
            List<string> dates = new List<string>();
            for (int i = 0; i < Int32.Parse(days); i++)
            {
                dates.Add(DateTime.Today.AddDays(-1 * i).ToString("dd-MMM-yy"));
            }
            foreach (string date in dates)
            {
                var a=g.Cypher.Match("(n:`attendance` {of:\""+id+"\",present:true,on:\"" + date + "\"})--(m:`student`)--(i:`institute`) ").ReturnDistinct<Attendance>("n").Results.Count();
                if (a > 0) att.Add(true); else att.Add(false);
            }
            return Ok(att);
    }
    [HttpGet]
    [Route("api/student/{id}/{standard}/{section}")]
    public IHttpActionResult getStu(string id, string standard, string section)
    {
        standard = standard.ToUpper();
        g.Connect();
        IEnumerable<Student> s = g.Cypher.Match("(i:`institute`)--(l:`class` {school:\"" + id + "\",standard:\"" + standard + "\",section:\"" + section + "\"})--(n:`student`)").ReturnDistinct<Student>("n").Results;
        IEnumerable<int> s2 = g.Cypher.Match("(i:`institute`)--(l:`class` {school:\"" + id + "\",standard:\"" + standard + "\",section:\"" + section + "\"})--(n:`student`)").ReturnDistinct<int>("id(n)").Results;

        return Ok(new StudentOfClassWithId { a = s.ToList(), IDs = s2.ToList() });
    }
    [HttpGet]
    [Route("api/student/{id}/")]
    public IHttpActionResult getAllStu(string id)
    {
        g.Connect();
        IEnumerable<Student> s = g.Cypher.Match("(i:`institute`)--(n:`student`)").Where("id(i)=" + id).Return<Student>("n").Results;
        return Ok(s);
    }
    [HttpGet]
    [Route("api/classWithAtt/{id}")]
    public IHttpActionResult getClassWithAtt(string id)
    {
        g.Connect();
        List<Class> s = g.Cypher.Match("(i:`institute`)--(n:`class`)--(s:`student`)--(o:`attendance` {on:\"" + DateTime.Today.ToString("dd-MMM-yy") + "\"})").Where("id(i)=" + id).ReturnDistinct<Class>("n").Results.ToList();
        List<Class> s2 = g.Cypher.Match("(i:`institute`)--(n:`class`)").Where("id(i)=" + id).ReturnDistinct<Class>("n").Results.ToList();
        List<ClassWithAtt> cwa = new List<ClassWithAtt>();
        List<ClassWithAtt> cwa_ = new List<ClassWithAtt>();
        foreach (Class c in s)
        {
            cwa.Add(new ClassWithAtt { class_ = c.standard + " - " + c.section, done = "Done" });
        }
        foreach (Class c in s2)
        {
            if (!s.Contains(c)) cwa.Add(new ClassWithAtt { class_ = c.standard + " - " + c.section, done = "Pending" });
        }
        return Ok(cwa);
    }
    [HttpGet]
    [Route("api/class/{id}")]
    public IHttpActionResult getClass(string id)
    {
        g.Connect();
        List<Class> s = g.Cypher.Match("(i:`institute`)--(n:`class`)").Where("id(i)=" + id).ReturnDistinct<Class>("n").Results.ToList();
        return Ok(s);
    }
    [HttpGet]
    [Route("api/staff/{id}")]
    public IHttpActionResult getStaff(string id)
    {
        g.Connect();
        List<Staff> s = g.Cypher.Match("(i:`institute`)--(n:`staff`)").Where("id(i)=" + id).ReturnDistinct<Staff>("n").Results.ToList();
        return Ok(s);
    }
    [HttpGet]
    [Route("api/hw/{id}/{standard}/{section}/{date}")]
    public IHttpActionResult getHW(string id, string standard, string section, string date)
    {
        g.Connect();
        if (date == null || date.Trim() == "") date = DateTime.Today.ToString("dd-MMM-yy");
        List<Homework> s = g.Cypher.Match("(i:`institute`)--(k:`class`  {section:\"" + section + "\",standard:\"" + standard + "\"})--(n:`homework` {on:\"" + date + "\"})").Where("id(i)=" + id).Return<Homework>("n").Results.ToList();
        if (s.Count > 0) return Ok(s[0]);
        else return Ok(new Homework());
    }
    [HttpGet]
    [Route("api/event/{id}")]
    public IHttpActionResult getEvents(string id)
    {
        g.Connect();
        List<Event> s = g.Cypher.Match("(i:`institute`)--(n:`event`)").Where("id(i)=" + id).ReturnDistinct<Event>("n").Results.ToList();
        return Ok(s);
    }
    public string password(string a)
    {
        byte[] p = Encoding.ASCII.GetBytes("$«" + a + "ª¾");
        p = MD5.Create().ComputeHash(p);
        return Encoding.ASCII.GetString(p);
    }
    public async void createRelationship(string from, string to, string type)
    {
        Relation r = new Relation { to = uri + "node/" + to, type = type };
        await h.PostAsync(uri + "node/" + from + "/relationships", new StringContent(JsonConvert.SerializeObject(r).ToString(), Encoding.UTF8, "application/json"));
    }
}
}
