using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CompanyDetailModel
    {
        public CompanyModel Company { get; set; }

        public List<ProfileDataModel> Portalusers { get; set; }
    }
}