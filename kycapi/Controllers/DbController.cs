using kycapi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Route("api/entities")]
[ApiController]
public class DbController : ControllerBase
{
    private readonly DbHelper _entityService;
    private readonly ILogger<DbController> _logger;

    public DbController(DbHelper entityService, ILogger<DbController> logger)
    {
        _entityService = entityService;
        _logger = logger;
    }

    // POST: api/entities
    [HttpPost]
    public IActionResult CreateEntity([FromBody] EntityDto entityDto)
    {
        try
        {
           
            _entityService.CreateEntity(entityDto);
            _logger.LogInformation("POSTED");
            ResponseType type = ResponseType.Success;
            return Ok(ResponseHandler.GetAppResponse(type, entityDto));
        }
        catch (InvalidDataException ex)
        {
            _logger.LogInformation("NOT POSTED");
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type, null));
        }
        catch (Exception ex)
        {
            _logger.LogError("ERROR");
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse(ex));
        }
    }

    // GET: api/entities
    [HttpGet]
    public IActionResult GetEntities([FromQuery] string? addressCountry = null, [FromQuery] string? gender = null, [FromQuery] DateTime? startdate = null, [FromQuery] DateTime? enddate = null, [FromQuery] string? searchQuery = null,
    [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortBy="Id", [FromQuery] string sortDirection="asc")
    {
        int skip = (page - 1) * pageSize;
       

     
        try
        {
            var entities = _entityService.GetEntities(addressCountry, gender, startdate, enddate, searchQuery, skip,
       pageSize, sortBy, sortDirection);
            _logger.LogInformation("FETCHED");
            ResponseType type = ResponseType.Success;
            return Ok(ResponseHandler.GetAppResponse(type, entities));
        }
        catch (InvalidDataException ex)
        {
            _logger.LogInformation("NOT FETCHED");
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type, null));
        }
        catch (Exception ex)
        {
            _logger.LogError("ERROR");
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse(ex));
        }

    }


    // Getbyid: api/entities/{id}   
    [HttpGet("{id}")]
    public IActionResult Getbyid(string id)
    {
        

        try
        {
            var entity = _entityService.Getbyid(id);
            _logger.LogInformation("FETCHED");
            ResponseType type = ResponseType.Success;
            return Ok(ResponseHandler.GetAppResponse(type, entity));
          
        }
        catch(InvalidDataException ex)
        {
            _logger.LogInformation("ID NOT FOUND");
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type,null));
       
        }
        catch (Exception ex)
        {
            _logger.LogError("ERROR");
            return  StatusCode(StatusCodes.Status500InternalServerError,ResponseHandler.GetExceptionResponse(ex));
        }
    }


    // PUT: api/entities/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateEntity(string id, [FromBody] EntityDto entityDto)
    {
      

        try
        {
            ResponseType type = ResponseType.Success;
            _entityService.UpdateEntity(id, entityDto);
            _logger.LogInformation("UPDATED");
            return Ok(type);
        }
        catch (InvalidDataException ex)
        {
            _logger.LogInformation("ID NOT FOUND");
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type,null));
        }
        catch (Exception ex)
        {
            _logger.LogError("ERROR");
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse(ex));
        }

    }

    // DELETE: api/entities/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteEntity(string id)
    {
       

        try
        {
            _entityService.DeleteEntity(id);
            _logger.LogInformation("DELETED");
            ResponseType type = ResponseType.Success;
            return Ok(type);
        }
        catch (InvalidDataException ex)
        {
            _logger.LogInformation("ID NOT FOUND");
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type, null));
        }
        catch (Exception ex)
        {
            _logger.LogError("ERROR");
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse(ex));
        }
    }

   
}