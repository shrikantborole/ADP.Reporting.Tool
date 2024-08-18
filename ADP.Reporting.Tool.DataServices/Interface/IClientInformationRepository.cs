using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    public interface IClientInformationRepository
    {
        Task<int> InsertClientInformationAsync(ClientInformation clientInformation);
        Task<int> UpdateClientInformationAsync(ClientInformation clientInformation);
        Task<int> DeleteClientInformationAsync(int id);
        Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize);
        Task<ClientInformation> UpSertClientInformationAsync(ClientInformation clientInformation);

    }
}
