using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSRepoPatternMVCDemo.Models
{
    [Table("EmployeeTable")]
    public class Employee
    {
        [Key]
        [Column("EmployeeId")]
        public int EmpId { get; set; }
        [StringLength(40)]
        public string? EmpName { get; set; }
        [StringLength(25,MinimumLength =2,ErrorMessage ="Designation should have minimum of 2 characters")]
        public string? Desig {  get; set; }
        [Range(25000,150000,ErrorMessage ="Salary should be between 25000 and 150000")]
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }

        [ForeignKey("Department")]
        public int? DepId { get; set; }
        public Department? department { get; set; }
    }
}
