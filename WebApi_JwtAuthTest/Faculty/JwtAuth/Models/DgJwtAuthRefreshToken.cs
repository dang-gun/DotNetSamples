using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JwtAuth.Models
{
	/// <summary>
	/// 리플레시 토큰
	/// </summary>
	public class DgJwtAuthRefreshToken
	{
		/// <summary>
		/// 유저 리플레시 토큰 고유키
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int idUserRefreshToken { get; set; }

		/// <summary>
		/// 외부에 연결할 유저의 고유키
		/// </summary>
		/// <remarks>이 값을 가지고 외부의 유저와 매칭시킨다.</remarks>
		public int idUser { get; set; }

		/// <summary>
		/// 리플레시 토큰
		/// </summary>
		public string RefreshToken { get; set; } = string.Empty;
		
		/// <summary>
		/// 만료 예정 시간
		/// </summary>
		public DateTime ExpiresTime { get; set; }

		/// <summary>
		/// 취소된 시간
		/// </summary>
		public DateTime? RevokeTime { get; set; }

		/// <summary>
		/// 생성당시 아이피
		/// </summary>
		public string? IpCreated { get; set; }

		#region 속성
		/// <summary>
		/// 만료 여부
		/// </summary>
		public bool ExpiredIs { get; set; }
		/// <summary>
		/// 취소 여부
		/// </summary>
		public bool RevokeIs { get; set; }
		/// <summary>
		/// 사용가능 여부
		/// </summary>
		public bool ActiveIs { get; set; }

		#endregion

		/// <summary>
		/// 이 토큰의 사용가능여부를 다시 확인한다.
		/// </summary>
		public DgJwtAuthRefreshToken ActiveCheck()
		{
			this.ExpiredIs = DateTime.UtcNow >= this.ExpiresTime;
			this.RevokeIs = RevokeTime != null;
			this.ActiveIs = RevokeTime == null && !ExpiredIs;

			return this;
		}
	}
}
