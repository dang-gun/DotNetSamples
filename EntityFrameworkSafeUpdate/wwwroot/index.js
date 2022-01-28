import { AjaxAssist2, ErrorAjaxAssist2 } from "/src/AjaxAssist2.js";
import { AjaxAssist } from "/src/AjaxAssistType.js";

/** Ajax 지원 클래스 */
window.AA2 = new AjaxAssist2();


window.LogCout = 0;

export function index()
{
}

window.VisitCountGet = async function ()
{
    //로그 카운트 추가
    ++LogCout;

    await AA2.get(
        AjaxAssist.TokenRelayType.None
        , {
            await: true,
            url: "/api/Site/VisitCountGet",
            success: function (data, textStatus, response)
            {
                console.log(LogCout + " 카운트 확인 => " + data.VisitTotal);
            },
            error: function (response, textStatus, errorThrown)
            {
                Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });
                
                console.log(LogCout + " => 에러 : " + textStatus);
                console.log(response);
            },
        });
}

window.VisitCount = async function ()
{
    //로그 카운트 추가
    ++LogCout;

    console.log(LogCout + " 카운트 추가 시도");

    AA2.put(
        AjaxAssist.TokenRelayType.None
        , {
            url: "/api/Site/VisitCount",
            success: async function (data, textStatus, response)
            {
                console.log(LogCout + " 카운트 추가 성공");
                await VisitCountGet();
            },
            error: function (response, textStatus, errorThrown)
            {
                Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });

                console.log(LogCout + " => 에러 : " + textStatus);
                console.log(response);
            },
        });
}


window.VisitCountError = async function ()
{
    //로그 카운트 추가
    ++LogCout;

    console.log(LogCout + " 카운트 추가 에러 시도");

    AA2.put(
        AjaxAssist.TokenRelayType.None
        , {
            url: "/api/Site/VisitCountError",
            success: async function (data, textStatus, response)
            {
                console.log(LogCout + " 카운트 추가 에러 성공");
                await VisitCountGet();
            },
            error: function (response, textStatus, errorThrown)
            {
                Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });

                console.log(LogCout + " => 에러 : " + textStatus);
                console.log(response);
            },
        });
}

window.VisitCountProtect1 = async function ()
{
    //로그 카운트 추가
    ++LogCout;

    console.log(LogCout + " 카운트 추가 보호1 시도");

    AA2.put(
        AjaxAssist.TokenRelayType.None
        , {
            url: "/api/Site/VisitCountProtect1",
            success: async function (data, textStatus, response)
            {
                console.log(LogCout + " 카운트 추가 보호1 시도");
                await VisitCountGet();
            },
            error: function (response, textStatus, errorThrown)
            {
                Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });

                console.log(LogCout + " => 에러 : " + textStatus);
                console.log(response);
            },
        });
}


window.VisitCountProtect2 = async function ()
{
    //로그 카운트 추가
    ++LogCout;

    console.log(LogCout + " 카운트 추가 보호2 시도");

    AA2.put(
        AjaxAssist.TokenRelayType.None
        , {
            url: "/api/Site/VisitCountProtect2",
            success: async function (data, textStatus, response)
            {
                console.log(LogCout + " 카운트 추가 보호2 성공");
                await VisitCountGet();
            },
            error: function (response, textStatus, errorThrown)
            {
                Log.LogMsg("* 에러 : " + nCount, function (sLogMsgCount) { console.log(sLogMsgCount); });

                console.log(LogCout + " => 에러 : " + textStatus);
                console.log(response);
            },
        });
}

