using System;
using System.IO;
using Xunit;

namespace Lecture01.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_given_no_input_prints_Hello_World()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Program.Main(null);
            var actual = writer.GetStringBuilder().ToString().Trim();

            // Assert
            Assert.Equal("Hello World!", actual);
        }
    }
}
