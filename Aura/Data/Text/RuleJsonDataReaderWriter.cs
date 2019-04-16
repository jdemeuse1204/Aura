using Aura.Data.Interfaces;
using Aura.DataAccess.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Data.Text
{
    public class RuleJsonDataReaderWriter : JsonDataReaderWriter, IRuleJsonDataReaderWriter
    {
        [Inject]
        public RuleJsonDataReaderWriter(IApplicationSettings applicationSettings)
            : base(applicationSettings.MainFileDirectory, applicationSettings.RulesFileName)
        {
        }
    }
}
