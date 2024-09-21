using ADP.Reporting.Tool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.DataServices
{
    /// <summary>
    /// Defines methods for accessing and manipulating alphabet data.
    /// </summary>
    public interface IAlphabetRepository
    {
        /// <summary>
        /// Gets all alphabets with pagination support.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A collection of alphabets.</returns>
        Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Gets an alphabet by its ID.
        /// </summary>
        /// <param name="id">The ID of the alphabet.</param>
        /// <returns>The alphabet with the specified ID, or null if not found.</returns>
        Task<Alphabet> GetAlphabetByIdAsync(int id);

        /// <summary>
        /// Inserts a new alphabet into the database.
        /// </summary>
        /// <param name="alphabet">The alphabet to insert.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> InsertAlphabetAsync(Alphabet alphabet);

        /// <summary>
        /// Updates an existing alphabet.
        /// </summary>
        /// <param name="alphabet">The alphabet to update.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> UpdateAlphabetAsync(Alphabet alphabet);

        /// <summary>
        /// Deletes an alphabet by its ID.
        /// </summary>
        /// <param name="id">The ID of the alphabet to delete.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> DeleteAlphabetAsync(int id);

        /// <summary>
        /// Inserts or updates an alphabet.
        /// </summary>
        /// <param name="alphabet">The alphabet to insert or update.</param>
        /// <returns>The updated or inserted alphabet.</returns>
        Task<Alphabet> UpsertAlphabetAsync(Alphabet alphabet);
    }
}
