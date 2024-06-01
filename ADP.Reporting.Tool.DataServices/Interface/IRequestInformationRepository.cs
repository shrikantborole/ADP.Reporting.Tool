using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    public interface IRequestInformationRepository
    {
        Task<int> InsertRequestInformationAsync(RequestInformation requestInformation);
        Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation);
        Task<int> DeleteRequestInformationAsync(int id);
        Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageIndex, int pageSize);
        Task<RequestInformation> GetRequestInformationByIdAsync(int id);
    }
}
