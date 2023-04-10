﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("tb_m_addresses")]
    public class Addresses
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required , Column ("address")]
        public string Address { get; set; }

        [Required, Column("postal_code")]
        public string PostalCode { get; set; }

        [Required, Column("city_id")]
        public int CityId { get; set; }

        // Cardinality & Relation
        [JsonIgnore]
        [ForeignKey(nameof(CityId))]
        public Cities? Cities { get; set; }

        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; }

        [JsonIgnore]
        public ICollection<Departments>? Departments { get; set;}
    }
}
