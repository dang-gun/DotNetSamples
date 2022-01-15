using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsFetchApiTest.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region 단순 호출
        /// <summary>
        /// 단순 호출
        /// </summary>
        /// <returns>TestModel01</returns>
        [HttpGet]
        public ActionResult<TestModel01> Call()
        {
            //리턴용 모델
            TestModel01 tmResult = new TestModel01();
            tmResult.nTest = 0;
            tmResult.sTest = "Call";

            return tmResult;
        }

        /// <summary>
        /// 단순호출 - 메개변수 전달 확인
        /// </summary>
        /// <param name="nData"></param>
        /// <param name="sData"></param>
        /// <returns>TestModel01</returns>
        [HttpGet]
        public ActionResult<TestModel01> Call2(int nData, string sData)
        {
            //리턴용 모델
            TestModel01 tmResult = new TestModel01();
            tmResult.nTest = 100000000 + nData;
            tmResult.sTest = "성공 : " + sData;

            return tmResult;
        }

        /// <summary>
        /// 단순호출(post) - 메개변수 전달 확인
        /// </summary>
        /// <param name="nData">'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' 로 데이터를 전달해야 한다.</param>
        /// <returns>TestModel01</returns>
        [HttpPost]
        public ActionResult<TestModel01> CallPost([FromForm]int nData)
        {
            //리턴용 모델
            TestModel01 tmResult = new TestModel01();
            tmResult.nTest = 2;
            tmResult.sTest = "성공 : " + nData;

            return tmResult;
        }
        #endregion

        #region 강제 에러 발생 테스트
        /// <summary>
        /// 지정된 시간동안 기다렸다가 500에러가 리턴됩니다.
        /// </summary>
        /// <param name="nDelay">대기할 시간(ms)</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<TestModel02> ErrorGet(int nDelay)
        {
            Thread.Sleep(nDelay);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 2;
            tmResult.sTest002 = "Test02";

            return StatusCode(500);
        }

        /// <summary>
        /// 지정된 시간동안 기다렸다가 500에러가 리턴됩니다.
        /// </summary>
        /// <param name="nDelay">대기할 시간(ms)</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TestModel02> ErrorPost([FromForm] int nDelay)
        {
            Thread.Sleep(nDelay);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 2;
            tmResult.sTest002 = "Test02";

            return StatusCode(500);
        }
        #endregion

        #region 대기후 모델(TestModel02) 리턴
        /// <summary>
        /// 지정된 시간 만큼 대기했다가 결과가 전달 된다.
        /// </summary>
        /// <param name="nDelay">대기할 시간(ms)</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<TestModel02> Delay(int nDelay)
        {
            Thread.Sleep(nDelay);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 3;
            tmResult.sTest002 = "Delay : " + nDelay;

            return tmResult;
        }

        /// <summary>
        /// 지정된 시간 만큼 대기했다가 결과가 전달 된다.
        /// </summary>
        /// <param name="nDelay">대기할 시간(ms)</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TestModel02> DelayPost(
            [FromForm] int nDelay
            , [FromForm] int nDelay2)
        {
            Thread.Sleep(nDelay);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 3;
            tmResult.sTest002 = "Delay : " + nDelay + ", Delay2 : " + nDelay2;

            return tmResult;
        }

        /// <summary>
        /// 지정된 시간 만큼 대기했다가 결과가 전달 된다.
        /// 메개변수로 'TestModel02PramModel'를 전달 받는다.
        /// [FromBody]로 바인딩 한다.
        /// </summary>
        /// <param name="dataDelay"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TestModel02> DelayPostFromBody(
            [FromBody] TestModel02PramModel dataDelay)
        {
            Thread.Sleep(dataDelay.nTest);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 3;
            tmResult.sTest002 = "nTest : " + dataDelay.nTest + ", nTest : " + dataDelay.nTest;

            return tmResult;
        }
        #endregion

        #region 인증 테스트
        /// <summary>
        /// (인증 필수)지정된 시간 만큼 대기했다가 결과가 전달 된다.
        /// </summary>
        /// <param name="nDelay">대기할 시간(ms)</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult<TestModel02> AuthGet(int nDelay)
        {
            Thread.Sleep(nDelay);

            //유저 정보 추출
            ClaimModel cm = new ClaimModel(((ClaimsIdentity)User.Identity).Claims);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = nDelay;
            tmResult.sTest002
                = "UserId : " + cm.id_int
                + ", Email : " + cm.email;

            return tmResult;
        }

        /// <summary>
        /// (인증 필수)지정된 시간 만큼 대기했다가 결과가 전달 된다.
        /// </summary>
        /// <param name="nDelay">대기할 시간(ms)</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<TestModel02> AuthPost(
            [FromForm] int nDelay
            , [FromForm] int nDelay2)
        {
            Thread.Sleep(nDelay);

            //유저 정보 추출
            ClaimModel cm = new ClaimModel(((ClaimsIdentity)User.Identity).Claims);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = nDelay;
            tmResult.sTest002
                = "UserId : " + cm.client_id
                + ", Email : " + cm.email;

            return tmResult;
        }
        #endregion

        #region 인증 케이스 바이 케이스
        /// <summary>
        /// (인증 필수)지정된 시간 만큼 대기했다가 결과가 전달 된다.
        /// </summary>
        /// <param name="nDelay">대기할 시간(ms)</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult<TestModel02> CaseByCase_Auth(int nDelay)
        {
            return this.CaseByCase(nDelay);
        }

        [HttpGet]
        public ActionResult<TestModel02> CaseByCase(int nDelay)
        {
            Thread.Sleep(nDelay);

            //유저 정보 추출
            ClaimModel cm = new ClaimModel(((ClaimsIdentity)User.Identity).Claims);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = nDelay;
            tmResult.sTest002
                = "UserId : " + cm.id_int
                + ", Email : " + cm.email;

            return tmResult;
        }
        #endregion
    }

}