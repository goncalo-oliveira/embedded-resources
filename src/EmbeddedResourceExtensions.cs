using System;
using System.IO;
using System.Threading.Tasks;

namespace System.Reflection
{
    public static class EmbeddedResourceExtensions
    {
        /// <summary>
        /// Loads the embedded resource
        /// </summary>
        /// <returns>The resource stream; null if not found or not visible</returns>
        public static Stream GetStream( this IEmbeddedResource resource )
            => resource.Assembly.GetManifestResourceStream( resource.Uri );

        /// <summary>
        /// Reads the embedded resource as a string
        /// </summary>
        /// <returns>The embedded resource content; null if not found or not visible</returns>
        public static string ReadAsString( this IEmbeddedResource resource )
            => ReadAsString( resource, Text.Encoding.UTF8 );

        /// <summary>
        /// Reads the embedded resource as a string
        /// </summary>
        /// <returns>The embedded resource content; null if not found or not visible</returns>
        public static Task<string> ReadAsStringAsync( this IEmbeddedResource resource )
            => ReadAsStringAsync( resource, Text.Encoding.UTF8 );

        /// <summary>
        /// Reads the embedded resource as a string
        /// </summary>
        /// <param name="encoding">The character encoding to use</param>
        /// <returns>The embedded resource content; null if not found or not visible</returns>
        public static string ReadAsString( this IEmbeddedResource resource, Text.Encoding encoding )
        {
            using ( var stream = GetStream( resource ) )
            {
                if ( stream == null )
                {
                    return ( null );
                }

                using ( var reader = new StreamReader( stream, encoding ) )
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Reads the embedded resource as a string
        /// </summary>
        /// <param name="encoding">The character encoding to use</param>
        /// <returns>The embedded resource content; null if not found or not visible</returns>
        public static async Task<string> ReadAsStringAsync( this IEmbeddedResource resource, Text.Encoding encoding )
        {
            using ( var stream = GetStream( resource ) )
            {
                if ( stream == null )
                {
                    return ( null );
                }

                using ( var reader = new StreamReader( stream, encoding ) )
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}
