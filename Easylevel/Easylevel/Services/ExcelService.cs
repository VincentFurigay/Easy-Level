using Easylevel.Data;
using Easylevel.Models;
using EFCore.BulkExtensions;
using OfficeOpenXml;

namespace Easylevel.Services
{
    public class ExcelService
    {
        private readonly PayrollContext _context;

        public ExcelService(PayrollContext context)
        {
            _context = context;
        }

        public async Task UploadTimeAttendance(Stream fstream)
        {
            using (var package = new ExcelPackage(fstream))
            {
                var worksheet = package.Workbook.Worksheets["TimeAttendance"];
                var rowCount = worksheet.Dimension.Rows;
                var timeAttendances = new List<TimeAttendance>();
                for(int row = 2;  row < rowCount; row++)
                {
                    var timeAttendance = new TimeAttendance
                    {
                        EmpId = worksheet.Cells[row, 1].Value.ToString(),
                        PayrollNumber = worksheet.Cells[row, 2].ToString()
                    };

                    timeAttendances.Add(timeAttendance);
                }

                await _context.BulkInsertAsync(timeAttendances);
            }


        }
    }
}
