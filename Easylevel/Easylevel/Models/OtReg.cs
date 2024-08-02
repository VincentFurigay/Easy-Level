using System.ComponentModel.DataAnnotations;

namespace Easylevel.Models
{
    public class OtReg
    {
        [Key]
        public int Id { get; set; }
        public string PayrollNumber { get; set; }
    }
}
