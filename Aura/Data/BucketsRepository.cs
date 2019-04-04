using Aura.AddOns.Step;
using Aura.Data.Interfaces;
using Aura.DataAccess.Json;
using Aura.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data
{
    public class BucketsRepository : IBucketsRepository
    {

        private readonly IApplicationSettings ApplicationSettings;
        private readonly IBucketsJsonDataReaderWriter BucketsJsonDataWriter;

        [Inject]
        public BucketsRepository(IApplicationSettings applicationSettings, IBucketsJsonDataReaderWriter bucketsJsonDataWriter)
        {
            ApplicationSettings = applicationSettings;
            BucketsJsonDataWriter = bucketsJsonDataWriter;
        }

        public IEnumerable<IBucket> GetBuckets()
        {
            return BucketsJsonDataWriter.All<Bucket>();
        }

        public void Save(IEnumerable<IBucket> buckets)
        {
            BucketsJsonDataWriter.Write(buckets);
        }
    }
}
