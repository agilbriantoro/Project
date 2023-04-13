using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string NameAddress { get; set; }

        public string PostalCode { get; set; }

        public int CityId { get; set; }
    }
}
