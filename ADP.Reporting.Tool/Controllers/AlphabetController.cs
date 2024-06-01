using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Alphabet>> GetAlphabetById(int id)
        {
            var alphabet = await alphabetService.GetAlphabetByIdAsync(id);
            if (alphabet == null)
            {
                return NotFound();
            }
            return Ok(alphabet);
        }

        [HttpPost]
        public async Task<ActionResult<Alphabet>> InsertAlphabet([FromBody]Alphabet alphabet)
        {
            if (!ModelState.IsValid)
            {
                // Log or inspect the ModelState errors
                return BadRequest(ModelState);
            }
            var response = await alphabetService.InsertAlphabetAsync(alphabet);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlphabet(int id, [FromBody] Alphabet alphabet)
        {
            if (id != alphabet.Id)
            {
                return BadRequest();
            }

            var result = await alphabetService.UpdateAlphabetAsync(alphabet);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlphabet(int id)
        {
            var result = await alphabetService.DeleteAlphabetAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
