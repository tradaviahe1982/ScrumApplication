using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumApplicationData.Models
{
    [Table("SprintStatus")]
    public class SprintStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //
        public virtual IEnumerable<Sprint> Sprints { get; set; }
    }
}
