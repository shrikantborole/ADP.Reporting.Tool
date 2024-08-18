using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.Services.Interface
{
    public interface ISqlFileDataService
    {
        Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData);
        Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData);
        Task<int> DeleteSqlFileDataAsync(int id);
        Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageNumber, int pageSize);
        Task<SqlFileData> GetSqlFileDataByIdAsync(int id);
        Task<SqlFileData> UpSertSqlFileDataAsync(SqlFileData sqlFileData);
    }
}
