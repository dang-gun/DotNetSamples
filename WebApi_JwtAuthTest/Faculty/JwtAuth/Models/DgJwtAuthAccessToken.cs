﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DGAuthServer
{
	/// <summary>
	/// 엑세스 토큰
	/// </summary>
	public class DgJwtAuthAccessToken
	{

		/// <summary>
		/// 외부에 연결할 유저의 고유키
		/// </summary>
		/// <remarks>이 값을 가지고 외부의 유저와 매칭시킨다.</remarks>
		[Key]
		public long idUser { get; set; }

		/// <summary>
		/// 이 유저가 사용중인 시크릿 코드
		/// <para>이 값이 바뀌면 기존 엑세스토큰은 만료된다.</para>
		/// </summary>
		public string Secret { get; set; } = string.Empty;
		
	}
}
