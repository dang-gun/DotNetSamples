using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="nData"></param>
        /// <param name="sData"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<TestModel01> Test01(int nData, string sData)
        {
            //리턴용 모델
            TestModel01 tmResult = new TestModel01();
            tmResult.nTest = 1;
            tmResult.sTest = "Test01";

            return tmResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nData"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<TestModel02> Test02(int nData)
        {
            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 2;
            tmResult.sTest002 = "Test02";

            return tmResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nData"></param>
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
        /// 
        /// </summary>
        /// <param name="nData"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TestModel02> ErrorPost(int nDelay)
        {
            Thread.Sleep(nDelay);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 2;
            tmResult.sTest002 = "Test02";

            return StatusCode(500);
        }


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
        /// 
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

        [HttpPost]
        public ActionResult<TestModel02> DelayPost2(
            [FromBody] TestModel02PramModel dataDelay)
        {
            Thread.Sleep(dataDelay.nTest);

            //리턴용 모델
            TestModel02 tmResult = new TestModel02();
            tmResult.nTest001 = 3;
            tmResult.sTest002 = "nTest : " + dataDelay.nTest + ", nTest : " + dataDelay.nTest;

            return tmResult;
        }


    }

}