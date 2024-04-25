﻿using DTOs.DTOs.CityDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICityRepository
    {
        Task AddAsync(CityAddDto cityAddDto);
        Task<CityGetDto> GetByIdAsync(int id); 
        Task<List<CityGetDto>> StartsWithAsync(string recherche);
        Task UpdateAsync(CityUpdateDto cityUpdateDto);
        Task DeleteAsync(int id);

    }
}
