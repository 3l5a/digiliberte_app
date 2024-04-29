using Services.DTOs.RentalDTOs;
using Services.DTOs.VehicleDTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;

using Repositories.Contracts;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

//    [Authorize(Roles = "ADMIN")]
//    [Authorize]

public class RentalController(IRentalRepository rentalRepository) : ControllerBase
{

    /// <summary>
    /// Get all currents rentals A VERIFIER
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllCurrent()
    {
        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllCurrentAsync();

            return listRentalsDto == null ? NotFound() : Ok(listRentalsDto);
        }
        catch (Exception)
        {
            throw;
        }
    }


    /// <summary>
    /// Get all past rentals A VERIFIER
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllPast()
    {
        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllPastAsync();

            return listRentalsDto == null ? NotFound() : Ok(listRentalsDto);
        }
        catch (Exception)
        {
            throw;
        }
    }







    // /// <summary>
    // /// Get one rental by Id A VERIFIER
    // /// </summary>
    // /// <param name="id"></param>
    // /// <returns></returns>

    // [ProducesResponseType(200)]
    // [ProducesResponseType(400)]
    // [ProducesResponseType(404)]
    // [ProducesResponseType(500)]

    // [HttpGet]

    // public async Task<ActionResult<RentalGetDto>> GetRentalById(int id)
    // {
    //     if (id <= 0)
    //         return BadRequest("\"Id\" must be a positive number");

    //     try
    //     {
    //         RentalGetDto oneRentalDto = await rentalRepository.GetByIdAsync(id);
    //         return oneRentalDto == null ? NotFound() : Ok(oneRentalDto);
    //     }
    //     catch (Exception)
    //     {
    //         throw;
    //     }
    // }




    /// <summary>
    /// Create a new rental A VERIFIER
    /// </summary>
    /// <param name="rentalAddDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<RentalAddDto>> Add(RentalAddDto rentalAddDto)
    {
        try
        {
            RentalAddDto rentalToCreate = await rentalRepository.AddAsync(rentalAddDto);

            return Ok($"Your rental has been successfully created and will start on {rentalToCreate.StartDateId.ToShortDateString}");
        }
        catch (Exception)
        {
            throw;
        }
    }


    /// <summary>
    ///  Update a rental A VERIFIER
    /// </summary>
    /// <param name="rentalUpdateDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpPut]

    public async Task<ActionResult<Rental>> Update(RentalUpdateDto rentalUpdateDto)
    {
        if (rentalUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        if (rentalUpdateDto.EndDateId <= rentalUpdateDto.StartDateId)
            return BadRequest("Ending rental date must be later than starting rental date");

        try
        {
            Rental rentalToUpdate = await rentalRepository.UpdateAsync(rentalUpdateDto);

            return rentalUpdateDto == null ? NotFound() : Ok("Your rental has been successfully updated");
        }
        catch (Exception)
        {
            throw;
        }
    }


    /// <summary>
    /// Delete a rental A VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpDelete]

    public async Task<ActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            Rental rentalToDelete = await rentalRepository.DeleteAsync(id);

            return rentalToDelete == null ? NotFound() : Ok($"The rental has been successfully deleted");
        }
        catch (Exception)
        {
            throw;
        }
    }

}