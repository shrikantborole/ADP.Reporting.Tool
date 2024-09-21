using ADP.Reporting.Tool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    /// <summary>
    /// Defines methods for managing request information records.
    /// </summary>
    public interface IRequestInformationRepository
    {
        /// <summary>
        /// Inserts a new request information record.
        /// </summary>
        /// <param name="requestInformation">The request information to insert.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertRequestInformationAsync(RequestInformation requestInformation);

        /// <summary>
        /// Updates an existing request information record.
        /// </summary>
        /// <param name="requestInformation">The request information to update.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> UpdateRequestInformationAsync(RequestInformation requestInformation);

        /// <summary>
        /// Deletes a request information record by its ID.
        /// </summary>
        /// <param name="id">The ID of the request information to delete.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> DeleteRequestInformationAsync(int id);

        /// <summary>
        /// Retrieves request information records with pagination support.
        /// </summary>
        /// <param name="pageIndex">The page index for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of request information records.</returns>
        Task<IEnumerable<RequestInformation>> GetRequestInformationsAsync(int pageIndex, int pageSize);

        /// <summary>
        /// Retrieves a request information record by its ID.
        /// </summary>
        /// <param name="id">The ID of the request information to retrieve.</param>
        /// <returns>The request information with the specified ID.</returns>
        Task<RequestInformation> GetRequestInformationByIdAsync(int id);

        /// <summary>
        /// Inserts or updates a request information record.
        /// </summary>
        /// <param name="requestInformation">The request information to insert or update.</param>
        /// <returns>The inserted or updated request information.</returns>
        Task<RequestInformation> UpsertRequestInformationAsync(RequestInformation requestInformation);
    }
}
