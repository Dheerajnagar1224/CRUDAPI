using kycapi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
    [Route("api/[controller]/CreateEntity")]

    public IActionResult CreateEntity([FromBody] EntityDto entityDto)
    {
        try
        {
           
            _entityService.CreateEntity(entityDto); 
            _logger.LogInformation("CreateEntity => POSTED");
            ResponseType type = ResponseType.Success;
            return Ok(ResponseHandler.GetAppResponse(type, entityDto));
        }
        catch (InvalidDataException ex)
        {
            _logger.LogError("CreateEntity => NOT POSTED",ex.Message);
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type, null));
        }
        catch (Exception ex)
        {
            _logger.LogError("CreateEntity => ERROR", ex.Message);  
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse("Something went wrong"));
        }
    }

    // GET: api/entities
    [HttpGet]
    [Route("api/[controller]/GetEntities")]

    public IActionResult GetEntities([FromQuery] string? addressCountry = null, [FromQuery] string? gender = null, [FromQuery] DateTime? startdate = null, [FromQuery] DateTime? enddate = null, [FromQuery] string? searchQuery = null,
    [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortBy="Id", [FromQuery] string sortDirection="asc")
    {
        int skip = (page - 1) * pageSize;
       

     
        try
        {
            var entities = _entityService.GetEntities(addressCountry, gender, startdate, enddate, searchQuery, skip,
       pageSize, sortBy, sortDirection);
            _logger.LogInformation("GetEntities => FETCHED");
            ResponseType type = ResponseType.Success;
            return Ok(ResponseHandler.GetAppResponse(type, entities));
        }
        catch (InvalidDataException ex)
        {
            _logger.LogError("GetEntities => NOT FETCHED", ex.Message);
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type, null));
        }
        catch (Exception ex)
        {
            _logger.LogError("GetEntities => ERROR", ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse("Something went wrong"));
        }

    }


    // Getbyid: api/entities/{id}   
    [HttpGet]
    [Route("api/[controller]/Getbyid/{id}")]

    public IActionResult Getbyid(string id)
    {
        

        try
        {
            var entity = _entityService.Getbyid(id);
            _logger.LogInformation("Getbyid => FETCHED");
            ResponseType type = ResponseType.Success;
            return Ok(ResponseHandler.GetAppResponse(type, entity));
          
        }
        catch(InvalidDataException ex)
        {
            _logger.LogError("Getbyid => ID NOT FOUND", ex.Message);
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type,null));
       
        }
        catch (Exception ex)
        {
            _logger.LogError("Getbyid => ERROR", ex.Message);
            return  StatusCode(StatusCodes.Status500InternalServerError,ResponseHandler.GetExceptionResponse("Something went wrong"));
        }
    }


    // PUT: api/entities/{id}
    [HttpPut]
    [Route("api/[controller]/UpdateEntity/{id}")]
    public IActionResult UpdateEntity(string id, [FromBody] EntityDto entityDto)
    {
      

        try
        {
            ResponseType type = ResponseType.Success;
            _entityService.UpdateEntity(id, entityDto);
            _logger.LogInformation("UpdateEntity => UPDATED");
               return Ok(ResponseHandler.GetAppResponse(type,null));
        }
        catch (InvalidDataException ex)
        {
            _logger.LogError("UpdateEntity => ID NOT FOUND", ex.Message);
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type,null));
        }
        catch (Exception ex)
        {
            _logger.LogError("UpdateEntity => ERROR", ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse("Something went wrong"));
        }

    }

    // DELETE: api/entities/{id}
    [HttpDelete]
    [Route("api/[controller]/DeleteEntity/{id}")]
    public IActionResult DeleteEntity(string id)
    {
       

        try
        {
            _entityService.DeleteEntity(id);
            _logger.LogInformation("DeleteEntity => DELETED");
            ResponseType type = ResponseType.Success;
            return Ok(ResponseHandler.GetAppResponse(type,null));
        }
        catch (InvalidDataException ex)
        {
            _logger.LogError("DeleteEntity => ID NOT FOUND",ex.Message);
            ResponseType type = ResponseType.Notfound;
            return NotFound(ResponseHandler.GetAppResponse(type, null));
        }
        catch (Exception ex)
        {
            _logger.LogError("DeleteEntity => ERROR", ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.GetExceptionResponse("Something went wrong"));
        }
     
    }

   
}