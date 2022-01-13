
/** 초기화 */
function Start()
{
    SignInAssist.Reset();
    SignInAssist.SignInUi();
}




/**
 *
 * @param nAwait 0=대기없음, 1=대기
 */
async function JsonFileLoad(nAwait)
{
    let nCount = ++LogCount;

    let jsonCallOpt = {
        url: "/TestData.json",
        data: {},

        success: function (data, textStatus, response)
        {
            Log.LogMsg("* 성공 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });
            console.log(JSON.parse(data));
        },
        error: function (response, textStatus, errorThrown)
        {
            Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });
            console.log(response);
        },
    };



    Log.LogMsg("<<<<<< " + nCount + " JsonFileLoad >>>>>>", function (sLogMsgCount) { console.log(sLogMsgCount); });

    switch (nAwait)
    {
        case 1://대기
            await AA2.get(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;

        case 0:
        default:
            //대기 없음
            AA2.get(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;
    }

    Log.LogMsg(">>>>>> " + nCount + " end JsonFileLoad <<<<<<", function (sLogMsgCount) { console.log(sLogMsgCount); });
}



/**
 * 딜레이 api 호출
 * @param nAwait 0=get대기없음, 1=get대기, 10=post대기없음, 11=post대기
 */
async function ApiDelay(nAwait)
{
    let nCount = ++LogCount;

    let nDelay = $("#txtDelay").val();

    let jsonCallOpt = {

        fetchOption:
        {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
            },
        },

        data: {
            nDelay: nDelay,
            nTest: 1000,
            sTest: "test1111",
        },

        success: function (data, textStatus, response)
        {
            Log.LogMsg("* 성공 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });
            console.log(JSON.parse(data));
        },
        error: function (response, textStatus, errorThrown)
        {
            Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });
            console.log(response);
        },
    };


    Log.LogMsg("<<<<<< " + nCount + " ApiDelay >>>>>>", function (sLogMsgCount) { console.log(sLogMsgCount); });

    switch (nAwait)
    {
        case 0://get대기 없음
            jsonCallOpt.url = "/api/Test/Delay";
            AA2.get(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;
        case 1://get대기
            jsonCallOpt.url = "/api/Test/Delay";
            jsonCallOpt.await = true;
            await AA2.get(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;

        case 10://post대기 없음
            jsonCallOpt.url = "/api/Test/DelayPost";
            AA2.post(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;
        case 11://post대기
            jsonCallOpt.url = "/api/Test/DelayPost";
            jsonCallOpt.await = true;
            await AA2.post(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;
    }

    Log.LogMsg(">>>>>> " + nCount + "end ApiDelay <<<<<<", function (sLogMsgCount) { console.log(sLogMsgCount); });
}



/**
 * 딜레이 api 호출
 * @param nAwait 0=get대기없음, 1=get대기, 10=post대기없음, 11=post대기
 */
async function ApiError(nAwait)
{
    let nCount = ++LogCount;

    let nDelay = $("#txtDelay").val();

    let jsonCallOpt = {
        data: { nDelay: nDelay },

        success: function (data, textStatus, response)
        {
            Log.LogMsg("* 성공 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });
            console.log(JSON.parse(data));
        },
        error: function (response, textStatus, errorThrown)
        {
            Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });
            console.log(response);
        },
    };


    Log.LogMsg("<<<<<< " + nCount + " ApiError >>>>>>", function (sLogMsgCount) { console.log(sLogMsgCount); });

    switch (nAwait)
    {
        case 0://get대기 없음
            jsonCallOpt.url = "/api/Test/ErrorGet";
            AA2.get(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;
        case 1://get대기
            jsonCallOpt.url = "/api/Test/ErrorGet";
            jsonCallOpt.await = true;
            await AA2.get(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;

        case 10://post대기 없음
            jsonCallOpt.url = "/api/Test/ErrorPost";
            AA2.post(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;
        case 11://post대기
            jsonCallOpt.url = "/api/Test/ErrorPost";
            jsonCallOpt.await = true;
            await AA2.post(AjaxAssist.TokenRelayType.None, jsonCallOpt);
            break;
    }

    Log.LogMsg(">>>>>> " + nCount + "end ApiError <<<<<<", function (sLogMsgCount) { console.log(sLogMsgCount); });
}