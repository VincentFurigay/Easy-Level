using System.ComponentModel.DataAnnotations;

namespace Easylevel.Models
{
    public class TimeAttendance
    {
        [Key]
        public int Id { get; set;}
        public string EmpId { get; set;}
        public string PayrollNumber { get; set;}
    }
}
