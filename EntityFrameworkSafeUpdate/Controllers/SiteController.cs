using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ApiResult;
using EntityFrameworkSafeUpdate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsDB;

namespace SPA_NetCore_Foundation.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SiteDataItemResult> VisitCountGet()
        {
            //리턴 보조
            ApiResultReady rmResult = new ApiResultReady(this);
            //리턴용 모델
            SiteDataItemResult tmResult = new SiteDataItemResult();
            rmResult.ResultObject = tmResult;

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                //데이터검색
                SiteData findSD
                    = db1.SiteData.FirstOrDefault();

                //전달 모델에 입력
                tmResult.VisitTotal = findSD.VisitTotal;
                tmResult.VisitTotalCount = findSD.VisitTotalCount;
            }

            return rmResult.ToResult();
        }

        /// <summary>
        /// 방문자 +1(비보호)
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ApiResultBaseModel> VisitCount()
        {
            //리턴 보조
            ApiResultReady rmResult = new ApiResultReady(this);

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                //데이터를 로드하고
                //메모리에 저장된다.
                SiteData findSD
                    = db1.SiteData.FirstOrDefault();

                Thread.Sleep(3000);

                //읽어들인 데이터를 +1해주고
                ++findSD.VisitTotal;
                //db에 저장한다.
                db1.SaveChanges();
            }

            return rmResult.ToResult();
        }

        /// <summary>
        /// 방문자 +1(낙관적 동시성)
        /// https://docs.microsoft.com/ko-kr/ef/core/saving/concurrency
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ApiResultBaseModel> VisitCountProtect()
        {
            //리턴 보조
            ApiResultReady rmResult = new ApiResultReady(this);

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                using (ModelsDbContext db2 = new ModelsDbContext())
                {
                    SiteData findSD = null;
                    SiteData findSD2 = null;

                    //대상 검색
                    findSD = db1.SiteData.FirstOrDefault();
                    findSD2 = db2.SiteData.FirstOrDefault();

                    //읽어들인 데이터를 +1해주고
                    ++findSD.VisitTotal;
                    ++findSD2.VisitTotal;

                    //Thread.Sleep(3000);
                    bool bSaveFailed = false;


                    while(false == bSaveFailed)
                    {
                        try
                        {
                            //db에 저장한다.
                            db1.SaveChanges();
                            db2.SaveChanges();
                            bSaveFailed = true;
                        }
                        catch (DbUpdateConcurrencyException e)
                        {
                            foreach (var entry in e.Entries)
                            {
                                if (entry.Entity is SiteData)
                                {
                                    var proposedValues = entry.CurrentValues;
                                    var databaseValues = entry.GetDatabaseValues();

                                    foreach (var property in proposedValues.Properties)
                                    {
                                        var proposedValue = proposedValues[property];
                                        var databaseValue = databaseValues[property];

                                        // TODO: decide which value should be written to database
                                        // proposedValues[property] = <value to be saved>;
                                    }

                                    // Refresh original values to bypass next concurrency check
                                    entry.OriginalValues.SetValues(databaseValues);
                                }
                                else
                                {
                                    throw new NotSupportedException(
                                        "Don't know how to handle concurrency conflicts for "
                                        + entry.Metadata.Name);
                                }
                            }
                        }

                    };
                }//end using db2
            }//end using db1

            return rmResult.ToResult();
        }


        /// <summary>
        /// 방문자 +1(낙관적 동시성 + 업데이트 반복)
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ApiResultBaseModel> VisitCountProtect2()
        {
            //리턴 보조
            ApiResultReady rmResult = new ApiResultReady(this);

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                using (ModelsDbContext db2 = new ModelsDbContext())
                {
                    SiteData findSD = null;
                    SiteData findSD2 = null;

                    //대상 검색
                    findSD = db1.SiteData.FirstOrDefault();
                    

                    //읽어들인 데이터를 +1해주고
                    ++findSD.VisitTotal;

                    //Thread.Sleep(3000);
                    bool bSaveFailed = false;


                    while (false == bSaveFailed)
                    {
                        //수정할 내용 다시 로드
                        findSD2 = db2.SiteData.FirstOrDefault();
                        ++findSD2.VisitTotal;

                        try
                        {
                            //db에 저장한다.
                            db1.SaveChanges();
                            db2.SaveChanges();
                            bSaveFailed = true;
                        }
                        catch (DbUpdateConcurrencyException e)
                        {
                            foreach (var entry in e.Entries)
                            {
                                if (entry.Entity is SiteData)
                                {
                                    var proposedValues = entry.CurrentValues;
                                    var databaseValues = entry.GetDatabaseValues();

                                    foreach (var property in proposedValues.Properties)
                                    {
                                        var proposedValue = proposedValues[property];
                                        var databaseValue = databaseValues[property];

                                        // TODO: decide which value should be written to database
                                        // proposedValues[property] = <value to be saved>;
                                    }

                                    // Refresh original values to bypass next concurrency check
                                    entry.OriginalValues.SetValues(databaseValues);
                                }
                                else
                                {
                                    throw new NotSupportedException(
                                        "Don't know how to handle concurrency conflicts for "
                                        + entry.Metadata.Name);
                                }
                            }
                        }

                    };
                }//end using db2
            }//end using db1

            return rmResult.ToResult();
        }


    }
}