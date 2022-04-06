using Microsoft.EntityFrameworkCore;

namespace DGAuthServer;

public static class DGAuthServerGlobal
{
	/// <summary>
	/// 사용할 옵션
	/// </summary>
	public static DgJwtAuthSettingModel Setting 
		= new DgJwtAuthSettingModel();

	public static DGAuthServerService Service
		= new DGAuthServerService();

	/// <summary>
	/// DB 컨택스트의 OnConfiguring이벤트에 사용될 액션
	/// </summary>
	public static Action<DbContextOptionsBuilder>? ActDbContextOnConfiguring = null;
}
