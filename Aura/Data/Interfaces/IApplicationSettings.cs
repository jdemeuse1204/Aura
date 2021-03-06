﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Data.Interfaces
{
    public interface IApplicationSettings
    {
        string MainFileDirectory { get; }
        string DataFileDirectory { get; }
        string DataFileName { get; }
        string SessionFileName { get; }
        string SessionFileDirectory { get; }
        string AddOnsFileDirectory { get; }
        string BucketsFileName { get; }
        string RulesFileName { get; }
    }
}
