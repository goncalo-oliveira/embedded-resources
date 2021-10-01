using System;
using System.Reflection;
using Xunit;

namespace embedded_tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAbsolute()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resource = assembly.GetEmbeddedResource( "embedded_tests/Embedded/file1.txt" );

            Assert.Equal( assembly, resource.Assembly );

            var content = resource.ReadAsString();

            Assert.NotNull( content );
            Assert.Equal( "file1", content );
        }

        [Fact]
        public void TestRelative()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resource = assembly.GetEmbeddedResource( "~/Embedded/file1.txt" );

            Assert.Equal( assembly, resource.Assembly );

            var content = resource.ReadAsString();

            Assert.NotNull( content );
            Assert.Equal( "file1", content );
        }
    }
}
