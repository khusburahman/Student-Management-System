using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Column("Student Name",TypeName="varchar(100)")]
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty ;
    public string Email { get; set; }   =string.Empty;
    public string Phone { get; set; } =String.Empty;
}
