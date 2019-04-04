using Aura.AddOns.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data.Interfaces
{
    public interface IBucketsRepository
    {
        void Save(IEnumerable<IBucket> buckets);
        IEnumerable<IBucket> GetBuckets();
    }
}
