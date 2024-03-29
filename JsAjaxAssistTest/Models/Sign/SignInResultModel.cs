﻿using ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuth.Models.Sign
{
    /// <summary>
    /// 사인인 성공시 전달할 모델
    /// </summary>
    public class SignInResultModel : ApiResultBaseModel
    {
        /// <summary>
        /// 유저의 고유 아이디
        /// </summary>
        public long idUser { get; set; }
        /// <summary>
        /// 이메일
        /// </summary>
        public string Email { get; set; }
        

        /// <summary>
        /// 엑세스 토큰
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 리플레시 토큰
        /// </summary>
        public string refresh_token { get; set; }
        
        /// <summary>
        /// 엑세스 토큰 수명
        /// </summary>
        public int expires_in { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public SignInResultModel()
            : base()
        {
            this.idUser = 0;
            this.Email = string.Empty;
            

            this.access_token = string.Empty;
            this.refresh_token = string.Empty;
            this.expires_in = 0;
        }
    }
}
