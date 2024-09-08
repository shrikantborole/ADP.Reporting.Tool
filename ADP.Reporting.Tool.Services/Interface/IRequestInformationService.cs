using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services.Interface
{
    /// <summary>
    /// Defines the contract for request information services.
    /// </summary>
    public interface IRequestInformationService
    {
        /// <summary>
        /// Inserts a new request information record asynchronously.
        /// </summary>
        /// <param name="requestInformation">The request information to insert.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> InsertRequestInformationAsync(RequestInformation requestInformation);

        /// <summary>
        /// Updates an existing request information record asynchronously.
        /// </summary>
        /// <param name="requestInformation">The request information to update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation);

        /// <summary>
        /// Deletes a request information record asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the request information to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of rows affected.</returns>
        Task<int> DeleteRequestInformationAsync(int id);

        /// <summary>
        /// Retrieves a list of request information records asynchronously, with pagination.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of request information records.</returns>
        Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Retrieves a request information record asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the request information to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the request information if found, otherwise null.</returns>
        Task<RequestInformation> GetRequestInformationByIdAsync(int id);

        /// <summary>
        /// Inserts or updates a request information record asynchronously.
        /// </summary>
        /// <param name="requestInformation">The request information to insert or update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the inserted or updated request information.</returns>
        Task<RequestInformation> UpSertRequestInformationAsync(RequestInformation requestInformation);
    }
}
