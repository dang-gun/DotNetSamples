
using EfMultiMigrations.Models;

namespace EfMultiMigrations;

public static class ModelDllGlobal
{
	/// <summary>
	/// 대상 DB 타입
	/// </summary>
	public static TargetDbType DbType = TargetDbType.None;
	/// <summary>
	/// 사용할 커낵트 스트링
	/// </summary>
	public static string DbConnectString = string.Empty;
}
