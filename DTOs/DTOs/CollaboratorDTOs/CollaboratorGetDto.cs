﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.CollaboratorDTOs
{
    public class CollaboratorGetDto : CollaboratorAddDto
    {
        public string Id { get; set; }
        public string Email {  get; set; }
    }
}
