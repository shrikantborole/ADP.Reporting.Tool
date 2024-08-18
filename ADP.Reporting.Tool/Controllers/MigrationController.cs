using ADP.Reporting.Tool.Services;
using ADP.Reporting.Tool.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADP.Reporting.Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private readonly IDataMigratorService _dataMigrator;
        private readonly ILogger<MigrationController> logger;
        public MigrationController(IDataMigratorService dataMigrator, ILogger<MigrationController> logger)
        {
            _dataMigrator = dataMigrator;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _dataMigrator.Run();
            return Ok();
        }
    }
}
