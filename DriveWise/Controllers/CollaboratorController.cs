﻿using DTOs.DTOs.CollaboratorDTOs;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers
{
    public class CollaboratorController(
        ICollaboratorRepository collaboratorRepository,
        ILogger<CollaboratorController> logger) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetByIdPerso(int id)
        {
            try
            {
                return Ok(await collaboratorRepository.GetByIdPersoAsync(id));
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                return Ok(await collaboratorRepository.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> GiveAdminRole(int id)
        {
            try
            {
                await collaboratorRepository.GiveAdminRoleAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
    }
}
