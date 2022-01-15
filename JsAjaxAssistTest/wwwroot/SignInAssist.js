
var SignInAssist = {};

//□□□□□□ 사인 관련 □□□□□□
SignInAssist.SignIn = false;
SignInAssist.SignIn_ID = 0;
SignInAssist.SignIn_Email = "";

//□□□□□□ 사인인 관련 □□□□□□
SignInAssist.divSignInArea = null;
SignInAssist.txtEmail = null;
SignInAssist.txtPassword = null;
SignInAssist.btnSignInStart = null;

//□□□□□□ 사인아웃 관련 □□□□□□
SignInAssist.btnSignOutStart = "";

//□□□□□□ 토큰 관련 □□□□□□
SignInAssist.access_token = "";
SignInAssist.refresh_token = "";

SignInAssist.txtAccessToken = null;
SignInAssist.btnAccessTokenDelete = null;
SignInAssist.txtRefreshToken = null;
SignInAssist.btnRefreshTokenDelete = null;


/** 초기화 */
SignInAssist.Reset = function ()
{
    AA2.AccessTokenRead = function ()
    {
        return SignInAssist.access_token;
    };
    AA2.RefreshTokenRead = function ()
    {
        return SignInAssist.refresh_token;
    };

    SignInAssist.divSignInArea = $("#divSignInArea");
    SignInAssist.txtEmail = $("#txtEmail");
    SignInAssist.txtPassword = $("#txtPassword");
    SignInAssist.btnSignInStart = $("#btnSignInStart");
    SignInAssist.btnSignInStart.click(SignInAssist.OnClick_SignIn);

    SignInAssist.btnSignOutStart = $("#btnSignOutStart");
    SignInAssist.btnSignOutStart.click(SignInAssist.OnClick_SignOut);


    SignInAssist.txtAccessToken = $("#txtAccessToken");
    SignInAssist.btnAccessTokenDelete = $("#btnAccessTokenDelete");
    SignInAssist.btnAccessTokenDelete.click(SignInAssist.AccessTokenDelete);
    SignInAssist.txtRefreshToken = $("#txtRefreshToken");
    SignInAssist.btnRefreshTokenDelete = $("#btnRefreshTokenDelete");
    SignInAssist.btnRefreshTokenDelete.click(SignInAssist.RefreshTokenDelete);

};

/** 사인인 클릭 이벤트 */
SignInAssist.OnClick_SignIn = function()
{
    SignInAssist.SignInUi(false);

    if (false === SignInAssist.SignIn)
    {
        AA2.put(AjaxAssist.TokenRelayType.None
            , {
                url: "/api/Sign/SignIn"
                , data: {
                    sEmail: SignInAssist.txtEmail.val()
                    , sPW: SignInAssist.txtPassword.val()
                }
                , success: function (jsonData)
                {
                    if ("0" === jsonData.InfoCode)
                    {
                        SignInAssist.SignIn_ID = jsonData.idUser;
                        SignInAssist.SignIn_Email = jsonData.Email;

                        SignInAssist.access_token = jsonData.access_token;
                        SignInAssist.refresh_token = jsonData.refresh_token;

                        SignInAssist.SignInUi(true);
                    }
                }

            });
    }
};

SignInAssist.OnClick_SignOut = function ()
{
    //ui 처리
    SignInAssist.SignInUi(false);
    //데이터 제거
    SignInAssist.SignIn_ID = 0;
    SignInAssist.SignIn_Email = "";
    SignInAssist.access_token = "";
    SignInAssist.refresh_token = "";

    if (true === SignInAssist.SignIn)
    {
        AA2.put(AjaxAssist.TokenRelayType.None
            , {
                url: "/api/Sign/SignOut"
                , data: {
                    sRefreshToken: SignInAssist.refresh_token
                }
                , success: function (jsonData)
                {
                }

            });
    }
};

/**
 * 사인인 ui를 잠금/풀기
 * @param {any} bSignIn 사인인 여부
 */
SignInAssist.SignInUi = function (bSignIn)
{
    if (undefined !== bSignIn
        && null !== bSignIn)
    {//값이 있다.
        //저장부터 한다.
        SignInAssist.SignIn = bSignIn;
    }
    

    if (true === SignInAssist.SignIn)
    {
        SignInAssist.txtEmail.prop("disabled", true);
        SignInAssist.txtPassword.prop("disabled", true);
        SignInAssist.btnSignInStart.prop("disabled", true);

        SignInAssist.btnSignOutStart.prop("disabled", false);

        SignInAssist.txtAccessToken.val(SignInAssist.access_token);
        SignInAssist.txtRefreshToken.val(SignInAssist.refresh_token);
    }
    else
    {
        SignInAssist.txtEmail.prop("disabled", false);
        SignInAssist.txtPassword.prop("disabled", false);
        SignInAssist.btnSignInStart.prop("disabled", false);

        SignInAssist.btnSignOutStart.prop("disabled", true);

        SignInAssist.txtAccessToken.val("");
        SignInAssist.txtRefreshToken.val("");
    }
};


/** 엑세스 토큰 제거 */
SignInAssist.AccessTokenDelete = function ()
{
    SignInAssist.access_token = "";
    SignInAssist.txtAccessToken.val("");
};
/** 리플레시 토큰 제거 */
SignInAssist.RefreshTokenDelete = function ()
{
    SignInAssist.refresh_token = "";
    SignInAssist.txtRefreshToken.val("");
};