using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD_Demo
{
    public class Section
    {
        /*
         public bool IsApplicable { get;  } removed because it does not belong on this entity
        
        private DateTime CreatedOn { get; set; } not part of the entity 
        private DateTime ModifiedOn { get; set; } not part of the entity 
        private Guid CreatedBy { get; set; } not part of the entity 
        private Guid ModifiedBy { get; set; } not part of the entity 
        
            
        
        private string Feature { set; get; } renamed to something more descriptive 
        private string AppPath { set; get; }  removed becaues it was redundant 
        private decimal CompletionPercent { get; set; } chagned to function
        private bool Completed { get; set; } changed to function
        
        private string RecentLessonCompletionDate { get; set; } changed to function 
        public List<Course> items { get; } renamed to be more descriptive 

        public int Type { get;  } changed to enum
             
             */
        public Guid Id { get; }
        public string Name { get; private set; }
        public int SectionNumber { get; private set; }
        public AppPath AppPath { get; private set; }
        public string Description { get; private set; }
        public SectionType Type { get; private set; }
        public bool Featured { get; private set; }
        public List<Course> Courses { get; private set; }

        //these are the same as the ones on course
        //this is just the long way to do it
        public decimal CompletionPercent
        {
            get
            {
                return Math.Round(Courses.Count(x => x.Completed) / (decimal)Courses.Count(),2) ;
            }
        }
        public DateTime? MostRecentLessonCompletedOn
        {
            get
            {
                return Courses.OrderByDescending(x => x.RecentLessonCompletionDate).First().RecentLessonCompletionDate;
            }
        }

        public bool Completed => Courses.All(x => x.Completed);

        public Section(Guid id, string name, int sectionNumber, AppPath appPath, string description,
            SectionType type, List<Course> courses, bool featured=false)
        {
            Id = id;
            Name = name;
            SectionNumber = sectionNumber;
            AppPath = appPath;
            Description = description;
            Type = type;
            Featured = featured;
            Courses = courses;
        }

        public void Update(Section s)
        {
            Name = s.Name;
            SectionNumber = s.SectionNumber;
            AppPath = s.AppPath;
            Description = s.Description;
            Type = s.Type;
            Featured = s.Featured;
        }

        public void AddCourse(Course c)
        {
            Courses.Add(c);
        }

        public void RemoveCourse(Course c)
        {
            Courses.Remove(c);
        }

    }

  

}