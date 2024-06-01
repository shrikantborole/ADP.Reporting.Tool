using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;

namespace ADP.Reporting.Tool.Services
{
    public class RequestInformationService : IRequestInformationService
    {
        private readonly IRequestInformationRepository _requestInformationRepository;

        public RequestInformationService(IRequestInformationRepository requestInformationRepository)
        {
            _requestInformationRepository = requestInformationRepository;
        }

        public async Task<int> InsertRequestInformationAsync(RequestInformation requestInformation)
        {
            return await _requestInformationRepository.InsertRequestInformationAsync(requestInformation);
        }

        public async Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation)
        {
            return await _requestInformationRepository.UpdateRequestInformationAsync(requestInformation);
        }

        public async Task<int> DeleteRequestInformationAsync(int id)
        {
            return await _requestInformationRepository.DeleteRequestInformationAsync(id);
        }

        public async Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageIndex, int pageSize)
        {
            return await _requestInformationRepository.GetRequestInformationsAsync(pageIndex, pageSize);
        }

        public async Task<RequestInformation> GetRequestInformationByIdAsync(int id)
        {
            return await _requestInformationRepository.GetRequestInformationByIdAsync(id);
        }
    }
}
