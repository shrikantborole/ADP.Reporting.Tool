﻿using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services
{
    public interface IAlphabetService
    {
        public Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize);
        Task<Alphabet> GetAlphabetByIdAsync(int id);
        Task<int> InsertAlphabetAsync(Alphabet alphabet);
        Task<int> UpdateAlphabetAsync(Alphabet alphabet);
        Task<int> DeleteAlphabetAsync(int id);
        Task<Alphabet> UpSertAlphabetAsync(Alphabet alphabet);
    }
}
