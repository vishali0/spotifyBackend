﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public  string UserPassword { get; set; }

        public string Email { get; set; }

        public long MobileNumber { get; set; }

    }
}
