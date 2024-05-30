using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services;

public class AplhabetService : IAlphabetService
{
    private readonly IAlphabetRepository _alphabetRepository;
    public AplhabetService(IAlphabetRepository alphabetRepository)
    {
        _alphabetRepository = alphabetRepository;
    }
    public async Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize)
    {
        var alphabets = await _alphabetRepository.GetAllAlphabetsAsync(pageNumber, pageSize);
        return alphabets;
    }
}