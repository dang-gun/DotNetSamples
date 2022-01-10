/*
 * 이 프로젝트에서 자주쓰는 아작스 호출 형식을 미리 정의 한다.
 * 
 * 응답에 대기하려면 await를 사용한다.(jsonOption.await을 false 로 줘야 한다.)
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
    mode: 'cors', // no-cors, cors, *same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
        'Content-Type': 'application/json',
        // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: 'follow', // manual, *follow, error
    referrer: 'no-referrer', // no-referrer, *client
    //body: JSON.stringify(jsonOpt.data), // body data type must match "Content-Type" header
};

/**
 * get로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2.get = async function (typeToken, jsonOption)
{
    jsonOption.method = AjaxAssist.AjaxType.Get;
    if (false === jsonOption.await)
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
    if (false === jsonOption.await)
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
    if (false === jsonOption.await)
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
    if (false === jsonOption.await)
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
    if (false === jsonOption.await)
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
        jsonOpt.body = JSON.stringify(jsonOpt.data);
    }



    let responseAjaxResult = null;

    if (false === jsonOpt.await)
    {//응답 대기

        responseAjaxResult = await fetch(jsonOpt.UrlObj, jsonOpt);
        if (true === responseAjaxResult.ok)
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
                    if (true === response.ok)
                    {//성공
                        return response.text();
                    }
                    else
                    {
                        throw new ErrorAA2(response);
                    }
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

    return responseAjaxResult;
};


AA2.FileLoad = async function (
    sFileUrl
    , funSuccess
    , jsonOption)
{
    let typeToken = AjaxAssist.TokenRelayType.None;
    method.method = AjaxAssist.AjaxType.Delete;

    if (false === jsonOption.await)
    {//비동기
        await AA2.call(typeToken, jsonOption);
    }
    else
    {
        AA2.call(typeToken, jsonOption);
    }
};