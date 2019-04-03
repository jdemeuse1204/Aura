﻿using Aura.AddOns;
using Aura.AddOns.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class Bucket : IBucket
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
