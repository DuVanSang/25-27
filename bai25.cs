using System;
using System.Collections.Generic;
using System.Text;

// Lớp Person trừu tượng
public abstract class Person
{
    public string name;
    public int age;
    public string gender;
    protected string bank_account;

    // Hàm tạo của lớp Person
    public Person(string name, int age, string gender)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
    }

    // Phương thức trừu tượng để lấy vai trò
    public abstract string getRole();
}

// Interface KPIEvaluator
public interface KPIEvaluator
{
    double calculateKPI(); // Phương thức tính KPI
}

// Lớp TeachingAssistant kế thừa từ Person và triển khai KPIEvaluator
public class TeachingAssistant : Person, KPIEvaluator
{
    public string employeeID;
    private int numberOfCourses;

    // Hàm tạo của lớp TeachingAssistant
    public TeachingAssistant(string name, int age, string gender, string employeeID, int numberOfCourses)
        : base(name, age, gender)
    {
        this.employeeID = employeeID;
        this.numberOfCourses = numberOfCourses;
    }

    // Ghi đè phương thức getRole để trả về vai trò
    public override string getRole()
    {
        return "Teaching Assistant";
    }

    // Ghi đè phương thức calculateKPI để tính KPI
    public double calculateKPI()
    {
        return numberOfCourses * 5;
    }
}

// Lớp Lecturer kế thừa từ Person và triển khai KPIEvaluator
public class Lecturer : Person, KPIEvaluator
{
    public string employeeID;
    private int numberOfPublications;

    // Hàm tạo của lớp Lecturer
    public Lecturer(string name, int age, string gender, string employeeID, int numberOfPublications)
        : base(name, age, gender)
    {
        this.employeeID = employeeID;
        this.numberOfPublications = numberOfPublications;
    }

    // Ghi đè phương thức getRole để trả về vai trò
    public override string getRole()
    {
        return "Lecturer";
    }

    // Ghi đè phương thức calculateKPI để tính KPI
    public double calculateKPI()
    {
        return numberOfPublications * 7;
    }
}

// Lớp Professor kế thừa từ Lecturer và không cho phép kế thừa thêm
public sealed class Professor : Lecturer
{
    public static int countProfessors = 0;
    private int numberOfProjects;

    // Hàm tạo của lớp Professor
    public Professor(string name, int age, string gender, string employeeID, int numberOfPublications, int numberOfProjects)
        : base(name, age, gender, employeeID, numberOfPublications)
    {
        this.numberOfProjects = numberOfProjects;
        countProfessors++;
    }

    // Ghi đè phương thức getRole để trả về vai trò
    public override string getRole()
    {
        return "Professor";
    }

    // Ghi đè phương thức calculateKPI để tính KPI
    public new double calculateKPI()
    {
        return base.calculateKPI() + numberOfProjects * 10;
    }
}

// Lớp chứa hàm main
class bai25
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<Person> people = new List<Person>();
        int n;

        // Nhập số lượng đối tượng
        Console.WriteLine("Nhập số lượng người (2-10): ");
        while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 10)
        {
            Console.WriteLine("Dữ liệu không hợp lệ. Nhập số lượng người (2-10): ");
        }

        // Nhập thông tin cho từng đối tượng
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập loại người thứ {i + 1} (ta, lec, gs): ");
            string type = Console.ReadLine().ToLower();
            Person person = null;

            switch (type)
            {
                case "ta":
                    person = CreateTeachingAssistant();
                    break;
                case "lec":
                    person = CreateLecturer();
                    break;
                case "gs":
                    person = CreateProfessor();
                    break;
                default:
                    Console.WriteLine("Loại không hợp lệ. Thử lại.");
                    i--;
                    continue;
            }

            people.Add(person);
        }

        // Hiển thị thông tin các đối tượng
        DisplayPeople(people);

        // Hiển thị số lượng Professor
        Console.WriteLine($"Số lượng Giáo sư: {Professor.countProfessors}");
    }

    // Hàm tạo đối tượng TeachingAssistant
    static TeachingAssistant CreateTeachingAssistant()
    {
        Console.WriteLine("Nhập tên: ");
        string name = Console.ReadLine();

        Console.WriteLine("Nhập tuổi: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhập giới tính: ");
        string gender = Console.ReadLine();

        Console.WriteLine("Nhập mã nhân viên: ");
        string employeeID = Console.ReadLine();

        Console.WriteLine("Nhập số lượng môn học: ");
        int numberOfCourses = int.Parse(Console.ReadLine());

        return new TeachingAssistant(name, age, gender, employeeID, numberOfCourses);
    }

    // Hàm tạo đối tượng Lecturer
    static Lecturer CreateLecturer()
    {
        Console.WriteLine("Nhập tên: ");
        string name = Console.ReadLine();

        Console.WriteLine("Nhập tuổi: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhập giới tính: ");
        string gender = Console.ReadLine();

        Console.WriteLine("Nhập mã nhân viên: ");
        string employeeID = Console.ReadLine();

        Console.WriteLine("Nhập số lượng bài báo khoa học: ");
        int numberOfPublications = int.Parse(Console.ReadLine());

        return new Lecturer(name, age, gender, employeeID, numberOfPublications);
    }

    // Hàm tạo đối tượng Professor
    static Professor CreateProfessor()
    {
        Console.WriteLine("Nhập tên: ");
        string name = Console.ReadLine();

        Console.WriteLine("Nhập tuổi: ");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhập giới tính: ");
        string gender = Console.ReadLine();

        Console.WriteLine("Nhập mã nhân viên: ");
        string employeeID = Console.ReadLine();

        Console.WriteLine("Nhập số lượng bài báo khoa học: ");
        int numberOfPublications = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhập số lượng dự án: ");
        int numberOfProjects = int.Parse(Console.ReadLine());

        return new Professor(name, age, gender, employeeID, numberOfPublications, numberOfProjects);
    }

    // Hàm hiển thị thông tin các đối tượng
    static void DisplayPeople(List<Person> people)
    {
        foreach (var person in people)
        {
            Console.WriteLine($"Tên: {person.name}");
            Console.WriteLine($"Tuổi: {person.age}");
            Console.WriteLine($"Giới tính: {person.gender}");
            Console.WriteLine($"Vai trò: {person.getRole()}");

            if (person is KPIEvaluator evaluator)
            {
                Console.WriteLine($"KPI: {evaluator.calculateKPI()}");
            }

            Console.WriteLine();
        }
    }
}