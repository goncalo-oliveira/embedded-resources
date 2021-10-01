using System;

namespace System.Reflection
{
    internal class EmbeddedResource : IEmbeddedResource
    {
        public Assembly Assembly { get; set; }
        public string Uri { get; set; }
    }
}
