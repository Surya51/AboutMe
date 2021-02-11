using System;
using System.Collections.Generic;
using System.Text;

namespace AboutMe.Domain.Entities
{
    public class MyInfo
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string LinkedIn { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Skype { get; set; }
        public string ProfilePic { get; set; }
        public SummaryDetails Summary { get; set; }
        public List<TechnicalSkillsDetails> TechnicalSkills { get; set; }
        public List<ExperienceDetails> Experience { get; set; }
        public List<EducationDetails> Education { get; set; }
        public List<string> Hobbies { get; set; }
    }
}
