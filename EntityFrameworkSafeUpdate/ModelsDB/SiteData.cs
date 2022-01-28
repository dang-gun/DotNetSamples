using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsDB
{
    /// <summary>
    /// 사이트의 전체 정보
    /// </summary>
    public class SiteData
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idSiteData { get; set; }

        /// <summary>
        /// 총 방문자.
        /// 2^63-1(9,223,372,036,854,775,807) 가 넘으면 VisitTotalCount를 1 더해준다.
        /// </summary>
        [ConcurrencyCheck]
        public long VisitTotal { get; set; }
        /// <summary>
        /// 총 방문자 최대 카운터.
        /// 총 방문자가 2^63-1(9,223,372,036,854,775,807)를 몇번 달성했는지 횟수
        /// </summary>
        [ConcurrencyCheck]
        public long VisitTotalCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
