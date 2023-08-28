using Microsoft.EntityFrameworkCore;
using ModelsDB;
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
    /// 낙관적 동시성 적용
    /// </summary>
    /// <remarks>
    /// 낙관적 동시성이 체크가 성공하면 저장한다.<br />
    /// 지정된 실행식을 지정된 횟수만큼 반복한다.<br />
    /// 추적중인 데이터가 모두 다시 로드 되므로 가급적 Context를 짧게 만들어야 
    /// 부하도 적고 속도도 빨라진다.
    /// </remarks>
    /// <param name="db1"></param>
    /// <param name="callback">반복해서 동작시킬 실행식.</param>
    /// <param name="nMaxLoop">최대 반복수. 마이너스 값이면 무한반복한다.</param>
    /// <returns>업데이트 성공 여부</returns>
    public static bool SaveChanges_UpdateConcurrency(
        ModelsDbContext db1
        , Func<bool> callback
        , int nMaxLoop)
    {
        //반복수
        int nLoopCount = 0;

        //저장 성공 여부
        bool bSaveSuccess = false;
        while (false == bSaveSuccess)
        {//낙관적 동시성 처리

            ++nLoopCount;
            if (0 < nMaxLoop
                && nLoopCount > nMaxLoop)
            {//마이너스값이 아니고
                //지정한 횟수(nMaxLoop)를 넘어섰다.

                //낙관적 동시성 종료
                break;
            }

            //동작 재실행
            bool bCallReturn = callback();
            if(false == bCallReturn)
            {//결과가 거짓이다.

                //낙관적 동시성 종료
                break;
            }

            bSaveSuccess = SaveChanges_UpdateConcurrencyCheck(db1);            
        }//end while (false == bSaveSuccess)

        
        return bSaveSuccess;
    }

    /// <summary>
    /// 낙관적 동시성 체크
    /// </summary>
    /// <remarks>
    /// 낙관적 동시성 체크가 성공면 저장하고 true가 리턴되고
    /// 실패하면 false가 리턴된다.
    /// </remarks>
    /// <param name="db1"></param>
    /// <returns></returns>
    public static bool SaveChanges_UpdateConcurrencyCheck(ModelsDbContext db1)
    {
        bool bReturn = false;

        try
        {
            db1.SaveChanges();
            bReturn = true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Update the values of the entity that failed to save from the store
            // 수정하려던 요소를 다시 로드 한다.
            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
            ex.Entries.Single().Reload();
        }

        return bReturn;
    }
}
