using System;
using Sfiss.WorkoutAPIService.Section.Model;

namespace Sfiss.WorkoutAPIService.Model
{
    public class Section
    {
        public Guid Guid { get; set; }
        public int Order { get; set; }

        public string Title { get; set; }
        public  SectionType SectionType { get; set; }

        public Completion Completion { get; set; }
    }
}