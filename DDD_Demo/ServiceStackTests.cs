using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace DDD_Demo
{
   public class ServiceStackTests
    {
        [Theory, AutoData]
        public void canCreateCourse(CreateCourseRequest req, Section section)
        {  
            //Seed data
            DbRepository<Section>._db.Add(section);
            //Arrange
            var sut = new ServiceStack();
            req.SectionId = section.Id;

            //Act
            sut.CreateCourse(req);

            //Assert
            var actual = DbRepository<Section>._db.Count == 1;
            Assert.True(actual);
        }

        [Theory, AutoData]
        public void canCreateLesson(CreateLessonRequest req,Section section)
        {
            //Seed data
            DbRepository<Section>._db.Add(section);

            //Arrange
            var sut =new ServiceStack();
            var s = DbRepository<Section>._db.First();
            var c = s.Courses.First();
            var cur = c.Lessons.Count;
            req.CourseId = c.Id;
            req.SectionId = section.Id;
            
            //Act
            sut.CreateLesson(req);

            //Assert
            var expected = cur + 1;
            var actual = DbRepository<Section>._db.First().Courses.First().Lessons.Count;
            Assert.Equal(expected,actual);
        }
        [Theory, AutoData]
        public void canGetCourse(GetCourseRequest req,Section section)
        {
            //Seed data
            DbRepository<Section>._db.Add(section);

            //Arrange
            var sut =new ServiceStack();
            var s = DbRepository<Section>._db.First();
            var c = s.Courses.First();            
            req.CourseId = c.Id;
            req.SectionId = section.Id;

            //Act
            var actual = sut.GetCourse(req);

            //Assert            
            var expected = c;
            Assert.Equal(expected,actual);
        }

        
    }
}
