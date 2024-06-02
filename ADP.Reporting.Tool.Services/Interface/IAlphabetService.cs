using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services
{
    public interface IAlphabetService
    {
        public Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize);
        Task<Alphabet> GetAlphabetByIdAsync(int id);
        Task<Alphabet> InsertAlphabetAsync(Alphabet alphabet);
        Task<bool> UpdateAlphabetAsync(Alphabet alphabet);
        Task<bool> DeleteAlphabetAsync(int id);
    }
}
