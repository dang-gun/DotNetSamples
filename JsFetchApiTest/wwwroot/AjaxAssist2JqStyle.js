/**
 * 이 프로젝트에서 자주쓰는 아작스 호출 형식을 미리 정의 한다.
 * (jquery스타일)
 * 
 * 비동기로 사용하려면 await를 사용한다.(jsonOption.await을 false 로 줘야 한다.)
 */

var AA2jq = {};


/**
 * get로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2jq.get = async function (typeToken, jsonOption)
{
    jsonOption.type = AjaxAssist.AjaxType.Get;
    if (false === jsonOption.await)
    {//비동기
        await AA2jq.call(typeToken, jsonOption);
    }
    else
    {
        AA2jq.call(typeToken, jsonOption);
    }
};
/**
 * post로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2jq.post = async function (typeToken, jsonOption)
{
    jsonOption.type = AjaxAssist.AjaxType.Post;
    if (false === jsonOption.await)
    {//비동기
        await AA2jq.call(typeToken, jsonOption);
    }
    else
    {
        AA2jq.call(typeToken, jsonOption);
    }
};
/**
 * put로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2jq.put = async function (typeToken, jsonOption)
{
    jsonOption.type = AjaxAssist.AjaxType.Put;
    if (false === jsonOption.await)
    {//비동기
        await AA2jq.call(typeToken, jsonOption);
    }
    else
    {
        AA2jq.call(typeToken, jsonOption);
    }
};
/**
 * patch로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2jq.patch = async function (typeToken, jsonOption)
{
    jsonOption.type = AjaxAssist.AjaxType.Patch;
    if (false === jsonOption.await)
    {//비동기
        await AA2jq.call(typeToken, jsonOption);
    }
    else
    {
        AA2jq.call(typeToken, jsonOption);
    }
};
/**
 * delete로 아작스 요청을 한다.
 * @param {AjaxAssist.TokenRelayType} typeToken typeToken 헤더에 토큰을 넣을지 여부
 * @param {json} jsonOption jsonOption 아작스 요청에 사용할 옵션 데이터. 지정하지 않은 옵션은기본 옵션을 사용한다.
 */
AA2jq.delete = async function (typeToken, jsonOption)
{
    jsonOption.type = AjaxAssist.AjaxType.Delete;
    if (false === jsonOption.await)
    {//비동기
        await AA2jq.call(typeToken, jsonOption);
    }
    else
    {
        AA2jq.call(typeToken, jsonOption);
    }
};



AA2jq.call = async function (typeToken, jsonOption)
{
    let opt = {
        method: jsonOption.type,
        mode: 'cors', // no-cors, cors, *same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json',
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrer: 'no-referrer', // no-referrer, *client
        body: JSON.stringify(jsonOption.data), // body data type must match "Content-Type" header
    };

    fetch(jsonOption.url, opt)
        .then(function (response)
        {
            return response.json();
        })
        .then(function (myJson)
        {
            console.log(JSON.stringify(myJson));
        });
}