using IdentityServer4_Custom.IdentityServer4;
using log4net;
using ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsAjaxAssistTest.Global
{
    /// <summary>
    /// 전역변수 모음
    /// </summary>
    public static class GlobalStatic
    {
        public static ILog log = LogManager.GetLogger("Program");

        /// <summary>
        /// 유저 정보 리스트
        /// </summary>
        public static List<User> User = new List<User>();
        public static List<UserSignIn> UserSignIn = new List<UserSignIn>();
        public static List<UserSignInTokenLog> UserSignInTokenLog = new List<UserSignInTokenLog>();


        /// <summary>
        /// 토큰 처리관련
        /// </summary>
        public static TokenProcess TokenProc = null;


        static GlobalStatic()
        {
            User.Add(new User { 
                idUser = 1,
                SignEmail = "test",
                Password = "1111"
            });
        }

    }
}
