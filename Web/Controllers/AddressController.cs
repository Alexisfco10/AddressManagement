using Application.Dtos.Address;
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
public class AddressController(
    IAddressService service,
    IValidator<AddressInsert> insertValidator,
    IValidator<AddressUpdate> updateValidator
    ) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Address>>> Get()
    {
        return Ok(await service.Get());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Address>> Get([FromRoute]int id)
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
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Address>> Post([FromBody] AddressInsert address)
    {
        try
        {
            var request = await insertValidator.ValidateAsync(address);
            if (!request.IsValid)
                return BadRequest(request.Errors);
            
            return Ok(await service.Add(address));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Address>> Put([FromBody] AddressUpdate address)
    {
        try
        {
            var request = await updateValidator.ValidateAsync(address);
            if (!request.IsValid)
                return BadRequest(request.Errors);
            
            return Ok(await service.Update(address));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
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