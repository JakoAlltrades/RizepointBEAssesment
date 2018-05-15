using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizepointBEAssesment.Models
{
    public class User
    {

        private int ID { get; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public List<string> interests { get; set; }

        public User(string fname, string lname, string email, List<string> interests)
        {
            this.fname = fname;
            this.lname = lname;
            this.email = email;
            this.interests = interests;
        }
    }
}