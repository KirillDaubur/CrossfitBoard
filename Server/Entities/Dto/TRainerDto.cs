﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class TrainerDto : UserDto
    {
        public List<UserDto> Wards { get; set; }
    }
}
