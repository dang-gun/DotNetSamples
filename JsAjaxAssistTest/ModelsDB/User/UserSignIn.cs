using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsDB
{
    /// <summary>
    /// 유저 사인인 한 유저의 정보.
    /// </summary>
    public class UserSignIn
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idUserSignIn { get; set; }

        /// <summary>
        /// 연결된 User.idUser
        /// </summary>
        [Required]
        public long idUser { get; set; }

        /// <summary>
        /// 리플레시 토큰
        /// </summary>
        public string RefreshToken { get; set; }


        /// <summary>
        /// ip, IPv6 대비하여 150칸 지정
        /// </summary>
        [MaxLength(150)]
        public string IP { get; set; }
        /// <summary>
        /// 브라우저에서 생성한 고유값
        /// </summary>
        [MaxLength(36)]
        public string GUID { get; set; }



        /// <summary>
        /// 직접 로그인한 시간
        /// </summary>
        public DateTime SignInDate { get; set; }
        /// <summary>
        /// 토큰 갱신 가능 시간
        /// </summary>
        public DateTime RefreshDate { get; set; }

        /// <summary>
        /// 마지막 업데이트 시간
        /// </summary>
        public DateTime LastUpdateDate { get; set; }


        /// <summary>
        /// 동시성 관리
        /// https://docs.microsoft.com/ko-kr/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/handling-concurrency-with-the-entity-framework-in-an-asp-net-mvc-application
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
