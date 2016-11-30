namespace xmlSerialization
{
    public class Teacher
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Teacher() { }

        public Teacher(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return Name + " " + Salary;
        }
    }
}
