using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumApplicationData.Models
{
    [Table("ProjectStatus")]
    public class ProjectStatus
    {
        //
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //
        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
