using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD_Demo.Domain
{
    public class Entity
    {
        public Guid Id { get; protected set; }
    }
    public class Course:Entity
    {
        /*
            
            public AppPath AppPathSelectorID { get; private set; } renamed to be more clear

            public DateTime CreatedOn { get;  } not part of the entity 
            public DateTime ModifiedOn { get;  } not part of the entity 
            public Guid CreatedBy { get;  } not part of the entity 
            public Guid ModifiedBy { get;  } not part of the entity 
        
            public List<Lesson> items { get;  } renamed to be more descriptive 

            public int Type { get;  } changed to enum 

            public bool IsApplicable { get;  } does not belong on this entity (not its responsibility)

            public Section SectionID { get;  } removed not sure why yet for now its because I want a single directional nav though the entity
             */
        
        public string Name { get; private set; }
        public int CourseNumber { get; private set; }
        public AppPath AppPath { get; private set; }
        public string Description { get; private set; }
        public string CourseIconURL { get; private set; }
        public String ImageURL { get; private set; }
        public CourseType Type { get; private set; }

        public bool Completed => Lessons.All(c => c.Completed);
        public decimal CompletionPercent => Lessons.Count(c => c.Completed) /(decimal) Lessons.Count();

        public DateTime? RecentLessonCompletionDate
        {
            get
            {
                return Lessons.OrderByDescending(x => x.CompletedOn).First().CompletedOn;
            }
        }
        public List<Lesson> Lessons { get; }

        public Course(Guid id, string name, int courseNumber, AppPath appPath,
            string description, string courseIconUrl, string imageUrl, CourseType type, List<Lesson> lessons)
        {
            Id = id;
            Name = name;
            CourseNumber = courseNumber;
            AppPath = appPath;
            Description = description;
            CourseIconURL = courseIconUrl;
            ImageURL = imageUrl;
            Type = type;
            Lessons = lessons;
        }

        public void Update(Course c)
        {
            this.Name = c.Name;
            this.Description = c.Description;
            this.CourseNumber = c.CourseNumber;
            this.CourseIconURL = c.CourseIconURL;
            //map all properties
        }
        public void AddLesson(Lesson lesson)
        {
            this.Lessons.Add(lesson);
        }

        public void RemoveLesson(Lesson lesson)
        {
            this.Lessons.Remove(lesson);
        }

    }

}
