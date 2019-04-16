using Aura.Data.Interfaces;
using Aura.DataAccess.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Data.Text
{
    public class BucketsJsonDataReaderWriter : JsonDataReaderWriter, IBucketsJsonDataReaderWriter
    {
        [Inject]
        public BucketsJsonDataReaderWriter(IApplicationSettings applicationSettings)
            : base(applicationSettings.MainFileDirectory, applicationSettings.BucketsFileName)
        {
        }
    }
}
