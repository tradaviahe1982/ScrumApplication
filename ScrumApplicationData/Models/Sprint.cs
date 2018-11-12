using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ScrumApplicationData.Models
{
    [Table("Sprints")]
    public class Sprint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SprintStatusId { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual IEnumerable<Story> Stories { get; set; }
    }
}
