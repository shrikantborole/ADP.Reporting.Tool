using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphabetController : ControllerBase
    {
        private readonly IAlphabetService alphabetService;

        public AlphabetController(IAlphabetService alphabetRepository)
        {
            alphabetService = alphabetRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alphabet>>> GetAllAlphabets(int pageNumber = 1, int pageSize = 10)
        {
            var alphabets = await alphabetService.GetAllAlphabetsAsync(pageNumber, pageSize);
            return Ok(alphabets);
        }
    }
}
