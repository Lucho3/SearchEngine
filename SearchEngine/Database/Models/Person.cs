using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Microsoft.EntityFrameworkCore;

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
        public int YearBorn { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public string EGN { get; set; }

        public Dictionary<string, object> GetProperties()
        {
            return new Dictionary<string, object>
            {
                { "Name", Name },
                { "Year Born", YearBorn },
                { "Sex", Sex },
                { "Height", Height },
                { "EGN", EGN },
            };
        }
        public override string ToString()
        {
            return $"{Name}, Born: {YearBorn}, Sex: {Sex}, Height: {Height} cm, EGN: {EGN}";
        }

    }
}
