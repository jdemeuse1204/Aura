﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class ClockPeriod
    {
        public ClockPeriod()
        {
            StartTime = DateTime.Now;
        }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}