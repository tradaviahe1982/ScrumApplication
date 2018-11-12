using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ScrumApplicationData.Models
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Day { get; set; }
        public int TaskStatusId { get; set; }
        public int StoryId { get; set; }

        public string UserId { get; set; }

        public virtual Story Story { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
