using CMSRepoPatternMVCDemo.Models;

namespace CMSRepoPatternMVCDemo.Repository
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAllDepts();
    }
}
