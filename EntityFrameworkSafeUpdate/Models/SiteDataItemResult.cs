using ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkSafeUpdate.Models
{
    public class SiteDataItemResult: ApiResultBaseModel
    {
        /// <summary>
        /// 총 방문자.
        /// 2^63-1(9,223,372,036,854,775,807) 가 넘으면 VisitTotalCount를 1 더해준다.
        /// </summary>
        public long VisitTotal { get; set; }
        /// <summary>
        /// 총 방문자 최대 카운터.
        /// 총 방문자가 2^63-1(9,223,372,036,854,775,807)를 몇번 달성했는지 횟수
        /// </summary>
        public long VisitTotalCount { get; set; }
    }
}
