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

    #region Log This
    /// <summary>
    /// 컨트롤이 전달받은 종속성을 이용한 로그 - 정보
    /// </summary>
    /// <param name="sMessage"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult LogThis_Info(string sMessage)
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");
        this._logger.LogInformation($"LogThis_Info에서 호출 : {sMessage}");

        return apiresult;
    }

    /// <summary>
    /// 컨트롤이 전달받은 종속성을 이용한 로그 - 디버그
    /// </summary>
    /// <param name="sMessage"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult LogThis_Debug(string sMessage)
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");
        this._logger.LogDebug($"LogThis_Debug에서 호출 : {sMessage}");

        return apiresult;
    }

    /// <summary>
    /// 컨트롤이 전달받은 종속성을 이용한 로그 - 경고
    /// </summary>
    /// <param name="sMessage"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult LogThis_Warning(string sMessage)
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");
        this._logger.LogWarning($"LogThis_Warning에서 호출 : {sMessage}");

        return apiresult;
    }
    #endregion

    #region GlobalStatic Log
    /// <summary>
    /// DotNetLogging을 이용한 로그 - 정보
    /// </summary>
    /// <param name="sMessage"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult LogGlobalStatic_Info(string sMessage)
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");
        GlobalStatic.Log.LogInfo($"LogGlobalStatic_Info에서 호출 : {sMessage}");

        return apiresult;
    }

    /// <summary>
    /// DotNetLogging을 이용한 로그 - 디버그
    /// </summary>
    /// <param name="sMessage"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult LogGlobalStatic_Debug(string sMessage)
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");
        GlobalStatic.Log.LogDebug($"LogGlobalStatic_Debug에서 호출 : {sMessage}");

        return apiresult;
    }

    /// <summary>
    /// DotNetLogging을 이용한 로그 - 경고
    /// </summary>
    /// <param name="sMessage"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult LogGlobalStatic_Warning(string sMessage)
    {
        ObjectResult apiresult = new ObjectResult(200);

        apiresult = StatusCode(200, "성공!");
        GlobalStatic.Log.LogWarning($"LogGlobalStatic_Warning에서 호출 : {sMessage}");

        return apiresult;
    }
    #endregion
}
