using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SearchEngine.Database.Models
{
    public class Project:ISearchable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string DocumentFormat { get; set; }

        public Dictionary<string, object> GetProperties()
        {
            return new Dictionary<string, object>
            {
                { "Name", Name },
                { "Year", Year },
                { "AuthorName", AuthorName },
                { "DocumentFormat", DocumentFormat }
            };
        }
        public override string ToString()
        {
            return $"{Name} - {Year}, by {AuthorName} ({DocumentFormat})";
        }
    }
}
