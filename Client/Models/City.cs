using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
