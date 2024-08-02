using Easylevel.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Easylevel.Services
{
    public class ExportService
    {
        private readonly PayrollContext _context;
        public ExportService(PayrollContext context)
        {
            _context = context;
        }

        public async Task <Stream> ExportData(string payrollNumber)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var payregSheet = package.Workbook.Worksheets.Add("PayReg");
                var otregSheet = package.Workbook.Worksheets.Add("OtReg");
                var payregData = await _context.PayRegs.Where(p => p.PayrollNumber == payrollNumber).ToListAsync();
                var otregData = await _context.OtRegs.Where(o => o.PayrollNumber == payrollNumber).ToListAsync();

                payregSheet.Cells[1, 1].Value = "PayrollNumber";
                for(int i = 0; i < payregData.Count; i++)
                {
                    payregSheet.Cells[i + 2, 1].Value = payregData[i].PayrollNumber;
                }

                otregSheet.Cells[1, 1].Value = "PayrollNumber";
                for (int i = 0; i < otregData.Count; i++)
                {
                    otregSheet.Cells[i + 2, 1].Value = otregData[i].PayrollNumber;
                }
                package.Save();
            };
            stream.Position = 0;
            return stream;

        }
    }
}
