﻿using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task2
{

    [Serializable]
    class Group : ISerializable
    {

        public decimal GroupId { get; set; }

        public string Name { get; set; }

        public List<Student> Students { get; set; }

        // no need to serialize this
        public int StudentsCount { get; set; }

        public Group(decimal groupId, string name, List<Student> students, int studentsCount)
        {
            GroupId = groupId;
            Name = name;
            Students = students;
            StudentsCount = studentsCount;
        }

        public Group(SerializationInfo information, StreamingContext context)
        {
            GroupId = information.GetDecimal("GroupId");
            Name = information.GetString("Name") ?? "";
            Students = new List<Student>();

            var value = information.GetValue("Students", typeof(List<decimal>));
            List<decimal> ids = (value == null) ? new List<decimal>() : (List<decimal>) value;

            foreach (decimal id in ids)
            {
                Student student = new Student
                {
                    StudentId = id,
                    FirstName = information.GetString("FirstName#" + id) ?? "",
                    LastName = information.GetString("LastName#" + id) ?? "",
                    Age = information.GetInt32("Age#" + id),
                    Group = this
                };
                Students.Add(student);
            }

            StudentsCount = Students.Count;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("GroupId", GroupId);
            info.AddValue("Name", Name);
            List<decimal> ids = Students.Select(s => s.StudentId).ToList();
            info.AddValue("Students", ids, typeof(List<decimal>));

            foreach (Student student in Students)
            {
                info.AddValue("FirstName#" + student.StudentId, student.FirstName);
                info.AddValue("LastName#" + student.StudentId, student.LastName);
                info.AddValue("Age#" + student.StudentId, student.Age);
            }
        }

        public override string ToString()
        {
            string studentsString = "[" + string.Join(", ", Students.Select(s => s.ToString()).ToArray()) + "]";
            return string.Format("Group[GroupId={0}, Name='{1}', Students={2}]", GroupId, Name, studentsString);
        }

    }

    class Student
    {

        public required decimal StudentId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required int Age { get; set; }

        public required Group Group { get; set; }

        public override string ToString()
        {
            return string.Format("Student[StudentId={0}, FirstName='{1}', LastName='{2}', Age={3}]", StudentId, FirstName, LastName, Age);
        }

    }


    internal class MainClass
    {

        public static void Main(string[] args)
        {
            Group x = new Group(1, "group#1", new List<Student>(), 0);
            Group y = new Group(2, "group#2", new List<Student>(), 0);
            Student a = new Student { StudentId = 1, FirstName = "a", LastName = "aa", Age = 20, Group = x };
            Student b = new Student { StudentId = 2, FirstName = "b", LastName = "bb", Age = 20, Group = x };
            Student c = new Student { StudentId = 3, FirstName = "c", LastName = "cc", Age = 20, Group = y };
            x.Students.Add(a);
            x.Students.Add(b);
            y.Students.Add(c);
            x.StudentsCount = 2;
            y.StudentsCount = 1;

            using (FileStream fileStream = new FileStream("output.dat", FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                binaryFormatter.Serialize(fileStream, x);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }

            using (FileStream fileStream = new FileStream("output.dat", FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                Group group = (Group)binaryFormatter.Deserialize(fileStream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                Console.WriteLine(group.ToString());
            }
        }
    }

}
