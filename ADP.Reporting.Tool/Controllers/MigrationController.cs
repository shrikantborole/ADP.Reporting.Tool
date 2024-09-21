using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private readonly IDataMigratorService _dataMigrator;
        private readonly ILogger<MigrationController> _logger;

        public MigrationController(IDataMigratorService dataMigrator, ILogger<MigrationController> logger)
        {
            _dataMigrator = dataMigrator;
            _logger = logger;
        }

        /// <summary>
        /// Triggers the data migration process.
        /// </summary>
        /// <returns>HTTP Status Code indicating the result of the migration.</returns>
        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            try
            {
                _logger.LogInformation("Migration process started.");
                await _dataMigrator.Run();
                _logger.LogInformation("Migration process completed successfully.");
                return Ok("Migration completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during the migration process.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during migration.");
            }
        }
    }
}
