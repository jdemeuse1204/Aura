using Aura.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules
{
    public class Rule<T, K> where T : class where K : class
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public IWhen<T> When { get; set; }
        public IThen<T, K> Then { get; set; }
    }
}
