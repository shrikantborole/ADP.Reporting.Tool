using ADP.Reporting.Tool.DataServices;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services;

public class AlphabetService : IAlphabetService
{
    private readonly IAlphabetRepository _alphabetRepository;
    public AlphabetService(IAlphabetRepository alphabetRepository)
    {
        _alphabetRepository = alphabetRepository;
    }

    public async Task<int> DeleteAlphabetAsync(int id)
    {
       return await _alphabetRepository.DeleteAlphabetAsync(id);
    }

    public async Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize)
    {
        var alphabets = await _alphabetRepository.GetAllAlphabetsAsync(pageNumber, pageSize);
        return alphabets;
    }

    public async Task<Alphabet> GetAlphabetByIdAsync(int id)
    {
        return await _alphabetRepository.GetAlphabetByIdAsync(id);
    }

    public async Task<int> InsertAlphabetAsync(Alphabet alphabet)
    {
        alphabet.UpdatedDate = alphabet.UpdatedDate ?? DateTime.Now;
        alphabet.CreatedDate = alphabet.CreatedDate ?? DateTime.Now;
        return await _alphabetRepository.InsertAlphabetAsync(alphabet);
    }

    public async Task<int> UpdateAlphabetAsync(Alphabet alphabet)
    {
        alphabet.UpdatedDate = DateTime.Now;
        return await _alphabetRepository.UpdateAlphabetAsync(alphabet);
    }

    public async Task<Alphabet> UpSertAlphabetAsync(Alphabet alphabet)
    {
        return await _alphabetRepository.UpSertAlphabetAsync(alphabet);
    }
}