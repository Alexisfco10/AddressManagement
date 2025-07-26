using Application.Dtos.Customer;
using Application.Services.Interface;
using Asp.Versioning;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Web.ApiUtils;

namespace Web.Controllers;

[ApiController]
[ApiVersion(1)]
[Route($"{ApiCons.Base}[controller]")]
public class CustomerController(
    ICustomerService service,
    IValidator<CustomerInsert> insertValidator,
    IValidator<CustomerUpdate> updateValidator
    ) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
    {
        try
        {
            return Ok(await service.Get());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto?>> Get([FromRoute] int id)
    {
        try
        {
            var result = await service.Get(id);
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Post([FromBody] CustomerInsert customer)
    {
        try
        {
            var request = await insertValidator.ValidateAsync(customer);
            if (!request.IsValid)
                return BadRequest(request.Errors);

            return Ok(await service.Add(customer));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<CustomerDto>> Put([FromBody] CustomerUpdate customer)
    {
        try
        {
            var request = await updateValidator.ValidateAsync(customer);
            if (!request.IsValid)
                return BadRequest(request.Errors);

            var result = await service.Update(customer);
            if (result == null)
                return BadRequest("Invalid Id");
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            if (await service.Delete(id))
                return Ok();
        
            return NotFound();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}