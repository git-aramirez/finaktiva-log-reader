using LogReader.Core.IServices;
using LogReader.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LogReader.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogReaderController : ControllerBase
    {
        private readonly ILogReaderService _logReaderService;
        private readonly ILogger<LogReaderController> _logger;
        public LogReaderController(ILogReaderService logReaderService, ILogger<LogReaderController> logger)
        {
            _logReaderService = logReaderService;
            _logger=logger;
        }

        //<summary>
        //This endpoint will try to obtain all the logs
        //</summary>
        [HttpGet]
        public async Task<IActionResult> Logs()
        {
            try
            {
                _logger.LogInformation("Trying to obtain the logs");
                var logs = _logReaderService.Logs();
                _logger.LogInformation("logs successfully obtained");

                return Ok(logs);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }

        //<summary>
        //This endpoint will try to create a log
        //</summary>
        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] EventLog eventLog)
        {
            try
            {
                if(eventLog!=null && ( (int) eventLog.Event>2 || (int) eventLog.Event<0 ||
                    String.IsNullOrEmpty(eventLog.Description)))
                {
                    return BadRequest("check the data and try again please!");
                }

                _logger.LogInformation("Trying to create the log");
                var result = _logReaderService.CreateLog(eventLog);
                _logger.LogInformation("logs successfully created");

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
