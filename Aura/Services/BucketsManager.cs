using Aura.AddOns;
using Aura.Data.Interfaces;
using Aura.Services.Interfaces;
using Ninject;
using System.Collections.Generic;

namespace Aura.Services
{
    public class BucketsManager : IBucketsManager
    {
        private IBucketsRepository BucketsRepository;

        [Inject]
        public BucketsManager(IBucketsRepository bucketsRepository)
        {
            BucketsRepository = bucketsRepository;
        }

        public void Save(IEnumerable<IBucket> buckets)
        {
            BucketsRepository.Save(buckets);
        }

        public IEnumerable<IBucket> GetBuckets()
        {
            return BucketsRepository.GetBuckets();
        }
    }
}
