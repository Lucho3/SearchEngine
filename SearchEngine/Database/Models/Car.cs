using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;

namespace SearchEngine.Database.Models
{
    public class Car : ISearchable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string FuelType { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        public int TyreSize { get; set; }

        public Dictionary<string, object> GetProperties()
        {
            return new Dictionary<string, object>
            {
                { "Brand", Brand },
                { "Model", Model },
                { "Year", Year },
                { "Fuel Type", FuelType },
                { "Tyre Size", TyreSize },
                { "VIN", VIN }
            };
        }
        public override string ToString()
        {
            return $"{Brand} {Model} ({Year}) - Fuel: {FuelType}, Tyres: {TyreSize} inches, VIN: {VIN}";
        }
    }
}
