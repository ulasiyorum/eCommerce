﻿using eCommerce_backend.Models;

namespace eCommerce_backend.Dtos.Actor
{
    public class GetActorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProfilePictureURL { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}