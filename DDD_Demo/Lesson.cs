using System;

namespace DDD_Demo
{
    public class Lesson
    {
        /*
         public AppPath AppPathSelectorID { get;  } renamed to be more clear
         public string AppPath { get;  } redundant not needed 
         public string Course { get;  }  removed not needed
         public bool? Published { get;  }   changed from nullable to none nullable default is false.
         public Guid CourseID { get;  } removed for now because I only want a uni directional flow



         
         public bool? IsNewFeature { get;  } changed to none nullable also renamed to be consistant 

        public DateTime CreatedOn { get;  }  audit property not needed here
        public DateTime ModifiedOn { get;  } audit property not needed here
        public Guid CreatedBy { get;  }  audit property not needed here
        public Guid ModifiedBy { get;  } audit property not needed here

        public string CompletedId { get;  } removed not needed (I think not sure yet)

        public bool enabled { get;  } renamed to be consistant 
        public bool IsApplicable { get;  } removed not needed here
        
        public int Type { get;  } changed to int

        public bool ApplicableFlag { get;  } removed not needed
             */

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int LessonNumber { get; private set; }
        public AppPath AppPath { get; private set; }
        public string Description { get; private set; }
        public bool Published { get; private set; }        
        public string ContentURL { get; private set; }
        public Guid? DependentOnLessonId { get; private set; }
        public bool NewFeature { get; private set; }
        public string QuestionField { get; private set; }
        public int CorrectAnswer { get; private set; }
        public string Answer1 { get; private set; }
        public string Answer2 { get; private set; }
        public string Answer3 { get; private set; }
        public string Answer4 { get; private set; }
        public string Answer5 { get; private set; }
        public string Answer6 { get; private set; }
        
        public DateTime? CompletedOn { get; private set; }
        public bool Completed => CompletedOn.HasValue; 

        public bool Enabled { get; private set; }        
        public LessonType Type { get; private set; }                

        public Lesson(Guid id, string name, int lessonNumber, AppPath appPath, string description,
            string contentUrl, Guid? dependentOnLessonId, bool newFeature, string questionField, 
            int correctAnswer, string answer1, string answer2, string answer3, string answer4, 
            string answer5, string answer6, LessonType type, bool published = false, bool enabled = false)
        {
            Id = id;
            Name = name;
            LessonNumber = lessonNumber;
            AppPath = appPath;
            Description = description;
            Published = published;
            ContentURL = contentUrl;
            DependentOnLessonId = dependentOnLessonId;
            NewFeature = newFeature;
            QuestionField = questionField;
            CorrectAnswer = correctAnswer;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
            Answer5 = answer5;
            Answer6 = answer6;
            Enabled = enabled;            
            Type = type;
            NewFeature = newFeature;
        }

        public void Enable()
        {
            this.Enabled = true;
        }

        public void Complete(DateTime date)
        {
            this.CompletedOn = date;
        }
        //need to check domain rules   
        //here I assume you can change a lesson to not
        //new and there is no way to make it new again.
        public void UnNew()
        {
            NewFeature = false;
        }

    }

  
}