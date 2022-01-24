using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsDB
{
    /// <summary>
    /// 사이트 전체 정보 - 오늘 방문자.
    /// </summary>
    public class SiteData_VisitToday
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idSiteData_VisitToday { get; set; }

        /// <summary>
        /// 기준 날짜
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 기준 날짜의 방문자 숫자
        /// </summary>
        public ulong Count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
