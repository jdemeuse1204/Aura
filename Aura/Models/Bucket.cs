using Aura.AddOns;
using System;

namespace Aura.Models
{
    public class Bucket : IBucket
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
