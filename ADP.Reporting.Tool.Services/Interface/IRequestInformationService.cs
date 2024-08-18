using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services.Interface
{
    public interface IRequestInformationService
    {
        Task<int> InsertRequestInformationAsync(RequestInformation requestInformation);
        Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation);
        Task<int> DeleteRequestInformationAsync(int id);
        Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageNumber, int pageSize);
        Task<RequestInformation> GetRequestInformationByIdAsync(int id);
        Task<RequestInformation> UpSertRequestInformationAsync(RequestInformation requestInformation);
    }
}
