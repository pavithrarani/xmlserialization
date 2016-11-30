using System;
using System.IO;
using System.Xml.Serialization;

namespace xmlSerialization
{
    class Program
    {
        private static readonly Teacher Teacher1 = new Teacher("Anders", 123456);
        static void Main()
        {
            //SerializeTeacherUsingFile();
            SerializeTeacherUsingString();
            //SerializeStudentUsingFile();
        }

        private static void SerializeTeacherUsingFile()
        {
            XmlSerializer teacherSerializer = new XmlSerializer(typeof(Teacher));

            using (FileStream fs = new FileStream("C:/Users/Karsten D/Documents/Git Ext/3_Semester/TEMP/teacher.txt", FileMode.Create))
            {
                teacherSerializer.Serialize(fs, Teacher1);
                fs.Flush();
            }

            using (FileStream fs = new FileStream("C:/Users/Karsten D/Documents/Git Ext/3_Semester/TEMP/teacher.txt", FileMode.Open))
            {
                object obj = teacherSerializer.Deserialize(fs);
                Teacher teacherCopy = (Teacher)obj;
                Console.WriteLine(teacherCopy);
            }
        }

        private static void SerializeTeacherUsingString()
        {
            // http://stackoverflow.com/questions/2434534/serialize-an-object-to-string
            XmlSerializer teacherSerializer = new XmlSerializer(typeof(Teacher));
            string xmlString = "empty";
            using (StringWriter textWriter = new StringWriter())
            {
                teacherSerializer.Serialize(textWriter, Teacher1);
                xmlString = textWriter.ToString();
                Console.WriteLine(xmlString);
            }

            using (StringReader reader = new StringReader(xmlString))
            {
                Teacher teacherCopy = (Teacher)teacherSerializer.Deserialize(reader);
                Console.WriteLine(teacherCopy);
            }
        }

        private static void SerializeStudentUsingFile()
        {
            Student student1 = new Student();
            student1.Name = "John";
            student1.Teachers[0] = Teacher1;

            student1.TeacherList.Add(Teacher1);

            XmlSerializer studentSerializer = new XmlSerializer(typeof(Student));

            using (FileStream fs = new FileStream("C:/Users/Karsten D/Documents/Git Ext/3_Semester/TEMP/student.txt", FileMode.Create))
            {
                studentSerializer.Serialize(fs, student1);
                fs.Flush();
            }

            using (FileStream fs = new FileStream("C:/Users/Karsten D/Documents/Git Ext/3_Semester/TEMP/student.txt", FileMode.Open))
            {
                Student studentCopy = (Student)studentSerializer.Deserialize(fs);
                Console.WriteLine(studentCopy);
            }
        }
    }
}