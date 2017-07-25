using System;
using System.Linq;
using DDD_Demo.Domain;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace DDD_Demo.Tests
{
   public class SectionTests
    {
        [Theory,AutoData]
        public void canGetSectionCourses(Section section)
        {
            Assert.True(section.Courses.Count==3);
        }
        [Theory,AutoData]
        public void canCalculateCompletionPercent(Section section)
        {
            var now = DateTime.Now;
            section.Courses.First().Lessons.ForEach(x=> x.Complete(now));
            Assert.True(section.CompletionPercent == .33M);
        }
    }
}
