﻿using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Entities;

namespace TutorLinkAPI.ViewModel
{
    public class AddApplyViewModel
    {
        [Required]
        public Guid PostId { get; set; }

        [Required]
        public Guid TutorId { get; set; }

        [Required]
        public ApplyStatuses Status { get; set; }
    }
}