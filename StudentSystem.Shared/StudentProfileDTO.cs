using System;

namespace StudentSystemServer.Shared
{
    public class StudentProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string ParentMobile1 { get; set; }
        public string ParentMobile2 { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
    }
}
