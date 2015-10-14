using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skulAPI.Models
{
    public class Institute
    {
        public string name { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string self { get; set; }
        public bool activated { get; set; }
        public string services { get; set; }
    }
    public class Class
    {
        protected bool Equals(Class other)
        {
            return (standard == other.standard && section== other.section && school==other.school);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Class)obj);
        }
        public override int GetHashCode()
        {
            return (section+school+standard).GetHashCode(); //or id.GetHashCode();
        }
        public string self { get; set; }
        public string section { get; set; }
        public string standard { get; set; }
        public string school { get; set; }
    }
    public class Student
    {
        public string name { get; set; }
        public string self { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string DOB { get; set; }
        public string blood { get; set; }
        public string admissionNo { get; set; }
        public string rollNo { get; set; }
        public string address { get; set; }
        public string school { get; set; }
        public string school_ { get; set; }
        public string class_ { get; set; }
        public string class__ { get; set; }
    }
    public class Subject
    {
        public string self{get;set;}
        public string name { get; set; }
        public string class_ { get; set; }
    }
    public class Staff
    {
        public string email{get;set;}
        public string pass{get;set;}
        public string self { get; set; }
        public string name{get;set;}
        public string DOB{get;set;}
        public string contact{get;set;}
        public string subject{get;set;}
        public string address{get;set;}
        public string school{get;set;}
        public string school_{get;set;}
    }
    public class Event
    {
        public string self{get;set;}
        public string school { get; set; }
        public string desc { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string img { get; set; }
    }
    public class Attendance
    {
        public string self{get;set;}
        public string of { get; set; }
        public string on { get; set; }
        public bool present { get; set; }
    }
    public class Homework
    {
        public string self{get;set;}
        public string class_ { get; set; }
        public string subject { get; set; }
        public string on { get; set; }
        public string detail { get; set; }
    }
    public class Relation
    {
        public string to { get; set; }
        public string type { get; set; }
    }

    public class StudentOfClassWithId
    {
        public List<Student> a { get; set; }
        public List<int> IDs { get; set; }
    }
    public class ClassWithAtt
    {
        public string id { get; set; }
        public string class_ { get; set; }
        public string done { get; set; }
    }
    public class instiStartup
    {
        public string stuAtt { get; set; }
        public string staAtt { get; set; }
        public string eventCount { get; set; }
    }
    public class test
    {
        public string a { get; set; }
    }
}