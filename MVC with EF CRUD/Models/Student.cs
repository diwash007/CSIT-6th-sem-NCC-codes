using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student {
    [Key]
    public int studentId {get; set;}
    [Column(TypeName = "varchar(200)")]
    public string Name {get; set;}
    public int RollNo {get; set;}
    [Column(TypeName = "varchar(200)")]
    public string Class {get; set;}
}