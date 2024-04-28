﻿using DTOs.DTOs.RentalDTOs;
using DTOs.DTOs.VehicleDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class RentalRepository(DriveWiseContext _context) : IRentalRepository
{

    public async Task<List<RentalGetDto>> GetAllCurrentAsync()
    {
        try
        {
            List<RentalGetDto> listAllCurrent = await _context
                                                        .Rentals
                                                        .Where(r => r.StartDateId > DateTime.Now)
                                                        .Select(r => new RentalGetDto
                                                        {
                                                            Id = r.Id,
                                                            ModelName = r.Vehicle.Model.Name,
                                                            BrandName = r.Vehicle.Model.Brand.Name,
                                                            Registration = r.Vehicle.Registration,
                                                            StartDate = r.StartDateId,
                                                            EndDate = r.EndDateId,
                                                        })
                                                        .ToListAsync();

            if (listAllCurrent == null)
                return null;

            return listAllCurrent;
        }
        catch (System.Exception)
        {
            throw;
        }
    }


    public async Task<List<RentalGetDto>> GetAllPastAsync()
    {
        try
        {
            List<RentalGetDto> listAllPast = await _context
                                                    .Rentals
                                                    .Where(r => r.EndDateId < DateTime.Now)
                                                    .Select(r => new RentalGetDto
                                                    {
                                                        Id = r.Id,
                                                        ModelName = r.Vehicle.Model.Name,
                                                        BrandName = r.Vehicle.Model.Brand.Name,
                                                        Registration = r.Vehicle.Registration,
                                                        StartDate = r.StartDateId,
                                                        EndDate = r.EndDateId,
                                                    })
                                                    .ToListAsync();

            if (listAllPast == null)
                return null;

            return listAllPast;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto)
    {
        try
        {
            await _context.Rentals.AddAsync(new Rental
            {
                VehicleId = rentalAddDto.VehicleId,
                CollaboratorId = rentalAddDto.CollaboratorId,
                StartDateId = rentalAddDto.StartDateId,
                EndDateId = rentalAddDto.EndDateId,
            });

            await _context.SaveChangesAsync();
            return rentalAddDto;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<VehicleGetDto>> ResearchCarRentalAsync(RentalResearchDateDto rentalResearchDateDto)
    {
        try
        {
            List<VehicleGetDto> listVehicleGetDtos = await _context
                                                            .Rentals
                                                            .Where(r => ((rentalResearchDateDto.StartDateId < r.StartDateId && rentalResearchDateDto.EndDateId < r.StartDateId)
                                                                            || (rentalResearchDateDto.StartDateId > r.EndDateId && rentalResearchDateDto.EndDateId > r.EndDateId))
                                                                            && r.Vehicle.Status.Name == "AVAILABLE"
                                                                    )
                                                            .Select(r => new VehicleGetDto
                                                            {
                                                                Id = r.Id,
                                                                Registration = r.Vehicle.Registration,
                                                                TotalSeats = r.Vehicle.TotalSeats,
                                                                CO2EmissionKm = r.Vehicle.CO2EmissionKm,
                                                                ImageUrl = r.Vehicle.ImageUrl,
                                                                CategoryName = r.Vehicle.Category.Name,
                                                                MotorType = r.Vehicle.Motor.Type,
                                                                ModelName = r.Vehicle.Model.Name,
                                                                BrandName = r.Vehicle.Model.Brand.Name,
                                                            })
                                                            .ToListAsync();

            return listVehicleGetDtos;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Rental> UpdateAsync(RentalUpdateDto rentalUpdateDto)
    {
        try
        {
            Rental? rentalToUpdate = await _context
                                            .Rentals
                                            .Where(r => ((rentalUpdateDto.StartDateId < r.StartDateId && rentalUpdateDto.EndDateId < r.StartDateId)
                                                || (rentalUpdateDto.StartDateId > r.EndDateId && rentalUpdateDto.EndDateId > r.EndDateId)) && r.Collaborator.CarpoolsAsPassenger.Count() == 0)
                                            .FirstOrDefaultAsync(r => r.Id == rentalUpdateDto.Id);

            if (rentalToUpdate == null)
                return null;

            rentalToUpdate.VehicleId = rentalUpdateDto.VehicleId;
            rentalToUpdate.CollaboratorId = rentalUpdateDto.CollaboratorId;
            rentalToUpdate.StartDateId = rentalUpdateDto.StartDateId;
            rentalToUpdate.EndDateId = rentalUpdateDto.EndDateId;

            await _context.SaveChangesAsync();
            return rentalToUpdate;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Rental> DeleteAsync(int id)
    {
        try
        {
            Rental? rentalToDelete = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);

            if (rentalToDelete == null)
                return null;

            _context.Rentals.Remove(rentalToDelete);
            await _context.SaveChangesAsync();
            return rentalToDelete;
        }
        catch (Exception)
        {
            throw;
        }
    }
}