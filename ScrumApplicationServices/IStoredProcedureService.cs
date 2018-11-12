using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ScrumApplicationServices
{
    public interface IStoredProcedureService
    {
        //
        Task<IEnumerable<Story>> GetAllStoryFromProjectId(int projectID);
        //
        void RecurringJobInsertStudent(string masv, string tensv, string diachisv);
        //
    }
}
