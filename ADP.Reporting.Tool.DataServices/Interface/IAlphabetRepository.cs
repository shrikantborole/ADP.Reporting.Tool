using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.DataServices
{
    public interface IAlphabetRepository
    {
        public Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize);
    }
}