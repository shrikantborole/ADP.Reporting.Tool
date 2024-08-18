using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;

namespace ADP.Reporting.Tool.Services
{
    public class ClientInformationService : IClientInformationService
    {
        private readonly IClientInformationRepository _clientInformationRepository;

        public ClientInformationService(IClientInformationRepository clientInformationRepository)
        {
            _clientInformationRepository = clientInformationRepository;
        }

        public async Task<int> InsertClientInformationAsync(ClientInformation clientInformation)
        {
            clientInformation.UpdatedDate = clientInformation.UpdatedDate ?? DateTime.Now;
            clientInformation.CreatedDate = clientInformation.CreatedDate ?? DateTime.Now;
            return await _clientInformationRepository.InsertClientInformationAsync(clientInformation);
        }

        public async Task<int> UpdateClientInformationAsync(ClientInformation clientInformation)
        {
            clientInformation.UpdatedDate = DateTime.Now;
            return await _clientInformationRepository.UpdateClientInformationAsync(clientInformation);
        }

        public async Task<int> DeleteClientInformationAsync(int id)
        {
            return await _clientInformationRepository.DeleteClientInformationAsync(id);
        }

        public async Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize)
        {
            return await _clientInformationRepository.GetClientInformationAsync(pageNumber, pageSize);
        }

        public async Task<ClientInformation> UpSertClientInformationAsync(ClientInformation clientInformation)
        {
            return await _clientInformationRepository.UpSertClientInformationAsync(clientInformation);
        }
    }
}
