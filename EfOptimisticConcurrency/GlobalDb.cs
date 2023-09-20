using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ModelsDB;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;


namespace Global.DB;


/// <summary>
/// Static으로 선언된 적역 변수들
/// </summary>
public static class GlobalDb
{
    /// <summary>
    /// 낙관적 동시성 - 여러줄 업데이트시 개체별 콜백함수
    /// </summary>
    /// <returns>false이면 낙관적 동시성 시도를 포기한다.</returns>
    public delegate bool MultiUpdateConcurrencyItemFuncDelegate<T>(T item);

    //public static UseDbType DBType = UseDbType.Sqlite;
    //public static string DBString = "Data Source=Test.db";

    public static UseDbType DBType = UseDbType.Mssql;
    public static string DBString = "Server=192.168.0.222;DataBase=LocalTest;UId=LocalTest_Login;pwd=asdf1234@";

    /// <summary>
    /// 낙관적 동시성 적용
    /// </summary>
    /// <remarks>
    /// <para>낙관적 동시성이 체크가 성공하면 저장한다.</para>
    /// <para>지정된 실행식을 지정된 횟수만큼 반복한다.</para>
    /// <para>추적중인 데이터가 모두 다시 로드 되므로 가급적 Context를 짧게 만들어야
    /// 부하도 적고 속도도 빨라진다.</para>
    /// </remarks>
    /// <param name="db1"></param>
    /// <param name="nMaxLoop">최대 반복수. 마이너스 값이면 무한반복한다.</param>
    /// <param name="callback">반복해서 동작시킬 실행식.</param>
    /// <returns>업데이트 성공 여부</returns>
    public static bool SaveChanges_UpdateConcurrency(
        ModelsDbContext db1
        , int nMaxLoop
        , Func<bool> callback)
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
    /// 낙관적 동시성 저장 시도
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




    /// <summary>
    /// 낙관적 동시성 여러행 적용
    /// </summary>
    /// <remarks>
    /// 낙관적 동시성이 체크가 성공하면 저장한다.<br />
    /// 지정된 실행식을 지정된 횟수만큼 반복한다.<br />
    /// 추적중인 데이터가 모두 다시 로드 되므로 가급적 Context를 짧게 만들어야 
    /// 부하도 적고 속도도 빨라진다.
    /// </remarks>
    /// <param name="db1"></param>
    /// <param name="nMaxLoop">최대 반복수. 마이너스 값이면 무한반복한다.</param>
    /// <param name="listLeft"><para>업데이트가 되지않고 남은 리스트</para>
    /// <para>이 리스트는 업데이트가 성공하면 비워진다.</para>
    /// <para>성공하지 못한 개체는 계속 남아있는다.</para>
    /// <para>리턴이 true가 되면 이 리스트의 아이템은 0개가 된다.</para>
    /// <para>리스트의 순서는 바뀔 수 있다.</para></param>
    /// <param name="callbackItem">저장이 실패한 아이템을 반복해서 동작시킬 실행식.</param>
    /// <param name="nDelay">저장전 대기시간</param>
    /// <returns>업데이트 성공 여부</returns>
    public static bool SaveChanges_MultiUpdateConcurrency<T>(
        ModelsDbContext db1
        , int nMaxLoop
        , ref List<T> listLeft
        , MultiUpdateConcurrencyItemFuncDelegate<T> callbackItem
        , int nDelay)
    {
        //반복수
        int nLoopCount = 0;

        //저장 성공 여부
        bool bSaveSuccess = false;

        //첫 동작 여부
        bool bFirstLoop = true;

        //에러 인덱스
        //-1이면 에러가 없다는 의미다.
        int nErrorIdx = 0;

        while (nErrorIdx != -1 )
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
            bool bCallReturn = false;

            if(true == bFirstLoop)
            {//첫 루프에서만 동작

                bFirstLoop = false;
                foreach (T tData in listLeft)
                {
                    bCallReturn = callbackItem(tData);
                    if(false == bCallReturn)
                    {//동시성 포기다.
                        break;
                    }
                }
            }
            else
            {//두번째 루프다.

                //에러난 개체만 갱신한다.
                //(맨 처음 개체가 에러난 개체다.)
                bCallReturn = callbackItem(listLeft[0]);
            }
            

            if (false == bCallReturn)
            {//결과가 거짓이다.

                //낙관적 동시성 종료
                break;
            }

            Thread.Sleep(nDelay);

            nErrorIdx = SaveChanges_MultiUpdateConcurrencyCheck<T>(db1, ref listLeft);
            if(-1 == nErrorIdx)
            {
                bSaveSuccess = true;
                listLeft.Clear();
            }
        }//end while (false == bSaveSuccess)


        return bSaveSuccess;
    }

    /// <summary>
    /// 낙관적 동시성 저장 시도
    /// </summary>
    /// <remarks>
    /// <para>실패하면 해당 개체의 리스트상 인덱스가 리턴된다.</para>
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="db1"></param>
    /// <param name="listLeft">기준이 되는 리스트</param>
    /// <returns>성공하면 -1, 실패한 개체의 리스트상 인덱스</returns>
    public static int SaveChanges_MultiUpdateConcurrencyCheck<T>(
        ModelsDbContext db1
        , ref List<T> listLeft)
    {
        int bReturn = -1;

        try
        {
            db1.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            //Debug.WriteLine($"DbUpdateConcurrencyException : {listLeft.Count} ");

            //수정하려다 실패한 개체
            //DbUpdateConcurrencyException는 실패한 첫 개체를 준다.
            EntityEntry dataFail = ex.Entries.Single();
            // 수정하려던 요소를 다시 로드 한다.
            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
            dataFail.Reload();


            //에러난 개체를 찾는다.
            bReturn = listLeft.IndexOf((T)dataFail.Entity);


            if (-1 != bReturn)
            {//업데이트에 실패한 개체가 있다.

                //인덱스 전까지 있는 개체를 지워준다.
                listLeft.RemoveRange(0, bReturn);
                //이번에 에러난 아이템을 리스트의 맨끝으로 이동시킨다.
                //이렇게 해서 에러난 개체는 마지막에 다시 처리하는 방식으로 처리한다.
                //T objFirstItem = listLeft[0];
                //listLeft.RemoveAt(0);
                //listLeft.Add(objFirstItem);

                //Debug.WriteLine($"DbUpdateConcurrencyException 2 : {listLeft.Count} ");
            }
        }

        return bReturn;
    }
}
