using Easylevel.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Easylevel.Data
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PayReg> PayRegs { get; set; }
        public DbSet<OtReg> OtRegs { get; set; }
        public DbSet<TimeAttendance> TimeAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PayReg>().HasData(
                new PayReg { Id = 1, PayrollNumber = "PR001" },
                new PayReg { Id = 2, PayrollNumber = "PR002" },
                new PayReg { Id = 3, PayrollNumber = "PR003" },
                new PayReg { Id = 4, PayrollNumber = "PR004" },
                new PayReg { Id = 5, PayrollNumber = "PR005" }
                );

            builder.Entity<OtReg>().HasData(
                new PayReg { Id = 1, PayrollNumber = "OT001" },
                new PayReg { Id = 2, PayrollNumber = "OT002" },
                new PayReg { Id = 3, PayrollNumber = "OT003" },
                new PayReg { Id = 4, PayrollNumber = "OT004" },
                new PayReg { Id = 5, PayrollNumber = "OT005" }
                );
        }
    }

    
}
