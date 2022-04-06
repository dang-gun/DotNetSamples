﻿using System.Security.Cryptography;

namespace DGAuthServer;

public class DgJwtAuthSettingModel
{
	/// <summary>
	/// 인증용 헤더의 이름
	/// <para>기본값 : authorization</para>
	/// </summary>
	/// <remarks>인증 토큰을 찾을때 사용하는 이름이다.</remarks>
	public string AuthHeaderName { get; set; } = "authorization";

	/// <summary>
	/// 인증 토큰의 시작 이름
	/// <para>기본값 : bearer</para>
	/// </summary>
	/// <remarks>
	/// AuthHeaderName으로 찾은 인증토큰의 값이 시작 이름이다.<br />
	/// 실제 사용되는 값은 AuthTokenStartName_Complete이고
	/// 이 값은 AuthTokenStartName_Complete를 설정하는 용도이다.<br />
	/// AuthTokenStartName_Complete에는 자동으로 뒤에 공백을 붙여서 들어가므로
	/// 뒷 공백을 넣으면 안된다.
	/// </remarks>
	public string AuthTokenStartName 
	{
		get
		{
			//뒤에 공백을 제거하고 전달
			return AuthTokenStartName_Complete.TrimEnd();
		}
		set
		{
			//뒤에 공백을 추가하고 전달
			AuthTokenStartName_Complete = value.TrimEnd() + " ";
		}
	}
	/// <summary>
	/// 인증 토큰의 시작 이름 - 실제로 사용되는 값
	/// </summary>
	public string AuthTokenStartName_Complete { get; protected set; } = "bearer ";

	/// <summary>
	/// 엑세스 토큰 생성에 사용될 시크릿 키
	/// </summary>
	/// <remarks>
	/// 이값이 null이거나 비어있으면 자동으로 생성된다.<br />
	/// 자동으로 생성된 값은 프로그램이 실행되는 동안만 유지되므로
	/// 웹사이트를 껏다키면 그전에 생성된 엑세스 토큰은 사용할 수 없게 된다.<br />
	/// <br />
	/// 이 값을 고정해야 웹사이트를 껏다켜는것과 관계없이 엑세스토큰이 유지된다.
	/// </remarks>
	public string? Secret 
	{
		get
		{
			if (null == this._secret
				|| string.Empty == this._secret)
			{//가지고 있는 값이 비어있다.

				//값을 생성한다.
				this._secret 
					= Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)); ;
			}

			return this._secret;
		}
		set
		{
			if (null == value
				|| string.Empty == value)
			{//전달되 값이 비어있다.
			 //값을 바꾸지 않는다.
			}
			else
			{
				this._secret = value;
			}
		}
	}
	/// <summary>
	/// 엑세스 토큰 생성에 사용될 시크릿 키(원본)
	/// </summary>
	private string _secret = string.Empty;

	/// <summary>
	/// 혼자 사용하는 시크릿을 사용할지 여부(개인 시크릿 키)<br />
	/// 이걸 사용하면 <see cref="this.Secret">Secret</see> 는 무시된다.
	/// </summary>
	/// <remarks>
	/// 시크릿을 혼자 사용하면 엑세스 토큰을 강제로 만료시키는 기능을 사용할 수 있다.<br />
	/// 보안상으로도 더 좋다.<br />
	/// 하지만 매번 저장소를 검색해야 하므로 자원낭비가 심하다.<br />
	/// 자신의 서비스가 동시접속자가 많다면 권장하지 않는 기능이다.
	/// </remarks>
	public bool SecretAlone { get; set; } = false;
	/// <summary>
	/// 혼자 사용하는 시크릿사용시 구분 기호
	/// </summary>
	/// <remarks>개인용 시크릿키를 검색하기위해 
	/// 엑세스토큰 맨앞에 사용자 고유번호가 붙게 된다.<br />
	/// 이때 이 고유번호를 구분하기위한 구분 기호이다.</remarks>
	//public string SecretAloneDelimeter { get; set; } = "▒";
	public string SecretAloneDelimeter { get; set; } = "%";

	#region 엑세스 토큰
	/// <summary>
	/// 엑세스토큰 수명(초, s)
	/// <para>기본값 3600 = 1시간</para>
	/// </summary>
	public int AccessTokenLifetime { get; set; } = 3600;

	/// <summary>
	/// 엑세스 토큰 쿠키 저장 여부
	/// </summary>
	/// <remarks>엑세스 토큰을 CookieOptions으로 넘겨 자동으로 저장하고 읽을지 여부이다.<br/>
	/// 이것을 사용하면 직접 전달한 토큰은 무시되고 쿠키에 있는 토큰만 사용하게 된다.
	/// </remarks>
	public bool AccessTokenCookie { get; set; } = true;

	/// <summary>
	/// 엑세스 토큰 쿠키 저장사용시 사용할 쿠키 이름
	/// </summary>
	/// <remarks>다른 쿠키이름과 중복되지 않도록 한다.</remarks>
	public string AccessTokenCookieName { get; set; } = "DGAccessToken";

	#endregion

	#region 리플레시 토큰
	/// <summary>
	/// 리플레시 토큰의 수명(초, s)
	/// <para>기본값 1296000 = 15일</para>
	/// </summary>
	/// <remarks>
	/// 이미 발급된 토큰은 적용되지 않는다.<br />
	/// 기존 토큰에 적용하려면 DB를 갱신해야한다.
	/// </remarks>
	public int RefreshTokenLifetime { get; set; } = 1296000;


	/// <summary>
	/// 리플레시 토큰 쿠키 저장 여부
	/// </summary>
	/// <remarks>리플레시 토큰을 CookieOptions으로 넘겨 자동으로 저장하고 읽을지 여부이다.<br/>
	/// 이것을 사용하면 직접 전달한 토큰은 무시되고 쿠키에 있는 토큰만 사용하게 된다.
	public bool RefreshTokenCookie { get; set; } = true;

	/// <summary>
	/// 리플레시 토큰 쿠키 저장사용시 사용할 쿠키 이름
	/// </summary>
	/// <remarks>다른 쿠키이름과 중복되지 않도록 한다.</remarks>
	public string RefreshTokenCookieName { get; set; } = "DGRefreshToken";

	/// <summary>
	/// 리플레시 토큰 다시사용여부
	/// </summary>
	/// <remarks>리플레시 토큰이 아직 유효한경우 새로 발급하지 않고
	/// 기존 토큰을 다시 사용할지 여부이다.</remarks>
	public RefreshTokenUsageType RefreshTokenReUseType { get; set; } 
		= RefreshTokenUsageType.OneTimeOnlyDelay;
	/// <summary>
	/// RefreshTokenReUseType에서 OneTimeOnlyDelay옵션 사용시 적용되는 지연시간(초, s)<br />
	/// 기본값 : 3
	/// </summary>
	public int OneTimeOnlyDelayTime { get; set; } = 3;
	#endregion


	/// <summary>
	/// 유저 고유번호를 나타내는 이름
	/// </summary>
	/// <remarks>크래임을 비롯하여 토큰의 소유자를 구분하기위한 
	/// 아이디를 검색할때 사용하는 이름이다.</remarks>
	public string UserIdName { get; set; } = "idUser";

	/// <summary>
	/// 사용할 디비 타입 0=InMemory 
	/// </summary>
	public int DbType { get; set; } = 0;

	/// <summary>
	/// 모든 데이터를 복사한다.
	/// </summary>
	/// <param name="data"></param>
	public void ToCopy(DgJwtAuthSettingModel data)
	{
		this.AuthHeaderName = data.AuthHeaderName;
		this.AuthTokenStartName = data.AuthTokenStartName;

		this.Secret = data.Secret;
		this.SecretAlone = data.SecretAlone;
		
		this.AccessTokenLifetime = data.AccessTokenLifetime;
		this.AccessTokenCookie = data.AccessTokenCookie;
		this.AccessTokenCookieName = data.AccessTokenCookieName;

		this.RefreshTokenLifetime = data.RefreshTokenLifetime;
		this.RefreshTokenCookie = data.RefreshTokenCookie;
		this.RefreshTokenCookieName = data.RefreshTokenCookieName;
		this.RefreshTokenReUseType = data.RefreshTokenReUseType;
		this.OneTimeOnlyDelayTime = data.OneTimeOnlyDelayTime;

		this.UserIdName = data.UserIdName;

		this.DbType = data.DbType;
	}
		
}
