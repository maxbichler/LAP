using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public int Role_ID { get; set; }
        public int Email { get; set; }
        public byte[] Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}