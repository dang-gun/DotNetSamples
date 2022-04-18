
import { Test01 } from "/Test01.js";
import { Test02 as Test02 } from "/Test02.js";
import { Test03, Test04 } from "/Test0304.js";
import Test05  from "/Test05.js";

//import jsondata from "/TestJson.json";
//import { jsondata } from "/TestJson.json";
// Blink 엔진 사용 브라우저만 동작함(91 버전 이상)
// 크롬, 엣지에서 확인(파이어폭스 동작안함)
//import jsondata from "/TestJson.json" assert { type: "json" };

//동작안함
//import htmlData from "/TestHtml.html" assert { type: "html" };

export function TestStart()
{
    //console.log(jsondata);
    //console.log(htmlData);
}

/** 생성한 오브젝트를 넣어둘 대상 */
TestStart.prototype.objTarget = null;

/**
 * 지정한 타겟으로 변경한다.
 * @param {any} nTarget
 */
TestStart.prototype.ChangeTarget = function (nTarget)
{
    let objThis = this;

    switch (nTarget)
    {
        case 1:
            objThis.objTarget = new Test01();
            break;
        case 2:
            objThis.objTarget = new Test02();
            break;
        case 3:
            objThis.objTarget = new Test03();
            break;
        case 4:
            objThis.objTarget = new Test04();
            break;
        case 5:
            objThis.objTarget = new Test05();
            break;
    }

    console.log("Loading complete");
};


/** 생성된 개체의 메시지를 호출한다. */
TestStart.prototype.CallTarget = function ()
{
    this.objTarget.Msg();
};