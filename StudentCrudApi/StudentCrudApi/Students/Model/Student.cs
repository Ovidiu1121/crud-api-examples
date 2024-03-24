using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCrudApi.Students.Model
{
    [Table("student_db")]
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("name")]
        public string name { get; set; }

        [Required]
        [Column("age")]
        public int age { get; set; }

        [Required]
        [Column("specialization")]
        public string specialization { get; set; }

    }
}
