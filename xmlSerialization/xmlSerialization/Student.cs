using System.Collections.Generic;

namespace xmlSerialization
{
    class Student
    {
        public string Name { get; set; }

        public Teacher[] Teachers = new Teacher[4];

        // IList cannot be serialized
        public List<Teacher> TeacherList = new List<Teacher>();

        public override string ToString()
        {
            return Name + " Teachers: " + string.Join(", ", TeacherList);
        }
    }
}