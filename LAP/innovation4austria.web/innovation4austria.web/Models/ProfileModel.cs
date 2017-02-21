using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class ProfileModel
    {
        public ProfileDataModel ProfileData { get; set; }
        public ProfilePasswordModel ProfilePassword { get; set; }
    }
}