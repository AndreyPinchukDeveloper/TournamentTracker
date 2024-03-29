﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.DTOs
{
    public class RegistrationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string GameID { get; set; }
        public string NameOfPlatform { get; set; }
        public string NameOfGame { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
