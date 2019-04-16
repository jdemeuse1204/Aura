using Aura.AddOns;
using System.Collections.Generic;

namespace Aura.Services.Interfaces
{
    public interface IBucketsManager
    {
        void Save(IEnumerable<IBucket> buckets);
        IEnumerable<IBucket> GetBuckets();
    }
}
