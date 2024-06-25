using System;
using System.Text;

// Khai báo interface KPI
public interface KPI
{
    double CalculateKPI();
}

// Khai báo lớp Person trừu tượng
public abstract class Person
{
    // Trường Name: kiểu xâu kí tự, phạm vi public, cho phép get, set
    public string Name { get; set; }

    // Trường Age: kiểu int, phạm vi public, cho phép get, set
    public int Age { get; set; }

    // Hàm tạo (constructor) với phạm vi public, 2 đối để gán 2 trường Name và Age
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Method trừu tượng ToString() trả lại xâu kí tự
    public abstract override string ToString();
}

// Khai báo lớp Student kế thừa từ Person và cài đặt KPI
public class Student : Person, KPI
{
    // Trường Major: kiểu xâu kí tự, phạm vi public, cho phép get, set
    public string Major { get; set; }

    // Trường GPA: kiểu số thực 4 byte, phạm vi public, cho phép get, set
    public float GPA { get; set; }

    // Hàm tạo (constructor) với phạm vi public, 4 đối để gán Name, Age, Major, GPA
    public Student(string name, int age, string major, float gpa) : base(name, age)
    {
        Major = major;
        GPA = gpa;
    }

    // Ghi đè hàm ToString() để hiển thị Name, Age, Major, GPA của đối tượng Student
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, GPA: {GPA}";
    }

    // Implement method CalculateKPI() trả về GPA
    public double CalculateKPI()
    {
        return GPA;
    }
}

// Khai báo lớp Teacher kế thừa từ Person và cài đặt KPI
public class Teacher : Person, KPI
{
    // Trường Major: kiểu xâu kí tự, phạm vi public, cho phép get, set
    public string Major { get; set; }

    // Trường Publications: kiểu int, phạm vi public, cho phép get, set
    public int Publications { get; set; }

    // Hàm tạo (constructor) với phạm vi public, 4 đối để gán Name, Age, Major, Publications
    public Teacher(string name, int age, string major, int publications) : base(name, age)
    {
        Major = major;
        Publications = publications;
    }

    // Ghi đè hàm ToString() để hiển thị Name, Age, Major, Publications của đối tượng Teacher
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, Publications: {Publications}";
    }

    // Implement method CalculateKPI() trả về 1.5 * Publications
    public double CalculateKPI()
    {
        return 1.5 * Publications;
    }
}

// Lớp chứa hàm Main
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Khai báo và cấp phát đối tượng Student với tên "Nguyễn Tiến Dũng", tuổi 20, khoa "CNTT&TT", GPA 3.8
        Student student = new Student("Nguyễn Tiến Dũng", 20, "CNTT&TT", 3.8f);

        // Khai báo và cấp phát đối tượng Teacher với tên "Vũ Đức Việt", tuổi 38, khoa "CNTT&TT", 5 publications
        Teacher teacher = new Teacher("Vũ Đức Việt", 38, "CNTT&TT", 5);

        // Hiển thị đối tượng Student bằng hàm ToString() và hiển thị điểm KPI
        Console.WriteLine(student.ToString());
        Console.WriteLine($"KPI: {student.CalculateKPI()}");

        // Hiển thị đối tượng Teacher bằng hàm ToString() và hiển thị điểm KPI
        Console.WriteLine(teacher.ToString());
        Console.WriteLine($"KPI: {teacher.CalculateKPI()}");
    }
}
