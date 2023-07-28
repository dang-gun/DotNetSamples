using Microsoft.EntityFrameworkCore;

using Global.DB;
using ModelsDB;
using System.Diagnostics;

namespace EfOptimisticConcurrency;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    #region MSSQL
    /// <summary>
    /// mssql 사용
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMssql_Use_Click(object sender, EventArgs e)
    {
        GlobalDb.DBType = UseDbType.Mssql;
        GlobalDb.DBString = txtMssql_ConnectStriong.Text;

        this.DbSetting();

        radioMssqlUse.Checked = true;
        radioSqliteUse.Checked = false;
    }
    #endregion

    #region SQLite
    private void btnSqlite_Use_Click(object sender, EventArgs e)
    {
        GlobalDb.DBType = UseDbType.Sqlite;
        GlobalDb.DBString = txtSqlite_ConnectStriong.Text;

        this.DbSetting();

        radioMssqlUse.Checked = false;
        radioSqliteUse.Checked = true;
    }
    #endregion

    private void DbSetting()
    {
        //db 마이그레이션 적용
        switch (GlobalDb.DBType)
        {
            case UseDbType.Sqlite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
            case UseDbType.Mssql:
                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;

            default://기본
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
        }
    }


    #region 동시성 애플리케이션
    /// <summary>
    /// 동시성 애플리케이션
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnApplicationConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_ApplicationConcurrency(3000, "첫번째");
        this.DB_Update_ApplicationConcurrency(0, "두번째");
    }

    /// <summary>
    /// 동시성 애플리케이션 처리
    /// </summary>
    /// <remarks>
    /// 애플리케이션 관리 동시성 토큰
    /// https://learn.microsoft.com/ko-kr/ef/core/saving/concurrency?tabs=data-annotations#application-managed-concurrency-tokens
    /// </remarks>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_ApplicationConcurrency(
        int nDelay
        , string sStr)
    {
        //비동기 처리
        Task.Run(() =>
        {
            TestOC1? findTarget = null;

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                bool saveFailed = false;
                findTarget = db1.TestOC1.Where(w => w.idTestOC1 == 1).FirstOrDefault();

                do
                {
                    saveFailed = false;
                    try
                    {
                        if (null != findTarget)
                        {
                            Log("TestOC1 findTarget : " + findTarget.Str);

                            findTarget.Int += 1;
                            findTarget.Str = sStr;

                            //☆☆☆☆ 저장할때 항상 GUID를 변경해야 한다.
                            findTarget.Version = Guid.NewGuid();

                            Thread.Sleep(nDelay);

                            db1.SaveChanges();
                            Log("TestOC1 db1.SaveChanges : " + sStr);
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        // 수정하려던 요소를 다시 로드 한다.
                        // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);

            }//end using db1

            this.ReloadDB();
        });
    }
    #endregion


    #region 동시성 서버

    /// <summary>
    /// 동시성 서버
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency(3000, "첫번째");
        this.DB_Update_ServerConcurrency(0, "두번째");
    }

    /// <summary>
    /// 동시성 서버
    /// </summary>
    /// <remarks>
    /// 다시 로드를 사용하여 낙관적 동시성 예외 해결(데이터베이스 승리)
    /// https://learn.microsoft.com/ko-kr/ef/ef6/saving/concurrency#resolving-optimistic-concurrency-exceptions-with-reload-database-wins
    /// </remarks>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_ServerConcurrency(
        int nDelay
        , string sStr)
    {
        //비동기 처리
        Task.Run(() =>
        {
            TestOC2? findTarget = null;

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                bool saveFailed = false;
                findTarget = db1.TestOC2.Where(w => w.idTestOC2 == 1).FirstOrDefault();

                do
                {
                    saveFailed = false;
                    try
                    {
                        if (null != findTarget)
                        {
                            Log("TestOC2 findTarget : " + findTarget.Str);

                            findTarget.Int += 1;
                            findTarget.Str = sStr;

                            Thread.Sleep(nDelay);

                            db1.SaveChanges();
                            Log("TestOC2 db1.SaveChanges : " + sStr);
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        // 수정하려던 요소를 다시 로드 한다.
                        // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);

            }//end using db1

            this.ReloadDB();
        });
    }

    #endregion

    #region 동시성 서버2

    /// <summary>
    /// 동시성 서버
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency2_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency2(3000, "첫번째");
        this.DB_Update_ServerConcurrency2(0, "두번째");
    }

    /// <summary>
    /// 동시성 서버
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_ServerConcurrency2(
        int nDelay
        , string sStr)
    {
        //비동기 처리
        Task.Run(() =>
        {
            TestOC2? findTarget = null;

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                findTarget = db1.TestOC2.Where(w => w.idTestOC2 == 1).FirstOrDefault();

                if (null != findTarget)
                {
                    GlobalDb.SaveChanges_UpdateConcurrency(
                        db1
                        , () =>
                        {
                            findTarget.Int += 1;
                            findTarget.Str = sStr;

                            Thread.Sleep(nDelay);

                            return true;
                        }
                        , -1);
                }

            }//end using db1

            this.ReloadDB();
        });
    }

    #endregion

    #region 동시성 없음
    /// <summary>
    /// 동시성 없음
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNotConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_NoConcurrency(3000, "첫번째");
        this.DB_Update_NoConcurrency(0, "두번째");
    }


    /// <summary>
    /// 동시성 없음
    /// </summary>
    /// <param name="nDelay">저장 직전 딜레이</param>
    /// <param name="sStr"></param>
    private void DB_Update_NoConcurrency(
        int nDelay
        , string sStr)
    {
        //비동기 처리
        Task.Run(() =>
        {
            TestOC3? findTarget = null;

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                findTarget = db1.TestOC3.Where(w => w.idTestOC3 == 1).FirstOrDefault();


                if (null != findTarget)
                {
                    Log("TestOC3 findTarget : " + findTarget.Str);

                    findTarget.Int += 1;
                    findTarget.Str = sStr;

                    Thread.Sleep(nDelay);
                    db1.SaveChanges();
                    Log("TestOC3 db1.SaveChanges : " + sStr);
                }

            }//end using db1

            this.ReloadDB();
        });
    }

    #endregion



    private void ReloadDB()
    {

        TestOC1? findOC1 = null;
        TestOC2? findOC2 = null;
        TestOC3? findOC3 = null;

        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            findOC1 = db1.TestOC1.Where(w => w.idTestOC1 == 1).FirstOrDefault();
            findOC2 = db1.TestOC2.Where(w => w.idTestOC2 == 1).FirstOrDefault();
            findOC3 = db1.TestOC3.Where(w => w.idTestOC3 == 1).FirstOrDefault();
        }

        if (true == InvokeRequired)
        {//다른 쓰래드다.
            this.Invoke(new Action(
                delegate ()
                {
                    this.ViewUi(findOC1, findOC2, findOC3);
                }));
        }
        else
        {//같은 쓰래드다.
            this.ViewUi(findOC1, findOC2, findOC3);
        }
    }

    private void ViewUi(TestOC1? findOC1, TestOC2? findOC2, TestOC3? findOC3)
    {
        if (null != findOC1)
        {
            this.txtDb_TestOC1_Int.Text = findOC1.Int.ToString();
            this.txtDb_TestOC1_Str.Text = findOC1.Str;
        }

        if (null != findOC2)
        {
            this.txtDb_TestOC2_Int.Text = findOC2.Int.ToString();
            this.txtDb_TestOC2_Str.Text = findOC2.Str;
        }

        if (null != findOC3)
        {
            this.txtDb_TestOC3_Int.Text = findOC3.Int.ToString();
            this.txtDb_TestOC3_Str.Text = findOC3.Str;
        }
    }

    private void Log(string sMsg)
    {
        Debug.WriteLine(string.Format("[{0}] {1}"
            , DateTime.Now.ToString("HH:mm:ss")
            , sMsg));
    }


}