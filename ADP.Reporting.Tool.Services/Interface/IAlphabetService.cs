using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services
{
    /// <summary>
    /// Defines the contract for services managing alphabets.
    /// </summary>
    public interface IAlphabetService
    {
        /// <summary>
        /// Retrieves all alphabets with pagination.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of alphabets.</returns>
        Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Retrieves an alphabet by its ID.
        /// </summary>
        /// <param name="id">The ID of the alphabet.</param>
        /// <returns>The alphabet with the specified ID.</returns>
        Task<Alphabet> GetAlphabetByIdAsync(int id);

        /// <summary>
        /// Inserts a new alphabet.
        /// </summary>
        /// <param name="alphabet">The alphabet to insert.</param>
        /// <returns>The number of records affected.</returns>
        Task<int> InsertAlphabetAsync(Alphabet alphabet);

        /// <summary>
        /// Updates an existing alphabet.
        /// </summary>
        /// <param name="alphabet">The alphabet to update.</param>
        /// <returns>The number of records affected.</returns>
        Task<int> UpdateAlphabetAsync(Alphabet alphabet);

        /// <summary>
        /// Deletes an alphabet by its ID.
        /// </summary>
        /// <param name="id">The ID of the alphabet to delete.</param>
        /// <returns>The number of records affected.</returns>
        Task<int> DeleteAlphabetAsync(int id);

        /// <summary>
        /// Inserts or updates an alphabet.
        /// </summary>
        /// <param name="alphabet">The alphabet to insert or update.</param>
        /// <returns>The inserted or updated alphabet.</returns>
        Task<Alphabet> UpSertAlphabetAsync(Alphabet alphabet);
    }
}
