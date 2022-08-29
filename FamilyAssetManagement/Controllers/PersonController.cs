using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyAssetManagement;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly FamilyAssetManagementDbContext _familyAssetManagementDbContext;
    public PersonController(FamilyAssetManagementDbContext familyAssetManagementDbContext)
    {
        _familyAssetManagementDbContext = familyAssetManagementDbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var persons = await _familyAssetManagementDbContext.Person.ToListAsync();
        return Ok(persons);
    }
    [HttpGet]
    [Route("get-person-by-id")]
    public async Task<IActionResult> GetPersonByIdAsync(int id)
    {
        var person = await _familyAssetManagementDbContext.Person.FindAsync(id);
        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Person person)
    {
        _familyAssetManagementDbContext.Person.Add(person);
        await _familyAssetManagementDbContext.SaveChangesAsync();
        return Created($"/get-person-by-id?id={person.Id}", person);
    }
    [HttpPut]
    public async Task<IActionResult> PutAsync(Person personToUpdate)
    {
        _familyAssetManagementDbContext.Person.Update(personToUpdate);
        await _familyAssetManagementDbContext.SaveChangesAsync();
        return NoContent();
    }
    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var personToDelete = await _familyAssetManagementDbContext.Person.FindAsync(id);
        if (personToDelete == null)
        {
            return NotFound();
        }
        _familyAssetManagementDbContext.Person.Remove(personToDelete);
        await _familyAssetManagementDbContext.SaveChangesAsync();
        return NoContent();
    }
}