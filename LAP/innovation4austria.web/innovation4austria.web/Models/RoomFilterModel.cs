﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class RoomFilterModel
    {
        public List<RoomModel> Rooms { get; set; }

        public FilterModel Filter { get; set; }
    }
}