
import { Test01 } from "/Test01.js";
import { Test02 } from "/Test02.js";



export function TestStart()
{
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
    }

    console.log("Loading complete");
};


/** 생성된 개체의 메시지를 호출한다. */
TestStart.prototype.CallTarget = function ()
{
    this.objTarget.Msg();
};