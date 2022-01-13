/*
 * 이 프로젝트에서 자주쓰는 아작스 호출 형식을 미리 정의 한다.
 * 
 * 응답에 대기하려면 await를 사용한다.(jsonOption.await을 true 로 줘야 한다.)
 */


/**
 * AjaxAssist2에서 에러가 발생할때 
 * @param {any} responseAjaxResult
 */
function ErrorAA2(responseAjaxResult)
{
    this.response = responseAjaxResult;
    this.status = this.response.status;
    this.statusText = this.response.statusText;;
    this.stack = (new Error()).stack;
}

var AA2 = {};

/** 아작스 기본 옵션 */
AA2.OptionDefult = {
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
     * @param {ErrorAA2} errorThrown 에러 내용. ErrorAA2 개체가 전달됨.
     */
    error: function (response, textStatus, errorThrown)
    {
    },

    /** fetch를 호출할때 강제로 전달하고 싶은 데이터가 있다면 여기에 입력한다.
     * 이 옵션이 가장 우선 된다.*/
    fetchOption: {
        /** no-cors, cors, *same-origin */
        mode: 'cors',
        /** // *default, no-cache, reload, force-cache, only-if-cached */
        cache: 'no-cache',
        /** include, *same-origin, omit */
        credentials: 'same-origin',
        headers: {
            /** 받을 데이터 타입 */
            'Accept': 'application/json',

            /** 전달할 데이터 타입 */
            //'Content-Type': 'application/json;charset=utf-8',
            //'Content-Type': 'text/plain',
            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        },
        /** manual, *follow, error */
        redirect: 'follow',
        /** no-referrer, *client */
        referrer: 'no-referrer',
    }
};

/**
 * get로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2.get = async function (typeToken, jsonOption)
{
    jsonOption.method = AjaxAssist.AjaxType.Get;
    if (true === jsonOption.await)
    {//응답 대기
        return await AA2.call(typeToken, jsonOption);
    }
    else
    {
        return AA2.call(typeToken, jsonOption);
    }
};
/**
 * post로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2.post = async function (typeToken, jsonOption)
{
    jsonOption.method = AjaxAssist.AjaxType.Post;
    if (true === jsonOption.await)
    {//응답 대기
        return await AA2.call(typeToken, jsonOption);
    }
    else
    {
        return AA2.call(typeToken, jsonOption);
    }
};
/**
 * put로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2.put = async function (typeToken, jsonOption)
{
    jsonOption.method = AjaxAssist.AjaxType.Put;
    if (true === jsonOption.await)
    {//응답 대기
        return await AA2.call(typeToken, jsonOption);
    }
    else
    {
        return AA2.call(typeToken, jsonOption);
    }
};
/**
 * patch로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2.patch = async function (typeToken, jsonOption)
{
    jsonOption.method = AjaxAssist.AjaxType.Patch;
    if (true === jsonOption.await)
    {//응답 대기
        return await AA2.call(typeToken, jsonOption);
    }
    else
    {
        return AA2.call(typeToken, jsonOption);
    }
};
/**
 * delete로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2.delete = async function (typeToken, jsonOption)
{
    jsonOption.method = AjaxAssist.AjaxType.Delete;
    if (true === jsonOption.await)
    {//응답 대기
        return await AA2.call(typeToken, jsonOption);
    }
    else
    {
        return AA2.call(typeToken, jsonOption);
    }
};


AA2.call = async function (typeToken, jsonOption)
{
    //옵션 저장
    let jsonOpt = Object.assign({}, AA2.OptionDefult, jsonOption);
    
    if ((undefined === jsonOpt.method)
        || (null === jsonOpt.method)
        || (null === jsonOpt.method))
    {//jsonOpt.method가 없다.

        //jquery 구버전 스타일 사용.
        jsonOpt.method = jsonOpt.type;
    }

    //url을 개체로 변경
    jsonOpt.UrlObj = new URL(jsonOpt.url, location.origin);

    if (AjaxAssist.AjaxType.Get === jsonOpt.method
        || AjaxAssist.AjaxType.Head === jsonOpt.method)
    {//메소드가 Get 이거나
        //메소드가 Head 이다.

        //Failed to execute 'fetch' on 'Window': Request with GET/HEAD method cannot have body.
        //'창'에서 '가져오기' 실행 실패: GET/HEAD 메서드를 사용한 요청은 본문을 가질 수 없습니다.

        //바디를 제거한다.
        delete jsonOpt["body"];

        //url쿼리를 만든다.
        jsonOpt.UrlObj.search
            = new URLSearchParams(jsonOpt.data);
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

    jsonFetchComplete = Object.assign({}, jsonFetch, jsonOpt.fetchOption);


    //완성된 리스폰스
    let responseAjaxResult = null;
    //리스폰스 처리
    if (true === jsonOpt.await)
    {//응답 대기

        responseAjaxResult
            = await fetch(jsonOpt.UrlObj, jsonFetchComplete);
        let responseCheckResult
            = await AA2.ResponseCheck(responseAjaxResult, jsonOpt);
        if (true === responseCheckResult.ok)
        {//성공
            jsonOpt.success(
                await responseAjaxResult.text()
                , responseAjaxResult.status
                , responseAjaxResult);
        }
        else
        {//실패
            let errorAA2 = new ErrorAA2(responseAjaxResult);
            jsonOpt.error(
                errorAA2.response
                , errorAA2.statusText
                , errorAA2
            );
        }
    }
    else
    {
        responseAjaxResult
            = fetch(jsonOpt.UrlObj, jsonOpt)
                .then(function (response)
                {
                    return AA2.ResponseCheck(response, jsonOpt);
                })
                .then(function (sData)
                {//정상 처리
                    jsonOpt.success(
                        sData
                        , responseAjaxResult.status
                        , responseAjaxResult);
                })
                .catch(function (errorAA2)
                {
                    jsonOpt.error(
                        errorAA2.response
                        , errorAA2.statusText
                        , errorAA2
                    );
                });
    }
    

    
    responseAjaxResult
        

    return responseAjaxResult;
};

/**
 * 
 * @param {any} response
 * @param {any} jsonOption
 * @returns 
 */
AA2.ResponseCheck = async function (
    response
    , jsonOption)
{
    if (true === response.ok)
    {//성공
        let objReturn = null;
        switch (jsonOption.contentGetType)
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
        throw new ErrorAA2(response);
    }
};


/**
 * 단순 파일 로드 .
 * funSuccess(data)로 
 * @param {string} sFileUrl
 * @param {Function} funSuccess
 * @param {json} jsonOption
 */
AA2.FileLoad = async function (
    sFileUrl
    , funSuccess
    , jsonOption)
{
    let typeToken = AjaxAssist.TokenRelayType.None;
    jsonOption.method = AjaxAssist.AjaxType.get;
    jsonOption.url = sFileUrl;

    if (true === jsonOption.await)
    {//대기
        await AA2.call(typeToken, jsonOption);
    }
    else
    {
        AA2.call(typeToken, jsonOption);
    }
};