﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.CityDTOs
{
    public class CityUpdateDto : CityAddDto
    {
        public int Id { get; set; }
    }
}
