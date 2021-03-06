﻿using System.Linq;
using Lurchsoft.FileData;
using Lurchsoft.FileData.Reading;
using NUnit.Framework;

// ReSharper disable PossibleMultipleEnumeration
namespace Lurchsoft.FileDataTests.Reading
{
    [TestFixture]
    public class EmbeddedTextFileSourceTests
    {
        [Test]
        public void GetTextFile_ShouldReturnNull_WhenFileDoesNotExist()
        {
            Assert.That(new EmbeddedTextFileSource().GetTextFile("does not exist"), Is.Null);
        }

        [Test]
        public void GetTextFile_ShouldReturnDisposable_WhenFileExists()
        {
            Assert.That(new EmbeddedTextFileSource().GetTextFile(EmbeddedFiles.MediumFileName), Is.Not.Null);
        }

        [Test]
        public void GetTextFile_ShouldReturnFileWithSeveralLines()
        {
            var file = new EmbeddedTextFileSource().GetTextFile(EmbeddedFiles.MediumFileName);
            var lines = file.ReadLines();
            Assert.That(lines.Count(), Is.GreaterThan(10));
        }

        [Test]
        public void GetTextFile_ShouldReturnFileWhoseLinesCanBeEnumeratedMultipleTimes()
        {
            var file = new EmbeddedTextFileSource().GetTextFile(EmbeddedFiles.MediumFileName);
            var lines = file.ReadLines();
            int count1 = lines.Count();
            int count2 = lines.Count();
            Assert.That(count1, Is.EqualTo(count2));
        }
    }
}
