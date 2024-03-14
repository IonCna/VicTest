using Microsoft.AspNetCore.Mvc;
using VicTest.Handlers;
using VicTest.Models;
using VicTest.Services.Interfaces;

namespace VicTest.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PersonController(IPersonService personService) : ControllerBase
{
    private readonly IPersonService _personService = personService;

    [HttpPost]
    public ActionResult CreateNewPerson([FromBody] Person target)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo invalido");
            }

            List<Person> list = _personService.InsertOne(target);
            return Ok(list);
        }
        catch (ErrorHandler error)
        {
            Response.StatusCode = (int)error.StatusCode;
            return new JsonResult(new { message = error.Message });
        }
        catch (Exception ex)
        {
            Response.StatusCode = 500;
            return new JsonResult(new { message = ex.Message });
        }
    }

    [HttpGet]
    public ActionResult GetPersonList()
    {
        try
        {
            var list = _personService.FindAll();
            return Ok(list);
        }
        catch (ErrorHandler error)
        {
            Response.StatusCode = (int)error.StatusCode;
            return new JsonResult(new { message = error.Message });
        }
        catch (Exception ex)
        {
            Response.StatusCode = 500;
            return new JsonResult(new { message = ex.Message });
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
