using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace SearchEngine.Database.Models
{
    public class Person:ISearchable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string YearBorn { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public int Height { get; set; }

        public Dictionary<string, object> GetProperties()
        {
            return new Dictionary<string, object>
            {
                { "Name", Name },
                { "YearBorn", YearBorn },
                { "Sex", Sex },
                { "Height", Height }
            };
        }
        public override string ToString()
        {
            return $"{Name}, Born: {YearBorn}, Sex: {Sex}, Height: {Height} cm";
        }

    }
}
