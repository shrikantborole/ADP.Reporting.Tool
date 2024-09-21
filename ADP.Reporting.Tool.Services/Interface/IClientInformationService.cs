using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services.Interface
{
    /// <summary>
    /// Defines the contract for services managing client information.
    /// </summary>
    public interface IClientInformationService
    {
        /// <summary>
        /// Inserts a new client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to insert.</param>
        /// <returns>The number of records affected.</returns>
        Task<int> InsertClientInformationAsync(ClientInformation clientInformation);

        /// <summary>
        /// Updates an existing client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to update.</param>
        /// <returns>The number of records affected.</returns>
        Task<int> UpdateClientInformationAsync(ClientInformation clientInformation);

        /// <summary>
        /// Deletes a client information record by its ID.
        /// </summary>
        /// <param name="id">The ID of the client information record to delete.</param>
        /// <returns>The number of records affected.</returns>
        Task<int> DeleteClientInformationAsync(int id);

        /// <summary>
        /// Retrieves client information records with pagination.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of client information records.</returns>
        Task<IEnumerable<ClientInformation>> GetClientInformationAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Inserts or updates a client information record.
        /// </summary>
        /// <param name="clientInformation">The client information to insert or update.</param>
        /// <returns>The inserted or updated client information record.</returns>
        Task<ClientInformation> UpSertClientInformationAsync(ClientInformation clientInformation);
    }
}
