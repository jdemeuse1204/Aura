using Aura.Data.Interfaces;
using Aura.Models;
using Aura.Models.Attributes;
using Aura.Rules.Interfaces;
using Aura.Rules.When;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Aura.Data
{
    public class RuleRepository : IRuleRepository
    {
        private readonly IRuleJsonDataReaderWriter RuleJsonDataReaderWriter;

        [Inject]
        public RuleRepository(IRuleJsonDataReaderWriter ruleJsonDataReaderWriter)
        {
            RuleJsonDataReaderWriter = ruleJsonDataReaderWriter;
        }

        public void Save(IRule rule)
        {
            RuleJsonDataReaderWriter.Write(rule);
        }

        public IEnumerable<T> GetAllRules<T>() where T : class, IRule, new()
        {
            return RuleJsonDataReaderWriter.All<T>();
        }

        public bool RulesExist()
        {
            return RuleJsonDataReaderWriter.HasData();
        }

        public IEnumerable<string> GetWhenProperties()
        {
            var properties = GetRuleFilterableProperties(typeof(WindowsProcess));
            var result = new List<string>();

            foreach (var property in properties)
            {
                var ruleFilterable = property.PropertyType.GetCustomAttribute<RuleFilterable>();

                if (ruleFilterable != null)
                {
                    // No functionality here yet
                    continue;
                }

                result.Add(property.Name);
            }

            return result;
        }

        public IEnumerable<string> GetWhenRuleNames()
        {
            return new List<string>
            {
                nameof(PropertyContains<object>),
                nameof(PropertyEquals<object>),
                nameof(PropertyEqualsIgnoreCase<object>),
                nameof(PropertyEqualsRegex<object>)
            };
        }

        private IEnumerable<PropertyInfo> GetRuleFilterableProperties(Type type)
        {
            return type.GetProperties().Where(w => w.GetCustomAttribute<RuleFilterable>() != null);
        }
    }
}
