using ADP.Reporting.Tool.Services;
using ADP.Reporting.Tool.Services.Interface;
using ADP.Reporting.Tool.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ADP.Reporting.Tool.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlphabetService _alphabetService;
        private readonly IClientInformationService _clientInformationService;
        private readonly IReportTypeService _reportTypeService;
        private readonly IRequestInformationService _requestInformationService;
        private readonly ISqlFileDataService _sqlFileDataService;

        public HomeController(ILogger<HomeController> logger, IAlphabetService alphabetService, 
            IClientInformationService clientInformationService,
           IReportTypeService reportTypeService, IRequestInformationService requestInformationService, ISqlFileDataService sqlFileDataService)
        {
            _logger = logger;
            _alphabetService = alphabetService;
            _clientInformationService = clientInformationService;
            _reportTypeService = reportTypeService;
            _requestInformationService = requestInformationService;
            _sqlFileDataService = sqlFileDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var data = _alphabetService.GetAllAlphabetsAsync().Result;
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetClientDetails(int alphabetId)
        {
            // Need to add one method to get details from SQL Server. Also expose the same information using endpoint
            var data = _clientInformationService.GetClientInformationAsync(1, 100).Result.Where(x => x.AlphabetId == alphabetId);
            return PartialView("_ClientDetailsTable", data.ToList());
        }

        [HttpPost]
        public JsonResult GetAlphabets(int start, int length)
        {
            start = start == 0 ? 1 : start;
            var data = _alphabetService.GetAllAlphabetsAsync(start, length).Result;
            return Json(new
            {
                draw = Request.Form["draw"],
                recordsTotal = data.Count(),
                recordsFiltered = data.Count(),
                data = data.ToList()
            });
        }

        [HttpGet]
        public ActionResult GetAlphabetDetail(int id)
        {
            var data = _alphabetService.GetAlphabetByIdAsync(id).Result;
            return PartialView("_AlphabetDetails", data);
        }

        [HttpGet]
        public ActionResult ReportType(int clientId)
        {
            var data = _reportTypeService.GetReportTypesAsync(1,100).Result.Where(x => x.ClientId == clientId).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult RequestInformation(int reportId)
        {
            var data = _requestInformationService.GetRequestInformationsAsync(1, 100).Result.Where(x => x.ReportId == reportId).ToList(); ;
            return View(data);
        }

        [HttpGet]
        public ActionResult SqlFileData(int requestId)
        {
            var data = _sqlFileDataService.GetSqlFileDatasAsync(1, 100).Result.Where(x => x.RequestId == requestId).FirstOrDefault(); ;
            return Json(new { sqlQuery = data?.SqlFileDataContent });
        }
    }
}
