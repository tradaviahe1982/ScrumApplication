using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ScrumApplicationData.Models
{
    [Table("Stories")]
    public class Story
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Reporter { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StoryStatusId { get; set; }
        public int StoryTypeId { get; set; }
        public int SprintId { get; set; }
        public virtual IEnumerable<Tasks> Tasks { get; set; }
        public virtual Sprint Sprint{ get; set; }
    }
}
