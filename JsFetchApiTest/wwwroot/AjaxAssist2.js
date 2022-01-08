/**
 * 이 프로젝트에서 자주쓰는 아작스 호출 형식을 미리 정의 합니다.
 * 
 * 비동기로 사용하려면 await를 사용한다.(jsonOption.async을 false 로 줘야 한다.)
 */

var AA2 = {};

AA2.get = async function (typeToken, jsonOption)
{
    method.method = AjaxAssist.AjaxType.Get;
    if (false === jsonOption.async)
    {//비동기
        await AA2.call(typeToken, jsonOption);
    }
    else
    {
        AA2.call(typeToken, jsonOption);
    }
};
AA2.post = async function (typeToken, jsonOption)
{
    if (false === jsonOption.async)
    {//비동기
        await AA2.call(typeToken, jsonOption);
    }
    else
    {
        AA2.call(typeToken, jsonOption);
    }
};


AA2.call = async function (typeToken, jsonOption)
{
    let opt = {
        method: jsonOption.method,
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