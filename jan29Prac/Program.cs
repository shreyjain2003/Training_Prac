namespace jan29Prac
{
    public interface IPerson
    {
        public void setName(string name);
        public void getName();
    }

    public class Student : IPerson
    {
        public string Name { get; set; }

        public void setName(string name)
        {
            this.Name = name;
        }
        public void getName()
        {
            System.Console.WriteLine("Name: " + this.Name);
        }
    }
    public class Person
    {
        public static void Main(string[] args)
        {
            {
                Student student = new Student();
                student.setName("John Doe");
                student.getName();
            }
        }
    }
}
