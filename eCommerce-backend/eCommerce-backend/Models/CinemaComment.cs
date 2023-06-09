﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_backend.Models
{
    public class CinemaComment : IComment
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PostTime { get; set; } = DateTime.Now;
        public int Rate { get; set; }


        [ForeignKey(nameof(Models.Cinema))]
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
    }
}
