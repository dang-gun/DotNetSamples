/*
 * 이 프로젝트에서 자주쓰는 아작스 호출 형식을 미리 정의 한다.
 * 
 * 응답에 대기하려면 await를 사용한다.(jsonOption.await을 true 로 줘야 한다.)
 */


/**
 * AjaxAssist2에서 에러가 발생할때 사용되는 개체
 * @param {any} responseAjaxResult
 */
function ErrorAjaxAssist2(responseAjaxResult)
{
    this.response = responseAjaxResult;
    this.status = this.response.status;
    this.statusText = this.response.statusText;;
    this.stack = (new Error()).stack;
}




/**
 * 이 프로젝트에서 자주쓰는 아작스 호출 형식을 미리 정의 한다.
 * 응답에 대기하려면 await를 사용한다.(jsonOption.await을 true 로 줘야 한다.)
 * @param {any} jsonOptionDefult 아작스 호출때 사용할 기본 옵션
 */
function AjaxAssist2(jsonOptionDefult)
{
    let objThis = this;

    //옵션 저장
    objThis.OptionDefult
        = Object.assign({}, objThis.OptionDefult, jsonOptionDefult);
    //개체가 참조되는 것을 방지 - fetchOption.headers
    objThis.OptionDefult.fetchOption
        = Object.assign({}, objThis.OptionDefult.fetchOption);
    objThis.OptionDefult.fetchOption.headers
        = Object.assign({}, objThis.OptionDefult.fetchOption.headers);
}

/** 콘솔에 로그를 표시할건지 여부 */
//AjaxAssist2.prototype.LogOn = false;
AjaxAssist2.prototype.LogOn = true;
/**
 * 로그 출력
 * @param {any} callback function(sLogTime){};
 */
AjaxAssist2.prototype.Log = function (callback)
{
    if (true === this.LogOn)
    {
        let s = "[" + (new Date().toISOString().substr(11, 8)) + "] ";
        callback(s);
    }
};

/** 아작스 기본 옵션 */
AjaxAssist2.prototype.OptionDefult = {
    /** 요청 url */
    url: "",
    /** 요청 url(인증)
     * 'AjaxAssist.TokenRelayType.CaseByCase' 인경우 엑세스토큰이 있을때 사용할 url.
     * 다른 경우에는 'url'을 사용한다.*/
    url_Auth: "",
    /** await 사용여부 */
    await: false,
    /** 컨탠츠 받기 타입. 
     * AjaxAssist.ContentGetType 사용.
     * 컨탠츠를 리턴받을때 어떤 타입으로 처리해서 받을지를 설정한다.*/
    contentGetType: AjaxAssist.ContentGetType.Json,

    /**
     * 요청이 성공했을때 호출될 콜백
     * @param {any} data 전달된 데이터. AjaxAssist.ContentGetType에 따라 선처리되서 온다.
     * @param {string} textStatus 결과 스테이터스. 성공시라 항상 '200'이다.
     * @param {object} response 처리가 완료된 리스폰스
     */
    success: function (data, textStatus, response)
    {
    },
    /**
     * 요청이 에러 났을때 호출될 콜백
     * @param {object} response 에러났을 때 전달받은 리스폰스
     * @param {string} textStatus 결과 스테이터스.
     * @param {ErrorAjaxAssist2} errorThrown 에러 내용. ErrorAjaxAssist2 개체가 전달됨.
     */
    error: function (response, textStatus, errorThrown)
    {
    },

    /** fetch를 호출할때 강제로 전달하고 싶은 데이터가 있다면 여기에 입력한다.
     * 이 옵션이 가장 우선 된다.*/
    fetchOption: {
        /** no-cors, cors, *same-origin */
        mode: "cors"
        /** // *default, no-cache, reload, force-cache, only-if-cached */
        , cache: 'no-cache'
        /** include, *same-origin, omit */
        , credentials: "omit"
        , headers: {
            /** 받을 데이터 타입 */
            "Accept": "application/json"

            /** 전달할 데이터 타입 */
            //"Content-Type": "application/json;charset=utf-8",
            //"Content-Type": "text/plain",
            ,"Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"
        }
        /** manual, *follow, error */
        , redirect: "follow"
        /** no-referrer, *client */
        , referrer: "no-referrer"
    }
};

/** 
 * 엑세스 토큰 읽기 함수.(직접 지정)
 * @returns {string} 가지고 있는 엑세스 토큰 리턴
 * */
AjaxAssist2.prototype.AccessTokenRead = function () { return ""; };
/**
 * 리플레시 토큰 읽기 함수.(직접 지정)
 * @returns {string} 가지고 있는 엑세스 토큰 리턴
 * */
AjaxAssist2.prototype.RefreshTokenRead = function () { return ""; };
/**
 * 리플레시 토큰처리가 성공하면 동작하는 함수.(직접 지정)
 * 여기서 리플레시 토큰 저장처리를 하지 않으면 무한으로 리플레시 토큰을 갱신요청을 하게 된다.
 * @param {any} jsonData 리플레시 토큰 처리가 완료되고 넘어온 데이터
 */
AjaxAssist2.prototype.RefreshTokenSuccess = async function (jsonData) { };
/** 
 *  리플레시 토큰이 만료가 확인되면 발생하는 이벤트
 *  어떤 식으로든 갱신 실패(타임아웃, 소실, 잘못된 토큰) 되었을때 호출되는 함수.
 * @param {string} errorCode -1:알수 없음
 * , -11/-12 :알수 없음
 * , -101: 인증 정보 없음
 * , -102:기간 만료
 * , -104:만료(기간은 남았는데 만료됨. 예>이미 갱신에 사용된경우)
 * @param {ErrorAjaxAssist2} errorAA2Obj 에러 개체
 * @param {AjaxAssist.TokenRelayType} typeToken 에러 당시 헤더에 토큰을 넣을지 여부
 * @param {ErrorAjaxAssist2} jsonOption 이 에러가 난 당시의 원본 옵션
 * */
AjaxAssist2.prototype.OnRefreshTokenExp = function (
    errorCode
    , errorAA2Obj
    , typeToken
    , jsonOption) { };


/** 대기 리스트를 한번에 처리할때 각 요청별 간격(ms) */
AjaxAssist2.prototype.WaitingListDelay = 10;

/**
 * get로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AjaxAssist2.prototype.get = async function (typeToken, jsonOption)
{
    let objThis = this;

    jsonOption.method = AjaxAssist.AjaxMethodType.Get;
    if (true === jsonOption.await)
    {//응답 대기
        return await objThis.call(typeToken, jsonOption);
    }
    else
    {
        return objThis.call(typeToken, jsonOption);
    }
};
/**
 * post로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AjaxAssist2.prototype.post = async function (typeToken, jsonOption)
{
    let objThis = this;

    jsonOption.method = AjaxAssist.AjaxMethodType.Post;
    if (true === jsonOption.await)
    {//응답 대기
        return await objThis.call(typeToken, jsonOption);
    }
    else
    {
        return objThis.call(typeToken, jsonOption);
    }
};
/**
 * put로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AjaxAssist2.prototype.put = async function (typeToken, jsonOption)
{
    let objThis = this;

    jsonOption.method = AjaxAssist.AjaxMethodType.Put;
    if (true === jsonOption.await)
    {//응답 대기
        return await objThis.call(typeToken, jsonOption);
    }
    else
    {
        return objThis.call(typeToken, jsonOption);
    }
};
/**
 * patch로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AjaxAssist2.prototype.patch = async function (typeToken, jsonOption)
{
    let objThis = this;

    jsonOption.method = AjaxAssist.AjaxMethodType.Patch;
    if (true === jsonOption.await)
    {//응답 대기
        return await objThis.call(typeToken, jsonOption);
    }
    else
    {
        return objThis.call(typeToken, jsonOption);
    }
};
/**
 * delete로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AjaxAssist2.prototype.delete = async function (typeToken, jsonOption)
{
    let objThis = this;

    jsonOption.method = AjaxAssist.AjaxMethodType.Delete;
    if (true === jsonOption.await)
    {//응답 대기
        return await objThis.call(typeToken, jsonOption);
    }
    else
    {
        return objThis.call(typeToken, jsonOption);
    }
};


AjaxAssist2.prototype.call = async function (typeToken, jsonOption)
{
    let objThis = this;

    //매개변수 백업(여기서는 이걸 원본취급한다.)
    var typeTokenTemp = typeToken;
    var jsonOptionTemp = jsonOption;

    //옵션 저장
    let jsonOpt = Object.assign({}, objThis.OptionDefult, jsonOption);
    //개체가 참조되는 것을 방지 - fetchOption.headers
    jsonOpt.fetchOption = Object.assign({}, jsonOpt.fetchOption);
    jsonOpt.fetchOption.headers = Object.assign({}, jsonOpt.fetchOption.headers);
    
    if ((undefined === jsonOpt.method)
        || (null === jsonOpt.method)
        || (null === jsonOpt.method))
    {//jsonOpt.method가 없다.

        //jquery 구버전 스타일 사용.
        jsonOpt.method = jsonOpt.type;
    }

    

    //일반 url 개체 만들기
    jsonOpt.UrlObj = new URL(jsonOpt.url, location.origin);
    jsonOpt.UrlAuthObj = null;

    //인증용 url을 개체 만들기
    if (AjaxAssist.TokenRelayType.CaseByCase === typeTokenTemp
        && "" !== jsonOpt.url_Auth)
    {//케이스 바이 케이스인데
        //엑세스 키가 있다.

        //인증용 url을 만든다.
        jsonOpt.UrlAuthObj = new URL(jsonOpt.url_Auth, location.origin);
    }

    

    if (AjaxAssist.AjaxMethodType.Get === jsonOpt.method
        || AjaxAssist.AjaxMethodType.Head === jsonOpt.method)
    {//메소드가 Get 이거나
        //메소드가 Head 이다.

        //Failed to execute 'fetch' on 'Window': Request with GET/HEAD method cannot have body.
        //'창'에서 '가져오기' 실행 실패: GET/HEAD 메서드를 사용한 요청은 본문을 가질 수 없습니다.

        //바디를 제거한다.
        delete jsonOpt["body"];

        //url쿼리를 만든다.
        jsonOpt.UrlObj.search
            = new URLSearchParams(jsonOpt.data);

        if (null !== jsonOpt.UrlAuthObj)
        {//인증용 url이 있다.
            jsonOpt.UrlAuthObj.search
                = new URLSearchParams(jsonOpt.data);
        }
        
    }
    else
    {//이외의 메소드

        let bJson = false;
        let sContentType = jsonOpt.fetchOption.headers["Content-Type"];


        if ("string" === (typeof sContentType))
        {
            if (-1 < sContentType.indexOf("application/x-www-form-urlencoded"))
            {
                //"application/x-www-form-urlencoded"인경우
                //json 형식이 아니고 url 쿼리모양으로 바꿔야 한다.
                //예> nData=1000&sData="test111"
                jsonOpt.body =  (new URLSearchParams(jsonOpt.data));
            }
            else
            {//예외
                bJson = true;
            }
        }
        else
        {//예외
            bJson = true;
        }

        if (true === bJson)
        {//json 처리 필요
            //예외는 모두 json으로 처리한다.
            jsonOpt.body = JSON.stringify(jsonOpt.data);
        }
    }


    //fetch에 사용될 옵션 정리 *****************
    let jsonFetch = {
        method: jsonOpt.method,
        body: jsonOpt.body,
    };


    //인증 키 전달 처리 *****
    let sAccessToken = "";
    //인증키 읽기
    if (AjaxAssist.TokenRelayType.HeadAdd === typeTokenTemp
        || AjaxAssist.TokenRelayType.CaseByCase === typeTokenTemp)
    {//전달 확인
        sAccessToken = objThis.AccessTokenRead();
    }
    else
    {//전달 안한다.
        sAccessToken = "";
    }
    //인증키 전달
    if ("" !== sAccessToken)
    {//엑세스 키가 있다.
        jsonOpt.fetchOption.headers["authorization"]
            = "Bearer " + sAccessToken;
    }



    //Fetch 사용자 지정 옵션 
    jsonFetchComplete = Object.assign({}, jsonFetch, jsonOpt.fetchOption);


    //완성된 리스폰스
    let responseAjaxResult = null;
    //사용할 주소 개체
    let urlTarget = null;
    if (AjaxAssist.TokenRelayType.CaseByCase === typeTokenTemp
        && null !== jsonOpt.UrlAuthObj)
    {//케이스 바이 케이스 이다.
        //url 개체가 완성되어 있다.

        //인증이 필요한 주소를 사용한다.
        urlTarget = jsonOpt.UrlAuthObj;
    }
    else
    {
        urlTarget = jsonOpt.UrlObj;
    }

    //리스폰스 처리jsonOptionTemp
    if (true === jsonOpt.await)
    {//응답 대기

        //요청
        responseAjaxResult
            = await fetch(urlTarget, jsonFetchComplete);

        //에러 개체
        let errorAAObj = null;

        try
        {
            //요청 데이터 처리
            let responseCheckResult
                = await objThis.ResponseCheck(responseAjaxResult, jsonOpt.contentGetType);
            if (true === responseAjaxResult.ok)
            {//성공
                jsonOpt.success(
                    responseCheckResult
                    , responseAjaxResult.status
                    , responseAjaxResult);
            }
            else
            {//실패
                errorAAObj = new ErrorAjaxAssist2(responseAjaxResult);
            }
        }
        catch (errorAA2)
        {
            errorAAObj = errorAA2;
        }

        //에러 처리
        if (null !== errorAAObj)
        {
            await objThis.ErrorToss(
                errorAAObj
                , typeTokenTemp
                , jsonOptionTemp);
        }
    }
    else
    {
        //요청
        responseAjaxResult
            = fetch(urlTarget, jsonFetchComplete)
                .then(function (response)
                {
                    return objThis.ResponseCheck(response, jsonOpt.contentGetType);
                })
                .then(function (sData)
                {//정상 처리
                    jsonOpt.success(
                        sData
                        , responseAjaxResult.status
                        , responseAjaxResult);
                })
                .catch(async function (errorAA2)
                {
                    await objThis.ErrorToss(
                        errorAA2
                        , typeTokenTemp
                        , jsonOptionTemp);
                });
    }

    return responseAjaxResult;
};

/**
 * 
 * @param {any} response
 * @param {any} contentGetType
 * @returns 
 */
AjaxAssist2.prototype.ResponseCheck = async function (
    response
    , contentGetType)
{
    if (true === response.ok)
    {//성공
        let objReturn = null;
        switch (contentGetType)
        {
            case AjaxAssist.ContentGetType.Response:
                objReturn = response;
                break;
            case AjaxAssist.ContentGetType.Json:
                objReturn = response.json();
                break;
            case AjaxAssist.ContentGetType.Binary:
                objReturn = response.arrayBuffer();
                break;

            case AjaxAssist.ContentGetType.Text:
            default:
                objReturn = response.text();
                break;
        }

        return objReturn;
    }
    else
    {
        throw new ErrorAjaxAssist2(response);
    }
};


/**
 * 단순 파일 로드 .
 * funSuccess(data)로 
 * @param {string} sFileUrl
 * @param {Function} funSuccess
 * @param {json} jsonOption
 */
AjaxAssist2.prototype.FileLoad = async function (
    sFileUrl
    , funSuccess
    , jsonOption)
{
    let objThis = this;

    let typeToken = AjaxAssist.TokenRelayType.None;
    jsonOption.method = AjaxAssist.AjaxMethodType.get;
    jsonOption.url = sFileUrl;

    jsonOption.success = funSuccess;


    if (true === jsonOption.await)
    {//대기
        await objThis.call(typeToken, jsonOption);
    }
    else
    {
        objThis.call(typeToken, jsonOption);
    }
};



//□□□□□□□□□□□□□□□□□□□□□□□
//리플레시 토큰 처리 관련 
//□□□□□□□□□□□□□□□□□□□□□□□

/** 
 *  RefreshToken을 갱신하고 있을때 아작스개체를 임시저장해둔다.
 *  짧은 시간 리플레시토큰을 여러번 사용하려고하면 싱크에 문제가 생겨
 *  죽어있는 토큰을 사용하려는 문제가 생긴다.
 *  그래서 여기에 개체를 넣어두고 다른 요청은 RefreshToAccess_WaitingList에 대기시켜둔다.
 * */
AjaxAssist2.prototype.RefreshToAccess_CallBool = false;
/** 이미 다른 리플레시 토큰이 갱신에 들어갔다면 다른 요청은 여기에 넣는다. */
AjaxAssist2.prototype.RefreshToAccess_WaitingList = {};
/** 리스트로 사용할 고유이름을 생성하기 위한 카운트 */
AjaxAssist2.prototype.RefreshToAccess_WaitingListNameCount = 0;

/**
 * fetch 호출 에러시 공통 처리.(무조건 await로 호출한다.)
 * @param {ErrorAjaxAssist2} errorAAObj 에러 개체
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOptionOriginal 이 에러가 난 당시의 원본 옵션
 */
AjaxAssist2.prototype.ErrorToss = async function (
    errorAAObj
    , typeToken
    , jsonOptionOriginal)
{
    let objThis = this;

    let errorAAObjTemp = errorAAObj;
    let typeTokenTemp = typeToken;
    let jsonOptionOriginalTemp = jsonOptionOriginal;

    //if (401 === errorAAObj.status)
    if (((AjaxAssist.TokenRelayType.HeadAdd === typeTokenTemp)
        || (AjaxAssist.TokenRelayType.CaseByCase === typeTokenTemp))
            && (401 === errorAAObj.status))
    {//HeadAdd나 CaseByCase이다.

        //엑세스 토큰이 만료 됐다는 의미다.
        //리프레시 토큰을 다시 요청한다.
        await objThis.RefreshToAccess(
            typeTokenTemp
            , jsonOptionOriginalTemp);
    }
    else
    {
        jsonOptionOriginalTemp.error(
            errorAAObjTemp.response
            , errorAAObjTemp.statusText
            , errorAAObjTemp
        );
    }
};

/**
 *  리플래토큰으로 엑세스 토큰 갱신을 요청한다.(무조건 await로 호출한다.)
 * @param {AjaxAssist.TokenRelayType} typeToken 에러 당시에 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOptionOriginal 이 에러가 난 당시의 원본 옵션
 * */
AjaxAssist2.prototype.RefreshToAccess = async function (
    typeToken
    , jsonOptionOriginal)
{
    let objThis = this;

    let typeTokenTemp = typeToken;
    let jsonOptionOriginalTemp = jsonOptionOriginal;

    
    if (false === objThis.RefreshToAccess_CallBool)
    {//진행중인 리플레시 토큰 갱신이 없다.

        //갱신중 알림
        objThis.RefreshToAccess_CallBool = true;

        //대상 url
        let urlTarget = new URL("/api/Sign/RefreshToAccess", location.origin);
        //전달용 바디 데이터
        let bodyData
            = (new URLSearchParams({
                "nID": SignInAssist.SignIn_ID
                , "sRefreshToken": SignInAssist.refresh_token
            }));

        let jsonFetch = {
            method: AjaxAssist.AjaxMethodType.Put
            , mode: "cors"
            , cache: "no-cache"
            , credentials: "omit"
            , headers: {
                "Accept": "application/json"
                , "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"
            }
            , body: bodyData
            , referrer: "no-referrer"
        };

        objThis.Log(function (sLogTime) { console.log(sLogTime + "RefreshToken 갱신 시작"); });
        objThis.Log(function (sLogTime) { console.log("/api/Sign/RefreshToAccess"); });
        //요청
        let responseAjaxResult
            = await fetch(urlTarget, jsonFetch);

        //에러 개체
        let errorAA2Obj = null;

        try
        {
            //결과 처리
            let responseCheckResult
                = await objThis.ResponseCheck(
                    responseAjaxResult
                    , AjaxAssist.ContentGetType.Json);
            if (true === responseAjaxResult.ok)
            {//성공

                if ("0" === responseCheckResult.InfoCode)
                {//성공
                    //리플레시 토큰 처리가 완료된것을 알림
                    objThis.RefreshTokenSuccess(responseCheckResult);
                    //전달받은 옵션으로 다시 호출한다.
                    objThis.call(typeTokenTemp, jsonOptionOriginalTemp);
                    //쌓여있는 리스트를 처리한다.
                    objThis.RefreshToAccess_WaitingList_Call();
                }
                else if ("-103" === responseCheckResult.InfoCode)
                {//너무 빠른 갱신요청

                    //이미 다른 쓰레드에서 토큰 갱신이 이루어 졌다는 소리다.
                    //만약 토큰이 다른곳에서 갱신된것이라면
                    //다음 호출에서 리플래시토큰 만료가 와야 한다.

                    //RefreshToAccess_CallBool가 true라면 대기 리스트에 추가하고
                    //RefreshToAccess_CallBool가 false라면 바로 다시 요청을 콜한다.
                    if (false === objThis.RefreshToAccess_CallBool)
                    {//리플래시 갱신을 하고 있지 않다.

                        objThis.Log(function (sLogTime) { console.log(sLogTime + "-103 : 다시 호출"); });
                        //전달받은 옵션으로 다시 호출한다.
                        objThis.call(typeTokenTemp, jsonOptionOriginalTemp);
                    }
                    else
                    {//리플래시 갱신을 하고 있다.

                        objThis.Log(function (sLogTime) { console.log(sLogTime + "-103 : 갱신 대기"); });
                        objThis.Log(function (sLogTime) { console.log(objThis.RefreshToAccess_WaitingList); });
                        objThis.RefreshToAccess_WaitingList_Add(
                            typeTokenTemp
                            , jsonOptionOriginalTemp
                            , "6001");
                    }
                }
                else
                {
                    objThis.Log(function (sLogTime) { console.log(sLogTime + "갱신 실패 : " + responseCheckResult.InfoCode); });
                    errorAA2Obj = new ErrorAjaxAssist2(responseAjaxResult);
                    objThis.OnRefreshTokenExp(responseCheckResult.InfoCode, errorAA2Obj);
                }
                
            }
            else
            {//실패
                //알수 없는 에러
                objThis.Log(function (sLogTime) { console.log(sLogTime + "갱신 실패 : 알 수 없는 에러"); });
                errorAA2Obj = new ErrorAjaxAssist2(responseAjaxResult);
                objThis.OnRefreshTokenExp(-1, errorAA2Obj);
            }
        }
        catch (errorAA2)
        {
            errorAA2Obj = errorAA2;
        }

        if (null !== errorAA2Obj)
        {//에러 개체가 생성됐다.

            //엑세스토큰 갱신이 실패했다.
            if (typeTokenTemp === AjaxAssist.TokenRelayType.CaseByCase)
            {//케이스 바이 케이스다.

                //전달받은 옵션으로 다시 호출한다.
                //인증 헤더는 전달하지 않는다.
                objThis.call(
                    AjaxAssist.TokenRelayType.None
                    , jsonOptionOriginalTemp);
            }
            else
            {
                //에러 전달
                jsonOptionOriginalTemp.error(
                    errorAA2Obj.response
                    , errorAA2Obj.statusText
                    , errorAA2Obj
                );
            }
        }//end if (null !== errorAA2Obj)
    }
    else
    {//갱신중이다.
        objThis.RefreshToAccess_WaitingList_Add(
            typeTokenTemp
            , jsonOptionOriginalTemp
            , "6002"
        );
    }
};



/**
 * 리플레시 토큰의 갱신이 진행중인경우 요청 리스트를 임시저장해준다.
 * @param {any} typeToken 저장할 토큰 타입
 * @param {any} jsonOption 저장할 옵션
 * @param {any} sMessage 디버그 메시지 추가
 */
AjaxAssist2.prototype.RefreshToAccess_WaitingList_Add = function (
    typeToken
    , jsonOption
    , sMessage)
{
    let objThis = this;

    objThis.RefreshToAccess_WaitingList[""
        + (++objThis.RefreshToAccess_WaitingListNameCount)]
        = [typeToken, jsonOption];

    var nCount = Object.keys(objThis.RefreshToAccess_WaitingList).length;

    objThis.Log(function (sLogTime) { console.log(sLogTime + sMessage + nCount); });
    objThis.Log(function (sLogTime) { console.log(objThis.RefreshToAccess_WaitingList);});
};

/** 가지고 있는 대기 리스트를 진행시킨다. */
AjaxAssist2.prototype.RefreshToAccess_WaitingList_Call = function ()
{
    let objThis = this;

    //임시저장한 아작스개체를 삭제한다.
    objThis.RefreshToAccess_CallBool = false;

    //가지고 있는 대기 리스트를 진행시킨다. ****************
    //RefreshToAccess_WaitingList에 있는 요청을 진행한다.
    let arrKey = Object.keys(objThis.RefreshToAccess_WaitingList);
    let nCount = arrKey.length;

    objThis.Log(function (sLogTime) { console.log(sLogTime + "대기 요청 진행:" + nCount); });

    for (var i = 0; i < nCount; ++i)
    {
        //문자열로 변경
        let itemTemp = arrKey[i];

        //약간의 딜레이를 주고 요청을 진행한다.
        setTimeout(function ()
        {
            let item = objThis.RefreshToAccess_WaitingList[itemTemp];
            //요청을 전달하고
            objThis.call(item[0], item[1]);
            //사용한 요청을 지운다.
            delete objThis.RefreshToAccess_WaitingList[itemTemp];
        }, objThis.WaitingListDelay * i);
    }
};