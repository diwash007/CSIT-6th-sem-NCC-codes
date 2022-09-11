using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student {
    [Key]
    public int StudentId {get; set;}
    [Column(TypeName = "varchar(200)")]
    public string Name {get; set;}
    public int RollNo {get; set;}
    [Column(TypeName = "varchar(50)")]
    public string Class {get; set;}
}

public class DataContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder ob) {
        ob.UseMySQL("server=localhost;database=csit;user=root;password=;");
    }
    public DbSet<Student> students {get; set;}
}

public class Program {
    DataContext dc = new DataContext();

    public void Insert(Student s) {
        dc.students.Add(s);
        dc.SaveChanges();
    }

    public void Delete(int id) {
        var student = dc.students.Find(id);
        if (student == null) return;
        dc.students.Remove(student);
        dc.SaveChanges();
    }

    public void Read() {
        foreach(var s in dc.students) {
            Console.WriteLine($"Name: {s.Name}");
        }
    }

    public void Update(int id, Student s) {
        Student student = dc.students.Find(id);
        if (student == null) return;
        student.Name = s.Name;
        student.Class = s.Class;
        student.RollNo = s.RollNo;

        dc.students.Update(student);
        dc.SaveChanges();
    }

    public static void Main() {
        Program p = new Program();
        Student s = new Student {
            StudentId=1,
            Name="Hari",
            RollNo=45,
            Class="seven"
        };

        p.Read();
    }
}