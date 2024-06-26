﻿using DataLayer.Entities;

namespace TutorLinkAPI.ViewModel
{
    public class UpdateAccountViewModel
    {
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public UserGenders Gender { get; set; }
    }
}
