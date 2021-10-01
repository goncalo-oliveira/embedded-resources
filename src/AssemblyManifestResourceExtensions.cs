using System;

namespace System.Reflection
{
    public static class AssemblyManifestResourceExtensions
    {
        /// <summary>
        /// Retrieves a reference to the given embedded resource
        /// </summary>
        /// <param name="assembly">The assembly to retrieve the resource from</param>
        /// <param name="resourceUri">The resource uri; if prefixed with '~' it will prepend the assembly name</param>
        /// <returns>An embedded resource reference</returns>
        public static IEmbeddedResource GetEmbeddedResource( this Assembly assembly, string resourceUri )
        {
            var resource = new EmbeddedResource
            {
                Assembly = assembly
            };

            if ( resourceUri.StartsWith( "~/" ) )
            {
                // append assembly name to resource uri
                resource.Uri = string.Concat( resource.Assembly.GetName().Name
                        , "."
                        , resourceUri.Substring( 2 ) );
            }
            else
            {
                // use absolute uri
                resource.Uri = resourceUri;
            }

            // normalize uri
            resource.Uri = resource.Uri.Replace( '/', '.' ).Trim( '.' );

            return ( resource );
        }
    }
}
