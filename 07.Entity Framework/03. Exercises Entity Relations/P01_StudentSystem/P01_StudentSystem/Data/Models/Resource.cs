using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public Resource()
        {
            Resources = new HashSet<Resource>();
        }
        public int ResourceId { get; set; }
        [Unicode]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(CourseId))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }

    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other,
    }

}
