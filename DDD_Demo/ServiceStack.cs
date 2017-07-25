using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Demo
{
    public class CreateLessonRequest
    {
        public CreateLessonRequest(Guid sectionId, Guid courseId, Lesson lesson)
        {
            SectionId = sectionId;
            CourseId = courseId;
            Lesson = lesson;
        }

        public Guid SectionId { get;  set; }
        public Guid CourseId { get;  set; }
        public Lesson Lesson { get;  set; }
    }

    public class ServiceStack
    {
        

        public ServiceStack()
        {
        
        }
        public void CreateCourse(CreateCourseRequest req)
        {
            var s = DbRepository<Section>.Get(req.SectionId);
            var course = new Course(Guid.NewGuid(),req.Name,req.CourseNumber,req.AppPath,req.Description,req.CourseIconURL,req.ImageURL,req.Type,new List<Lesson>());
            s.Courses.Add(course);
            DbRepository<Section>.Save(s);
        }

        public Course GetCourse(GetCourseRequest req)
        {
           return DbRepository<Section>.Get(req.SectionId).Courses.Find(x=>x.Id==req.CourseId);
        }

        public void CreateLesson(CreateLessonRequest req)
        {
            var s = DbRepository<Section>.Get(req.SectionId);
            s.Courses.Find(x=>x.Id== req.CourseId).Lessons.Add(req.Lesson);
        }
    }

    public class GetCourseRequest
    {
        public Guid SectionId { get; set; }
        public Guid CourseId { get; set; }
    }
    public class CreateCourseRequest
    {
        public Guid SectionId { get; set; }
        public string Name { get;  set; }
        public int CourseNumber { get;  set; }
        public AppPath AppPath { get;  set; }
        public string Description { get;  set; }
        public string CourseIconURL { get;  set; }
        public String ImageURL { get;  set; }
        public CourseType Type { get;  set; }        
    }
}
