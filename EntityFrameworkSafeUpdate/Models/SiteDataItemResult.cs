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
        /// 18,446,744,073,709,551,615 가 넘으면 VisitTotalCount를 1 더해준다.
        /// </summary>
        public ulong VisitTotal { get; set; }
        /// <summary>
        /// 총 방문자 최대 카운터.
        /// 총 방문자가 18,446,744,073,709,551,615를 몇번 달성했는지 횟수
        /// </summary>
        public ulong VisitTotalCount { get; set; }
    }
}
