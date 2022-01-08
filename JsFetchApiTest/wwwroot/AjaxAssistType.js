/** 아작스 지원 */
var AjaxAssist = {};

/** 아작스 요청 타입 */
AjaxAssist.AjaxType = {
    Get: "GET",
    Post: "POST",
    Put: "PUT",
    Patch: "PATCH",
    Delete: "DELETE"
};

/** 아작스 요청시 토큰을 어떻게 처리할지 여부 */
AjaxAssist.TokenRelayType = {
    /** 전달하지 않음 */
    None: 0,

    /** 
     *  무조건 전달 
     *  기존 토큰이 죽어 있으면 갱신후 전달.
     */
    HeadAdd: 1,

    /** 
     *  기존 토큰이 없으면 없이 전달.
     *  기존 토큰이 있으면 있이 전달.
     *  기존 토큰이 죽어 있으면 갱신후 전달.
     * */
    CaseByCase: 2,
};