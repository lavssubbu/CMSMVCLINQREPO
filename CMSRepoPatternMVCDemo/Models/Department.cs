using System.ComponentModel.DataAnnotations;

namespace CMSRepoPatternMVCDemo.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        public string? DepName { get; set; }

        //Navigation property
        public List<Employee>? Employees { get; set; }
    }
}
