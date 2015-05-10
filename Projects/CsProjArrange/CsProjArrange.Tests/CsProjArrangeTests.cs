using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CsProjArrange.Tests
{
    [TestFixture]
    public class CsProjArrangeTests
    {
        [Test]
        public void Arrange_with_arrangeOptionsNone_should_output_expected_csproj()
        {
            var target = new CsProjArrange();

            target.Arrange(@".\TestData\CsProjArrangeInput.csproj",
                @"CsProjArrangeActualDefaultOutput.csproj", stickyElementNames: null, 
                sortAttributes: null, options: CsProjArrange.ArrangeOptions.None);

            byte[] expectedBytes = File.ReadAllBytes(@".\TestData\CsProjArrangeExpectedDefaultOutput.csproj");
            byte[] actualBytes = File.ReadAllBytes(@"CsProjArrangeActualDefaultOutput.csproj");

            actualBytes.Should().Equal(expectedBytes);
        }

        [Test]
        public void Arrange_with_arrangeOptionsCombineRootElements_should_output_expected_csproj()
        {
            var target = new CsProjArrange();

            target.Arrange(@".\TestData\CsProjArrangeInput.csproj",
                @"arrangedOutput.csproj", stickyElementNames: null,
                sortAttributes: null, options: CsProjArrange.ArrangeOptions.CombineRootElements);

            byte[] expectedBytes = File.ReadAllBytes(@".\TestData\CsProjArrangeExpectedArrangeOptionsCombineRootElementsOutput.csproj");
            byte[] actualBytes = File.ReadAllBytes(@"arrangedOutput.csproj");

            actualBytes.Should().Equal(expectedBytes);
        }

        //[Test]
        //public void Arrange_combineRootElements_should_combine_rootElements()
        //{
        //    var csproj = XDocument.Parse(TestData.TestData.CsProjArrangeInput);

        //    var target = new CsProjArrange();

        //    // Act
        //    target.Arrange(csproj, null, null, CsProjArrange.ArrangeOptions.CombineRootElements);

        //    // Assert
        //    csproj.ToString().Should().Be(TestData.TestData.CsProjArrangeExpectedArrangeOptionsCombineRootElementsOutput);
        //}

    }
}
