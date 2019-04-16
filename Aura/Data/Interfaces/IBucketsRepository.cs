using Aura.AddOns;
using System.Collections.Generic;

namespace Aura.Data.Interfaces
{
    public interface IBucketsRepository
    {
        void Save(IEnumerable<IBucket> buckets);
        IEnumerable<IBucket> GetBuckets();
    }
}
