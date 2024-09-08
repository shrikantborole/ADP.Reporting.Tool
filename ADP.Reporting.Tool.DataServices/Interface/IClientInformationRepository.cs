using ADP.Reporting.Tool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    /// <summary>
    /// Defines methods for managing client information.
    /// </summary>
    public interface IClientInformationRepository
    {
        /// <summary>
        /// Inserts a new client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to insert.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertClientInformationAsync(ClientInformation clientInformation);

        /// <summary>
        /// Updates an existing client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to update.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> UpdateClientInformationAsync(ClientInformation clientInformation);

        /// <summary>
        /// Deletes a client information record by its ID.
        /// </summary>
        /// <param name="id">The ID of the client information to delete.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> DeleteClientInformationAsync(int id);

        /// <summary>
        /// Retrieves client information with pagination support.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of client information records.</returns>
        Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Inserts or updates client information.
        /// </summary>
        /// <param name="clientInformation">The client information to insert or update.</param>
        /// <returns>The inserted or updated client information.</returns>
        Task<ClientInformation> UpsertClientInformationAsync(ClientInformation clientInformation);
    }
}
