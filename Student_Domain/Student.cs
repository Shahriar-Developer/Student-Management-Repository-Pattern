using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Domain
{
    [Serializable]
    [Table("Student")]
    public class Student : IEntity<int>
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(20)]
        public string Class { get; set; }
    }
}
