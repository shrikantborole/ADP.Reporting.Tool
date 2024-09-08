using ADP.Reporting.Tool.Models.Configurations;
using ADP.Reporting.Tool.Models.Internal;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ADP.Reporting.Tool.Services
{
    /// <summary>
    /// Service to handle the migration of client, alphabet, and related data.
    /// </summary>
    public class DataMigratorService : IDataMigratorService, IDisposable
    {
        // Track whether Dispose has been called.
        private bool _disposed = false;
        private readonly ILogger<DataMigratorService> _logger;
        private readonly IOptionsSnapshot<MigrationConfiguration> _optionSnapShot;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IAlphabetService _alphabetService;
        private readonly IClientInformationService _clientInformationService;
        private readonly IReportTypeService _reportTypeService;
        private readonly IRequestInformationService _requestInformationService;
        private readonly ISqlFileDataService _sqlFileDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataMigratorService"/> class.
        /// </summary>
        public DataMigratorService(ILogger<DataMigratorService> logger, IOptionsSnapshot<MigrationConfiguration> optionSnapShot, ILoggerFactory loggerFactory,
            IAlphabetService alphabetService,
            IClientInformationService clientInformationService,
            IReportTypeService reportTypeService,
            IRequestInformationService requestInformationService,
            ISqlFileDataService sqlFileDataService
            )
        {
            _logger = logger;
            _optionSnapShot = optionSnapShot;
            _loggerFactory = loggerFactory;
            _alphabetService = alphabetService;
            _clientInformationService = clientInformationService;
            _reportTypeService = reportTypeService;
            _requestInformationService = requestInformationService;
            _sqlFileDataService = sqlFileDataService;

        }

        /// <summary>
        /// Starts the data migration process.
        /// </summary>
        public async Task Run()
        {
            try
            {
                _logger.LogInformation("Data migration process started.");
                await PopulateClientAlphabet();
                _logger.LogInformation("Data migration process completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while running the data migration process.");
                throw;
            }
        }


        /// <summary>
        /// Populates the alphabet data for clients to be migrated.
        /// </summary>
        private async Task PopulateClientAlphabet()
        {
            try
            {
                _logger.LogInformation($"{GetType().FullName} : {System.Reflection.MethodBase.GetCurrentMethod().Name} Started.");
                string? path = _optionSnapShot?.Value?.Path;
                string? clientsToMigrate = _optionSnapShot?.Value?.ClientsToMigrate;

                if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(clientsToMigrate))
                {
                    throw new ArgumentException("Path and ClientsToMigrate should not be empty.");
                }

                MigrationContext migrationContext = new MigrationContext();
                foreach (string clientName in clientsToMigrate.Split(','))
                {
                    var alphabet = await _alphabetService.UpSertAlphabetAsync(new Models.Alphabet()
                    {
                        Name = clientName,
                        Description = "Migration Script - Inserted Record",
                        CreatedBy = "MigrationUser",
                        UpdatedBy = "MigrationUser",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    });

                    migrationContext.AlphabetId = alphabet.Id;
                    _logger.LogInformation($"Migration: UpSert Alphabet : '{clientName}' with Id '{migrationContext.AlphabetId}' done.");
                    await PopulateClient($"{path}\\{clientName}", migrationContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while populating client alphabet data.");
                throw;
            }
        }


        /// <summary>
        /// Populates the client data.
        /// </summary>
        /// <param name="clientPath">The path of the client.</param>
        /// <param name="migrationContext">The context of the migration.</param>
        private async Task PopulateClient(string clientPath, MigrationContext migrationContext)
        {
            try
            {
                _logger.LogInformation($"{GetType().FullName} : {System.Reflection.MethodBase.GetCurrentMethod().Name} Started.");
                string? path = _optionSnapShot?.Value?.Path;
                string? clientsToMigrate = _optionSnapShot?.Value?.ClientsToMigrate;

                if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(clientsToMigrate))
                {
                    throw new ArgumentException("Path and ClientsToMigrate should not be empty.");
                }

                foreach (string clientName in clientsToMigrate.Split(','))
                {
                    var alphabet = await _alphabetService.UpSertAlphabetAsync(new Models.Alphabet()
                    {
                        Name = clientName,
                        Description = "Migration Script - Inserted Record",
                        CreatedBy = "MigrationUser",
                        UpdatedBy = "MigrationUser",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    });

                    migrationContext.AlphabetId = alphabet.Id;
                    _logger.LogInformation($"Migration: UpSert Alphabet : '{clientName}' with Id '{migrationContext.AlphabetId}' done.");
                    await PopulateClient($"{path}\\{clientName}", migrationContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while populating client alphabet data.");
                throw;
            }
        }

        /// <summary>
        /// Populates report types for a given client.
        /// </summary>
        private async Task PopulateReportType(string clientNamePath, MigrationContext migrationContext)
        {
            try
            {
                string[] reportTypes = GetDirectories(clientNamePath);
                foreach (string reportType in reportTypes)
                {
                    var reportTypeInformation = await _reportTypeService.UpSertReportTypeAsync(
                      new Models.ReportType()
                      {
                          Type = reportType,
                          Description = "Migration Script - Inserted Record",
                          CreatedBy = "MigrationUser",
                          UpdatedBy = "MigrationUser",
                          CreatedDate = DateTime.Now,
                          UpdatedDate = DateTime.Now,
                          ClientId = migrationContext.ClientId,
                      });

                    migrationContext.ReportId = reportTypeInformation.Id;
                    _logger.LogInformation($"Migration: Upsert Report type '{reportType}' with Id '{migrationContext.ReportId}' for client '{migrationContext.ClinetName}' done.");
                    await PopulateRequestInformation($"{clientNamePath}\\{reportType}", migrationContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while populating report types.");
                throw;
            }
        }

        private async Task PopulateRequestInformation(string reportTypePath, MigrationContext migrationContext)
        {
            try
            {
                string[] requestNumbers = GetDirectories(reportTypePath);
                foreach (string requestNumber in requestNumbers)
                {
                    var requestInformation = await _requestInformationService.UpSertRequestInformationAsync(
                      new Models.RequestInformation()
                      {
                          ReportId = migrationContext.ReportId,
                          RequestType = requestNumber,
                          Description = "Migartion Script - Inserted Record",
                          CreatedBy = "MigartionUser",
                          UpdatedBy = "MigrationUser",
                          CreatedDate = DateTime.Now,
                          UpdatedDate = DateTime.Now,
                          ClientId = migrationContext.ClientId,
                      }
                  );
                    migrationContext.RequestInformationId = requestInformation.Id;
                    _logger.Log(LogLevel.Information, $"Migration: UpSert for Request number '{requestNumber}' of Id '{migrationContext.RequestInformationId}' for client '{migrationContext.ClinetName}' done.");
                    await PopulateRequestNumber($"{reportTypePath}\\{requestNumber}", migrationContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while populating request information.");
                throw;
            }
        }

        private async Task PopulateRequestNumber(string requestNumberPath, MigrationContext migrationContext)
        {
            string[] filePaths = Directory.GetFiles(requestNumberPath, "*.sql");
            foreach (string filePath in filePaths)
            {
                _logger.Log(LogLevel.Information, $"Inserting file '{Path.GetFileName(filePath)}' for client '{migrationContext.ClinetName}' started.");
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);
                    var requestInformation = await _sqlFileDataService.UpSertSqlFileDataAsync(
                        new Models.SqlFileData()
                        {
                            RequestId = migrationContext.RequestInformationId,
                            SqlFileDataContent = fileContent,
                            CreatedBy = "MigartionUser",
                            UpdatedBy = "MigrationUser",
                            CreatedDate = DateTime.Now,
                            Description = "Migartion Script - Inserted Record",
                            UpdatedDate = DateTime.Now,
                        }
                    );
                    _logger.Log(LogLevel.Information, $"Inserting file '{Path.GetFileName(filePath)}' for client '{migrationContext.ClinetName}' done.");
                }
                else
                {
                    _logger.Log(LogLevel.Warning, $"File '{filePath}' does not exist.");
                }
            }
        }

        private string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path).Select(Path.GetFileName).ToArray();
        }

        // Dispose pattern implementation
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here
                    _logger?.LogInformation("Disposing DataMigratorService resources.");
                    (_alphabetService as IDisposable)?.Dispose();
                    (_clientInformationService as IDisposable)?.Dispose();
                    (_reportTypeService as IDisposable)?.Dispose();
                    (_requestInformationService as IDisposable)?.Dispose();
                    (_sqlFileDataService as IDisposable)?.Dispose();
                }
                // Dispose unmanaged resources here if any
                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~DataMigratorService()
        {
            Dispose(disposing: false);
        }
    }
}
