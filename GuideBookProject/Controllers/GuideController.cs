using GuideBookProject.Models;
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


        [HttpPost("AddPerson")]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest();
                }

                var persons = await _guideRepository.Add_Person(person);

                //return Ok(persons);
                
                return CreatedAtAction(nameof(GetPerson), new { id = persons.UserID }, persons);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new person record!..");
            }
        }


        [HttpDelete("{Id:int}", Name = "DeletePerson")]
        public async Task<ActionResult> DeletePerson(int Id)
        {
            try
            {
                await _guideRepository.Delete_Person(Id);

                return Ok($"Person with User Id = {Id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting new person record!..");
            }
        }


        [HttpDelete("{Id:int}", Name = "RemovePerson")]
        public async Task<ActionResult> RemovePerson(int Id)
        {
            try
            {           
                await _guideRepository.Remove_Person(Id);

                return Ok($"Person with User Id = {Id} removed");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing new person record!..");
            }
        }


        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Person>> GetPerson(int Id)
        {
            try
            {
                var result = await _guideRepository.Get_Person(Id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriewing data from the database!..");
            }
        }


        [HttpGet("GetPersons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            try
            {
                var persons = await _guideRepository.Get_Persons();

                return Ok(persons);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriewing data from the database!..");
            }
        }


        [HttpPut("UpdatePerson")]
        public async Task<ActionResult<Person>> UpdatePerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest();
                }

                var result = await _guideRepository.Update_Person(person);

                return Ok(result);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating new person record!..");
            }
        }


        [HttpPost("AddCommInfo")]
        public async Task<ActionResult<CommInfo>> AddCommInfo(CommInfo commInfo)
        {
            try
            {
                if (commInfo == null)
                {
                    return BadRequest();
                }

                var commInfos = await _guideRepository.Add_CommInfo(commInfo);

                return CreatedAtAction(nameof(GetCommInfo), new { id = commInfos.CommInfoID }, commInfos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new commInfo record!..");
            }
        }


        [HttpDelete("{Id:int}", Name = "RemoveCommInfo")]
        public async Task<ActionResult> RemoveCommInfo(int Id)
        {
            try
            {              
                await _guideRepository.Remove_CommInfo(Id);

                return Ok($"CommInfo with User Id = {Id} removed");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing new CommInfo record!..");
            }
        }


        [HttpGet("{Id:int}", Name = "GetCommInfo")]
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
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriewing data from the database!..");
            }
        }


        //[HttpGet(Name = "Report")]
        //public async Task<ActionResult<Person>> Report()
        //{

        //}


        [HttpGet("Reportx")]
        public async Task<ActionResult<List<Report>>> Reportx()
        {
            try
            {
                var result = await _guideRepository.Reportx();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriewing data from the database!..");
            }
        }
    }
}
