using System;
using System.Collections.Generic;
using System.Linq;

namespace studentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            aLevelStudent Tim = new aLevelStudent(16, "Tim", "Male", 
                new aLevelCourse("Maths", "Dave"), new aLevelCourse("Computer Science", "Dave"), new aLevelCourse("Physics", "Dave"), new aLevelCourse("Economics", "Dave"));
            
            Tim.getDetails();
            Tim.drop("Maths");
            Tim.getDetails();
            Tim.newSubject("Latin", "Dave");
            Tim.getDetails();

            gcseStudent Bob = new gcseStudent(16, "Bob", "Male",
                new gcseCourse("Economics", "Dave"), new gcseCourse("Computer Science", "Dave"), new gcseCourse("Religious Studies", "Dave"), new gcseCourse("Geography", "Dave"));
            Bob.getDetails();
            Bob.drop("Maths");
            Bob.getDetails();
            Bob.newSubject("Latin", "Dave");
            Bob.getDetails();
        }
    }


    //student class
    class Student
    {
        private int age;
        private string name;
        private string sex;

        public Student(int a, string n, string s)
        {
            age = a;
            name = n;
            sex = s;
        }
        //getters
        public string getName() { return this.name; }
        public int getAge() { return this.age; }
        public string getSex() { return this.sex; }
        public virtual void getDetails()
        {
            Console.WriteLine("\n" +
                "Name: {0}\n" +
                "Age:  {1}\n" +
                "Sex:  {2}\n" +
                "\n", 
                this.name, Convert.ToString(this.age), this.sex);
        }
        //virtual drop subject method
        public virtual void drop(string course = null)
        {
            Console.WriteLine("Course dropped");
        }
        public virtual void newSubject(string course = null, string teacher = null)
        {
            Console.WriteLine("Course added");
        }
    }
    class gcseStudent : Student
    {
        LinkedList<gcseCourse> enrolledCourses = new LinkedList<gcseCourse> { };
        public gcseStudent(int a, string n, string s, gcseCourse c1, gcseCourse c2, gcseCourse c3, gcseCourse c4) : base(a, n, s)
        {
            enrolledCourses.AddLast(new gcseCourse("Maths", "Dave"));
            enrolledCourses.AddLast(new gcseCourse("English Lit", "Dave"));
            enrolledCourses.AddLast(new gcseCourse("English Lang", "Dave"));
            enrolledCourses.AddLast(new gcseCourse("Physics", "Dave"));
            enrolledCourses.AddLast(new gcseCourse("Chemistry", "Dave"));
            enrolledCourses.AddLast(new gcseCourse("Biology", "Dave"));
            enrolledCourses.AddLast(c1);
            enrolledCourses.AddLast(c2);
            enrolledCourses.AddLast(c3);
            enrolledCourses.AddLast(c4);
        }
        public override void drop(string course)
        {
            gcseCourse current = new gcseCourse(null, null);
            int count = enrolledCourses.Count();
            foreach (gcseCourse c in enrolledCourses)
            {
                if (c.getSubject() == course)
                {
                    current = c;
                }
            }
            enrolledCourses.Remove(current);
            base.drop();
        }
        public override void newSubject(string course, string teacher)
        {
            enrolledCourses.AddLast(new gcseCourse(course, teacher));
            base.newSubject();
        }
        public override void getDetails()
        {
            Console.WriteLine("\n" +
                "Name: {0}\n" +
                "Age:  {1}\n" +
                "Sex:  {2}\n" +
                "\n" +
                "Courses - GCSE:\n" +
                "",
                base.getName(), Convert.ToString(base.getAge()), base.getSex());

            foreach (gcseCourse c in enrolledCourses)
            {
                Console.WriteLine("{0}", c.getSubject());                
            }
            Console.WriteLine("");
        }
    }
    class aLevelStudent : Student
    {
        private LinkedList<aLevelCourse> enrolledCourses = new LinkedList<aLevelCourse> { };
        public aLevelStudent(int agee, string namee, string sexx, aLevelCourse c1, aLevelCourse c2, aLevelCourse c3, aLevelCourse c4 = null) : base(agee, namee, sexx)
        {
            enrolledCourses.AddLast(c1);
            enrolledCourses.AddLast(c2);
            enrolledCourses.AddLast(c3);
            if (c4 != null)
            {
                enrolledCourses.AddLast(c4);
            }
        }
        public override void drop(string course)
        {
            aLevelCourse current = new aLevelCourse(null, null);
            int count = enrolledCourses.Count();
            foreach (aLevelCourse c in enrolledCourses)
            {
                if (c.getSubject() == course)
                {
                    current = c;
                }
            }
            enrolledCourses.Remove(current);
            base.drop();
        }
        public override void newSubject(string course, string teacher)
        {
            enrolledCourses.AddLast(new aLevelCourse(course, teacher));
            base.newSubject();
        }
        public override void getDetails()
        {
            Console.WriteLine("\n" +
                "Name: {0}\n" +
                "Age:  {1}\n" +
                "Sex:  {2}\n" +
                "\n" +
                "Courses - A Level:", 
                base.getName(), Convert.ToString(base.getAge()), base.getSex());

            foreach (aLevelCourse c in enrolledCourses)
            {
                Console.WriteLine("{0}", c.getSubject());   
            }
            Console.WriteLine("");
        }
    } 

    class Course
    {
        private string subject;
        private string teacher;
        private int duration;

        public Course(string s, string t, int d)
        {
            subject = s;
            teacher = t;
            duration = d;
        }
        public void changeDuration(int d)
        {
            duration = d;
            Console.WriteLine("Duration changed to {0} years", duration);
        }
        public void changeTeacher(string t)
        {
            teacher = t;
            Console.WriteLine("Teacher changed to {0}", teacher);
        }

        public string getSubject()
        {
            return subject;
        }
        public string getTeacher()
        {
            return teacher;
        }
        public int getDuration()
        {
            return duration;
        }
    }
    class gcseCourse : Course
    {
        public gcseCourse(string s, string t, int d = 3) : base(s, t, d) { }
    }
    class aLevelCourse : Course
    {
        public aLevelCourse(string s, string t, int d = 2) : base(s, t, d) { }
    }   
}
