using ADP.Reporting.Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP.Reporting.Tool.Services
{
    public interface IAlphabetService
    {
        public Task<IEnumerable<Alphabet>> GetAllAlphabetsAsync(int pageNumber, int pageSize);
    }
}
