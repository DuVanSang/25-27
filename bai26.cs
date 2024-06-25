using System;
using System.Text;

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

// Khai báo lớp Student kế thừa từ Person
public class Student : Person
{
    // Trường Major: kiểu xâu kí tự, phạm vi public, cho phép get, set
    public string Major { get; set; }

    // Hàm tạo (constructor) với phạm vi public, 3 đối để gán Name, Age, Major
    public Student(string name, int age, string major) : base(name, age)
    {
        Major = major;
    }

    // Ghi đè hàm ToString() để hiển thị Name, Age, Major của đối tượng Student
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}";
    }
}

// Lớp chứa hàm Main
class bai26
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Khai báo đối tượng Student và cấp phát đối tượng với tên là "Nguyễn Tiến Dũng", tuổi 20, khoa "CNTT&TT"
        Student student = new Student("Nguyễn Tiến Dũng", 20, "CNTT&TT");

        // Sử dụng hàm ToString() để hiển thị đối tượng
        Console.WriteLine(student.ToString());
    }
}
