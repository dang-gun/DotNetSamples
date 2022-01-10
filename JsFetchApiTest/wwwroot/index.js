
var Log = {};
/** 로그메시지에 사용할 카운트 */
Log.LogMsgCount = 0;
Log.LogMsgCount_Pad = "0000000";

/**
 * 게임 로그 창에 로그를 표시한다.
 * @param {string} sLogMsg 표시할 메시지
 * @param {function} funText string를 파라메타로 받는 함수를 넘긴다.
 * 예> function (sText) { console.log(sText); }
 */
Log.LogMsg = function (sLogMsg, funText)
{
    //숫자 입력 문자열로 변환
    let sLogMsgCount
        = (Log.LogMsgCount_Pad + Log.LogMsgCount)
            .slice(-Log.LogMsgCount_Pad.length);
    sLogMsgCount = "[" + sLogMsgCount + "]"
        + "[" + (new Date().toISOString().substr(11, 8)) + "] "
        + sLogMsg;


    let _log;
    _log = "<div>" + sLogMsgCount + "</div>";
    $("#divLog").append(_log);

    //스크롤 최하단으로
    $("#divLog").scrollTop($("#divLog")[0].scrollHeight);

    funText(sLogMsgCount);


    //로그 카운트 증가
    ++Log.LogMsgCount;
}