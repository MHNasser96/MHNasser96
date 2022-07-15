using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UMS.Domain.Models;

namespace UMS.WebApi.Controllers;
[ApiController]
 [Route("odata/[controller]")]
public class SessionTimeController : ODataController
{
    private readonly UmsContext _context;
    private readonly ILogger<SessionTimeController> _logger;
    
    public SessionTimeController(UmsContext context, ILogger<SessionTimeController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    [EnableQuery(PageSize = 15)]
    [HttpGet]
    public IQueryable<SessionTime> GetR()
    {
        return _context.SessionTimes;
    }
    
    [EnableQuery]
    [HttpGet("one")]
    public SingleResult<SessionTime> GetOne([FromODataUri] long key)
    {
        var result = _context.SessionTimes.Where(c => c.Id == key);
        return SingleResult.Create(result);
    }
    
    
    /*[EnableQuery]
    public async Task<IActionResult> Post([FromBody] SessionTime sessionTime)
    {
        _context.SessionTimes.Add(sessionTime);
        await _context.SaveChangesAsync();
        return Created(sessionTime);
    }
    
    
    [EnableQuery]
    public async Task<IActionResult> Delete([FromODataUri] long key)
    {
        SessionTime existingSessionTime = await _context.SessionTimes.FindAsync(key);
        if (existingSessionTime == null)
        {
            return NotFound();
        }
    
        _context.SessionTimes.Remove(existingSessionTime);
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status204NoContent);
    }
    
    private bool SessionTimeExisting(long key)
    {
        return _context.SessionTimes.Any(p => p.Id == key);
    }*/
}