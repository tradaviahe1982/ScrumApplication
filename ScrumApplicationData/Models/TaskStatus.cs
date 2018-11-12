using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ScrumApplicationData.Models
{
    [Table("TaskStatus")]
    public class TaskStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //
        public virtual IEnumerable<Tasks> Tasks { get; set; }
    }
}
