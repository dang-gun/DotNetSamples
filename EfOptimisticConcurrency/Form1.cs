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
    /// mssql ���
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
        //db ���̱׷��̼� ����
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

            default://�⺻
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
        }
    }


    #region ���ü� ���ø����̼�
    /// <summary>
    /// ���ü� ���ø����̼�
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnApplicationConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_ApplicationConcurrency(3000, "ù��°");
        this.DB_Update_ApplicationConcurrency(0, "�ι�°");
    }

    /// <summary>
    /// ���ü� ���ø����̼� ó��
    /// </summary>
    /// <remarks>
    /// ���ø����̼� ���� ���ü� ��ū
    /// https://learn.microsoft.com/ko-kr/ef/core/saving/concurrency?tabs=data-annotations#application-managed-concurrency-tokens
    /// </remarks>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_ApplicationConcurrency(
        int nDelay
        , string sStr)
    {
        //�񵿱� ó��
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

                            //�١١١� �����Ҷ� �׻� GUID�� �����ؾ� �Ѵ�.
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
                        // �����Ϸ��� ��Ҹ� �ٽ� �ε� �Ѵ�.
                        // �����Ϸ��� ���� �ʱ�ȭ �ǹǷ� �������� ���� �ٽ� ����ؾ� �Ѵ�.
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);

            }//end using db1

            this.ReloadDB();
        });
    }
    #endregion


    #region ���ü� ����

    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency(3000, "ù��°");
        this.DB_Update_ServerConcurrency(0, "�ι�°");
    }

    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <remarks>
    /// �ٽ� �ε带 ����Ͽ� ������ ���ü� ���� �ذ�(�����ͺ��̽� �¸�)
    /// https://learn.microsoft.com/ko-kr/ef/ef6/saving/concurrency#resolving-optimistic-concurrency-exceptions-with-reload-database-wins
    /// </remarks>
    /// <param name="nDelay"></param>
    /// <param name="sStr"></param>
    private void DB_Update_ServerConcurrency(
        int nDelay
        , string sStr)
    {
        //�񵿱� ó��
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
                        // �����Ϸ��� ��Ҹ� �ٽ� �ε� �Ѵ�.
                        // �����Ϸ��� ���� �ʱ�ȭ �ǹǷ� �������� ���� �ٽ� ����ؾ� �Ѵ�.
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);

            }//end using db1

            this.ReloadDB();
        });
    }

    #endregion

    #region ���ü� ����2

    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnServerConcurrency2_Click(object sender, EventArgs e)
    {
        this.DB_Update_ServerConcurrency2(3000, "ù��°");
        this.DB_Update_ServerConcurrency2(0, "�ι�°");
    }

    /// <summary>
    /// ���ü� ����
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
        //�񵿱� ó��
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

    #region ���ü� ����
    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNotConcurrency_Click(object sender, EventArgs e)
    {
        this.DB_Update_NoConcurrency(3000, "ù��°");
        this.DB_Update_NoConcurrency(0, "�ι�°");
    }


    /// <summary>
    /// ���ü� ����
    /// </summary>
    /// <param name="nDelay">���� ���� ������</param>
    /// <param name="sStr"></param>
    private void DB_Update_NoConcurrency(
        int nDelay
        , string sStr)
    {
        //�񵿱� ó��
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
        {//�ٸ� �������.
            this.Invoke(new Action(
                delegate ()
                {
                    this.ViewUi(findOC1, findOC2, findOC3);
                }));
        }
        else
        {//���� �������.
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