
var SignInAssist = {};

//□□□□□□ 사인 관련 □□□□□□
SignInAssist.SignIn = false;
SignInAssist.SignIn_ID = 0;
SignInAssist.SignIn_Email = "";
SignInAssist.access_token = "";
SignInAssist.refresh_token = "";

SignInAssist.txtAccessToken = null;
SignInAssist.txtRefreshToken = null;

//□□□□□□ 사인인 관련 □□□□□□
SignInAssist.divSignInArea = null;
SignInAssist.txtEmail = null;
SignInAssist.txtPassword = null;
SignInAssist.btnSignInStart = null;

//□□□□□□ 사인아웃 관련 □□□□□□
SignInAssist.btnSignOutStart = "";



/** 초기화 */
SignInAssist.Reset = function ()
{
    SignInAssist.divSignInArea = $("#divSignInArea");
    SignInAssist.txtEmail = $("#txtEmail");
    SignInAssist.txtPassword = $("#txtPassword");
    SignInAssist.btnSignInStart = $("#btnSignInStart");

    SignInAssist.btnSignOutStart = $("#btnSignOutStart");

    SignInAssist.txtAccessToken = $("#txtAccessToken");
    SignInAssist.txtRefreshToken = $("#txtRefreshToken");

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