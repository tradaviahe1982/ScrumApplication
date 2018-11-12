using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumApplicationData.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace ScrumApplication.Models.SprintViewModels
{
    public class SprintDetailViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số Sprint")]
        public int Number { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn trạng thái Sprint")]
        public int SprintStatusId { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn trạng thái dự án")]
        public int ProjectId { get; set; }
        public string StatusMessage { get; set; }
        //
    }
}
