using System.ComponentModel.DataAnnotations;

namespace Easylevel.Models
{
    public class PayReg
    {
        [Key]
        public int Id { get; set; }
        public string PayrollNumber { get; set; }
    }
}
