﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DuesStatus
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string e_posta { get; set; }
        public DateTime tarih { get; set; }
        public int ucret { get; set; }
        public string durum { get; set; }
    }
}