using System.Security.Cryptography;
using System.Text;

namespace Global.DB;

/// <summary>
/// Static으로 선언된 적역 변수들
/// </summary>
public static class GlobalDb
{

    //public static UseDbType DBType = UseDbType.Sqlite;
    //public static string DBString = "Data Source=Test.db";

    public static UseDbType DBType = UseDbType.Mssql;
    public static string DBString = "Server=192.168.0.222;DataBase=LocalTest;UId=LocalTest_Login;pwd=asdf1234@";


    /// <summary>
    /// 문자열로 저장된 배열(혹은 리스트)의 데이터를 구분할때 사용하는 구분자
    /// </summary>
    /// <remarks>
    /// 이 값을 중간에 바꾸면 기존의 데이터를 재대로 못읽을 수 있다.
    /// </remarks>
    public static char DbArrayDiv = '▒';

}
