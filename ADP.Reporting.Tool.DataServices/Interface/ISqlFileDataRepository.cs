using ADP.Reporting.Tool.Models;

namespace ADP.Reporting.Tool.DataServices.Interface
{
    public interface ISqlFileDataRepository
    {
        Task<int> InsertSqlFileDataAsync(SqlFileData sqlFileData);
        Task<int> UpdateSqlFileDataAsync(SqlFileData sqlFileData);
        Task<int> DeleteSqlFileDataAsync(int id);
        Task<IEnumerable<SqlFileData>> GetSqlFileDatasAsync(int pageIndex, int pageSize);
        Task<SqlFileData> GetSqlFileDataByIdAsync(int id);
        Task<SqlFileData> UpSertSqlFileDataAsync(SqlFileData sqlFileData);
    }
}
