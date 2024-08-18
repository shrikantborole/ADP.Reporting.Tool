using ADP.Reporting.Tool.DataServices.Interface;
using ADP.Reporting.Tool.Models;
using ADP.Reporting.Tool.Services.Interface;

namespace ADP.Reporting.Tool.Services
{
    public class SqlFileDataService : ISqlFileDataService
    {
        private readonly ISqlFileDataRepository _sqlFileDataRepository;

        public SqlFileDataService(ISqlFileDataRepository sqlFileDataRepository)
        {
            _sqlFileDataRepository = sqlFileDataRepository;
        }

        public async Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData)
        {
            return await _sqlFileDataRepository.InsertSqlFileDataAsync(sqlFileData);
        }

        public async Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData)
        {
            return await _sqlFileDataRepository.UpdateSqlFileDataAsync(sqlFileData);
        }

        public async Task<int> DeleteSqlFileDataAsync(int id)
        {
            return await _sqlFileDataRepository.DeleteSqlFileDataAsync(id);
        }

        public async Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageIndex, int pageSize)
        {
            return await _sqlFileDataRepository.GetSqlFileDatasAsync(pageIndex, pageSize);
        }

        public async Task<SqlFileData> GetSqlFileDataByIdAsync(int id)
        {
            return await _sqlFileDataRepository.GetSqlFileDataByIdAsync(id);
        }

        public async Task<SqlFileData> UpSertSqlFileDataAsync(SqlFileData sqlFileData)
        {
            return await _sqlFileDataRepository.UpSertSqlFileDataAsync(sqlFileData);
        }
    }
}
