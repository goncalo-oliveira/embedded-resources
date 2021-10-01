using System;

namespace System.Reflection
{
    /// <summary>
    /// An embedded resource reference
    /// </summary>
    public interface IEmbeddedResource
    {
        /// <summary>
        /// The assembly where the embedded resource is located
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// The embedded resource absolute Uri
        /// </summary>
        string Uri { get; }
    }
}
