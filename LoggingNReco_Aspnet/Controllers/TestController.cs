using Microsoft.AspNetCore.Mvc;

using LoggingNReco_Aspnet.Global;

namespace LoggingNReco_Aspnet.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestController : ControllerBase
{
    /// <summary>
    /// 사용할 로거
    /// </summary>
    private ILogger _logger;

    public TestController(ILogger<TestController> logger)
    {
        this._logger = logger;
    }

    /// <summary>
    /// 무조건 성공
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult SuccessCall()
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");

        this._logger.LogInformation("SuccessCall에서 호출~");
        this._logger.LogDebug("SuccessCall에서 호출~");
        return apiresult;
    }

    /// <summary>
    /// 무조건 성공2
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult SuccessCall2()
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");
        this._logger.LogInformation("SuccessCall2에서 호출!!!");

        return apiresult;
    }
}
