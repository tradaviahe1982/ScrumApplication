using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData;
using ScrumApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;
namespace ScrumApplicationServices.Core
{
    public class StoredProcedureManager : IStoredProcedureService
    {
        private readonly ScrumApplicationDbContext _context;
        public StoredProcedureManager(ScrumApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Story>> GetAllStoryFromProjectId(int projectID)
        {
            var stories = await _context.Stories.FromSql("EXECUTE dbo.GetInfoAboutPoint {0}", projectID).ToListAsync();
            return stories;
        }
        //
        public void RecurringJobInsertStudent(string masv, string tensv, string diachisv)
        {
            _context.Database.ExecuteSqlCommand("Recurring_Job @student_code,@student_name,@student_address", new SqlParameter("@student_code", masv), new SqlParameter("@student_name", tensv), new SqlParameter("@student_address", diachisv));
        }
        //
    }
}
