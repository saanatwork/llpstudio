﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLP.BOL.CustomModels
{
    public class CustomAjaxResponse
    {
        public DateTime dResponseDate { get; set; }
        public int iRespinseInteger { get; set; }
        public bool bResponseBool { get; set; }
        public string sResponseString { get; set; }
    }
}
