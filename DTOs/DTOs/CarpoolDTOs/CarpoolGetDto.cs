﻿using DTOs.DTOs.AddressDTOs;
using DTOs.DTOs.CollaboratorDTOs;
using DTOs.DTOs.VehicleDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.CarpoolDTOs;
public class CarpoolGetDto : CarpoolAddDto
{
    public int Id { get; set; }
    public CollaboratorGetDto Driver { get; set; }
    public List<CollaboratorGetDto> PassengersDto { get; set; }
    public int RemainingSeats { get; set; }
    public VehicleGetDto VehicleGetDto { get; set; }
    public AddressGetDto StartAddressDto { get; set; }
    public AddressGetDto EndAddressDto { get; set; }
}