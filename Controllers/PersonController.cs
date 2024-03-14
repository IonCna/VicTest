using Microsoft.AspNetCore.Mvc;
using VicTest.Models;
using VicTest.Services;

namespace VicTest.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService = new();

    [HttpPost]
    public ActionResult CreateNewPerson([FromBody] Person target)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo invalido");
            }

            _personService.CreateNewPerson(target);

            List<Person> list = _personService.GetPersonList();

            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to create {ex.Message}");
        }
    }

    [HttpGet]
    public ActionResult GetPersonList()
    {
        try
        {
            var list = _personService.GetPersonList();
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public ActionResult FindByName(string name)
    {
        try
        {
            var target = _personService.FindByName(name);
            return Ok(target);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
