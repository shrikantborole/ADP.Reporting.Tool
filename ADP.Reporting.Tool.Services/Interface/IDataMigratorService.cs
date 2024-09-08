namespace ADP.Reporting.Tool.Services.Interface
{
    /// <summary>
    /// Defines the contract for data migration services.
    /// </summary>
    public interface IDataMigratorService
    {
        /// <summary>
        /// Runs the data migration process.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Run();
    }
}
