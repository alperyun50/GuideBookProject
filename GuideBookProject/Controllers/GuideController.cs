﻿using GuideBookProject.Models;
using GuideBookProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideRepository _guideRepository;

        public GuideController(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }


        [HttpPost]
        public async Task<ActionResult> AddPerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest();
                }

                var persons = await _guideRepository.Add_Person(person);

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new person record!..");
            }
        }


        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeletePerson(int Id)
        {
            try
            {
                var persontodelete = await _guideRepository.Get_Person(Id);

                if (persontodelete == null)
                {
                    return NotFound();
                }

                await _guideRepository.Delete_Person(Id);

                return Ok($"Person with User Id = {Id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting new person record!..");
            }
        }


        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> RemovePerson(int Id)
        {
            try
            {
                var persontoremove = await _guideRepository.Get_Person(Id);

                if (persontoremove == null)
                {
                    return NotFound();
                }

                await _guideRepository.Remove_Person(Id);

                return Ok($"Person with User Id = {Id} removed");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing new person record!..");
            }
        }


        //[HttpGet("{Id:int}")]
        //public async Task<IActionResult<Person>> GetPerson(int Id)
        //{

        //}


        [HttpGet]
        public async Task<ActionResult> GetPersons()
        {
            try
            {
                var persons = await _guideRepository.Get_Persons();

                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriewing data from the database!..");
            }
        }


        [HttpPut("{Id:int}")]
        public async Task<ActionResult<Person>> UpdatePerson(int Id, Person person)
        {
            try
            {
                if(Id != person.UserID)
                {
                    return BadRequest("");
                }

                var persontoupdate = await _guideRepository.Get_Person(Id);

                if(persontoupdate == null)
                {
                    return NotFound();
                }

                return await _guideRepository.Update_Person(person);

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating new person record!..");
            }
        }


        [HttpPost]
        public async Task<ActionResult<CommInfo>> AddCommInfo(CommInfo commInfo)
        {
            try
            {
                if (commInfo == null)
                {
                    return BadRequest();
                }

                var commInfos = await _guideRepository.Add_CommInfo(commInfo);

                return Ok(commInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new commInfo record!..");
            }
        }


        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> RemoveCommInfo(int Id)
        {
            try
            {
                var commInfotoremove = await _guideRepository.Get_CommInfo(Id);

                if (commInfotoremove == null)
                {
                    return NotFound();
                }

                await _guideRepository.Remove_CommInfo(Id);

                return Ok($"CommInfo with User Id = {Id} removed");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing new CommInfo record!..");
            }
        }


        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CommInfo>> GetCommInfo(int Id)
        {
            try 
            {
                var result = await _guideRepository.Get_CommInfo(Id);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriewing data from the database!..");
            }
        }


        //[HttpGet]
        //public async Task<ActionResult<Person>> LocationReport()
        //{

        //}
    }
}
