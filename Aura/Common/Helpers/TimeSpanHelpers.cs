using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.Common.Helpers
{
    public static class TimeSpanHelpers
    {
        public static TimeSpan Sum(IEnumerable<TimeSpan> spans)
        {
            return new TimeSpan(spans.Select(w => w.Ticks).Sum());
        }
    }
}
