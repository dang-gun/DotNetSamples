using Microsoft.EntityFrameworkCore;
using System.Linq;

using Global.DB;
using ModelsDB;
using ModelsDB.Test3Blog;

namespace EfForeignKey;

internal class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Entity Framework Foreign Key test!");

        Console.WriteLine("DB Setting....");

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

        //딱 한번만 호출해야 한다.
        //Db_DataAdd();

        DateTime dtNow = DateTime.Now;

        //테스트
        //using (ModelsDbContext db1 = new ModelsDbContext())
        //{
        //    //블로그는 순차 생성
        //    //for (int i = 1; i < 100; ++i)
        //    //{
        //    //    Test1Blog newT1B = new Test1Blog();
        //    //    newT1B.Name = $"Test1Blog {i}";
        //    //    db1.Test1Blog.Add(newT1B);

        //    //    Test2Blog newT2B = new Test2Blog();
        //    //    newT2B.Name = $"Test2Blog {i}";
        //    //    db1.Test2Blog.Add(newT2B);
        //    //}

        //    //db1.SaveChanges();

        //    //Db_DataAdd_Temp2(new Random(), db1);
        //    //db1.SaveChanges();


        //    Test1Blog iqTO = db1.Test1Blog.Include(x => x.Posts).First();

        //    List<Test1Post> listTO = new List<Test1Post>();

        //    Test1Post t1pTemp = db1.Test1Post.First();
        //    Test1Blog t1bTemp = t1pTemp.Blog;

        //    Console.WriteLine($"iqTO : {iqTO.Name}, listTO count : {listTO.Count}");
        //    Console.WriteLine($"t1pTemp = t1bTemp : {t1bTemp.Name}");
        //}

        //return;



        //임의 테스트용
        using (ModelsDbContext db0 = new ModelsDbContext())
        {
            //Test3Blog new1T3_1 = new Test3Blog();
            //new1T3_1.Name = "new1T3_1";
            //db0.Test3Blog.Add(new1T3_1);
            //Test3Blog new1T3_2 = new Test3Blog();
            //new1T3_2.Name = "new1T3_2";
            //db0.Test3Blog.Add(new1T3_2);

            //db0.SaveChanges();

            //Test3Post newT3_P1 = new Test3Post();
            //newT3_P1.idTest3Blog = new1T3_1.idTest3Blog;
            //newT3_P1.Date = dtNow;
            //newT3_P1.Str = "newT3_P1";
            //db0.Test3Post.Add(newT3_P1);

            //Test3Post newT3_P2 = new Test3Post();
            //newT3_P2.idTest3Blog = new1T3_1.idTest3Blog;
            //newT3_P2.Date = dtNow;
            //newT3_P2.Str = "newT3_P2";
            //db0.Test3Post.Add(newT3_P2);

            //Test3Post newT3_P_2_1 = new Test3Post();
            //newT3_P_2_1.idTest3Blog = new1T3_2.idTest3Blog;
            //newT3_P_2_1.Date = dtNow;
            //newT3_P_2_1.Str = "newT3_P1";
            //db0.Test3Post.Add(newT3_P_2_1);

            //db0.SaveChanges();


            List<Test3Post> list
                = db0.Test3Blog
                    .Where(w => w.idTest3Blog == 1)
                    .First()
                    .Test3Post
                    .ToList();

            if (1 == 1)
            { }

        }



        Console.WriteLine("****** select list ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test1Blog> iqTO = db1.Test1Blog;
            List<Test1Blog> listTO = iqTO.ToList();

            Console.WriteLine($"count : {listTO.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test2Blog> iqTO = db1.Test2Blog;
            
            List<Test2Blog> listTO = iqTO.ToList();

            Console.WriteLine($"count : {listTO.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }


        Console.WriteLine(" ");
        Console.WriteLine("****** select take(non Include) child ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            List<Test1Select> listTo
                = (from t1b in db1.Test1Blog.Take(1)
                   select new Test1Select()
                   {
                       idTest1Blog = t1b.idTest1Blog,
                       Name = t1b.Name,
                       Posts = t1b.Posts.ToList(),
                   })
                   .ToList();

            Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            List<Test2Select> listTo
                = (from t2b in db1.Test2Blog.Take(1)
                   select new Test2Select()
                   {
                       idTest2Blog = t2b.idTest2Blog,
                       Name = t2b.Name,
                       Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                   })
                   .ToList();

            Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }



        Console.WriteLine(" ");
        Console.WriteLine("****** select take child ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test1Select> list
                = (from t1b in db1.Test1Blog.Take(1).Include(i => i.Posts)
                   select new Test1Select()
                   {
                       idTest1Blog = t1b.idTest1Blog,
                       Name = t1b.Name,
                       Posts = t1b.Posts.ToList(),
                   });

            List<Test1Select> listTo = list.ToList();

            Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            //Console.WriteLine("query : ");
            //Console.WriteLine(list.ToQueryString());
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test2Select> list
                = (from t2b in db1.Test2Blog.Take(1)
                   select new Test2Select()
                   {
                       idTest2Blog = t2b.idTest2Blog,
                       Name = t2b.Name,
                       Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                   });

            List<Test2Select> listTo = list.ToList();
            Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            //Console.WriteLine("query : ");
            //Console.WriteLine(list.ToQueryString());
        }



        Console.WriteLine(" ");
        Console.WriteLine("****** select where child ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test1Select> list
                = (from t1b in db1.Test1Blog.Where(w => w.idTest1Blog == 1)
                   select new Test1Select()
                   {
                       idTest1Blog = t1b.idTest1Blog,
                       Name = t1b.Name,
                       Posts = t1b.Posts.ToList(),
                   });

            List<Test1Select> listTo = list.ToList();

            Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            //Console.WriteLine("query : ");
            //Console.WriteLine(list.ToQueryString());
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test2Select> list
                = (from t2b in db1.Test2Blog.Where(w => w.idTest2Blog == 1)
                   select new Test2Select()
                   {
                       idTest2Blog = t2b.idTest2Blog,
                       Name = t2b.Name,
                       Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                   });

            List<Test2Select> listTo = list.ToList();
            Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            //Console.WriteLine("query : ");
            //Console.WriteLine(list.ToQueryString());
        }


        Console.WriteLine(" ");
        Console.WriteLine("****** select where child 30 ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test1Select> list
                = (from t1b in db1.Test1Blog.Where(w => 1 <= w.idTest1Blog && w.idTest1Blog <= 30)
                   select new Test1Select()
                   {
                       idTest1Blog = t1b.idTest1Blog,
                       Name = t1b.Name,
                       Posts = t1b.Posts.ToList(),
                   });

            List<Test1Select> listTo = list.ToList();

            Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            //Console.WriteLine("query : ");
            //Console.WriteLine(list.ToQueryString());
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<Test2Select> list
                = (from t2b in db1.Test2Blog.Where(w => 1 <= w.idTest2Blog && w.idTest2Blog <= 30)
                   select new Test2Select()
                   {
                       idTest2Blog = t2b.idTest2Blog,
                       Name = t2b.Name,
                       Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                   });

            List<Test2Select> listTo = list.ToList();
            Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            //Console.WriteLine("query : ");
            //Console.WriteLine(list.ToQueryString());
        }





        Console.WriteLine(" ");
        Console.WriteLine("****** select child list ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            List<Test1Select> list
                = (from t1b in db1.Test1Blog.Where(w => 1 <= w.idTest1Blog && w.idTest1Blog <= 10)
                   select new Test1Select()
                  {
                      idTest1Blog = t1b.idTest1Blog,
                      Name = t1b.Name,
                      Posts = t1b.Posts.ToList(),
                  })
                  .ToList();

            int c = 0;
            foreach (Test1Select t in list)
            {
                if(null != t.Posts)
                {
                    c += t.Posts.Count;
                }
            }

            Console.WriteLine($"count : {list.Count}, post:{c}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            List<Test2Select> list
                = (from t2b in db1.Test2Blog.Where(w => 1 <= w.idTest2Blog && w.idTest2Blog <= 10)
                   select new Test2Select()
                   {
                       idTest2Blog = t2b.idTest2Blog,
                       Name = t2b.Name,
                       Posts = db1.Test2Post.Where(w=>w.idTest2Blog == t2b.idTest2Blog).ToList(),
                   })
                  .ToList();

            int c = 0;
            foreach (Test2Select t in list)
            {
                if (null != t.Posts)
                {
                    c += t.Posts.Count;
                }
            }

            Console.WriteLine($"count : {list.Count}, post:{c}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }





        Console.WriteLine(" ");
        Console.WriteLine("****** item to parent list ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            Test1Post iqTO = db1.Test1Post.Include(i => i.Blog).First();
            Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            Test1Blog? t1b = iqTO.Blog;
            string sName = string.Empty;
            if(null != t1b)
            {
                sName = t1b.Name;
            }
            Console.WriteLine($"blog : {sName}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            Test2Post iqTO = db1.Test2Post.First();
            Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


            Test2Blog t2b
                = db1.Test2Blog
                    .Where(w => w.idTest2Blog == iqTO.idTest2Blog)
                    .First();
            Console.WriteLine($"blog : {t2b.Name}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }



        Console.WriteLine(" ");
        Console.WriteLine("****** item to parent list (non Include) ******");
        Console.WriteLine(" start select fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            Test1Post iqTO = db1.Test1Post.First();
            Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

            iqTO.Blog
                = db1.Test1Blog
                    .Where(w => w.idTest1Blog == iqTO.idTest1Blog)
                    .FirstOrDefault();

            Test1Blog? t1b = iqTO.Blog;
            string sName = string.Empty;
            if (null != t1b)
            {
                sName = t1b.Name;
            }
            Console.WriteLine($"blog : {sName}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }

        Console.WriteLine(" start select non fk list --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            Test2Post iqTO = db1.Test2Post.First();
            Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


            Test2Blog t2b
                = db1.Test2Blog
                    .Where(w => w.idTest2Blog == iqTO.idTest2Blog)
                    .First();
            Console.WriteLine($"blog : {t2b.Name}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
        }




        Console.WriteLine("------- 'R' 을 눌러 프로그램 종료 ------");

        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();
        } while (keyinfo.Key != ConsoleKey.R);
    }

    /// <summary>
    /// 데이터 생성
    /// </summary>
    /// <remarks>
    /// 마이그레이션에서 데이터를 넣으면 마이그레이션 파일이 너무 커지는 현상이 있다.
    /// 이 함수를 수동으로 한번만 호출하여 테스트용 DB파일을 생성한다.
    /// </remarks>
    static void Db_DataAdd()
    {
        Random rand = new Random();

        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            Console.WriteLine("DB data add start1");

            //블로그는 순차 생성
            for (int i = 1; i < 10000; ++i)
            {
                Test1Blog newT1B = new Test1Blog();
                newT1B.Name = $"Test1Blog {i}";
                db1.Test1Blog.Add(newT1B);

                Test2Blog newT2B = new Test2Blog();
                newT2B.Name = $"Test2Blog {i}";
                db1.Test2Blog.Add(newT2B);
            }

            db1.SaveChanges();
        }

        using (ModelsDbContext db2 = new ModelsDbContext())
        {
            Console.WriteLine("DB data add start2");
            for (int i = 1; i <= 1; ++i)
            {
                Db_DataAdd_Temp1(i, rand);
            }

            Console.WriteLine("DB data add End");
        }

    }

    /// <summary>
    /// 10만번씩 끊어서 실행
    /// </summary>
    /// <param name="nCount"></param>
    /// <param name="rand"></param>
    static void Db_DataAdd_Temp1(
        int nCount
        , Random rand)
    {
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            Console.WriteLine("DB data add start2-" + nCount);
            for (int i = 1; i < 100000; ++i)
            {
                Db_DataAdd_Temp2(rand, db1);
            }

            db1.SaveChanges();
        }
    }

    /// <summary>
    /// 1개를 넣는다.
    /// </summary>
    /// <param name="rand"></param>
    /// <param name="db1"></param>
    static void Db_DataAdd_Temp2(
        Random rand
        , ModelsDbContext db1)
    {
        int Int = rand.Next(0, 100000);
        string Str = Guid.NewGuid().ToString();
        DateTime Date = new DateTime(rand.Next(0, 1000000));
        long idFK = rand.Next(1, 10000);
        //long idFK = rand.Next(0, 100);

        Test1Post newT1P = new Test1Post();
        newT1P.Int = Int;
        newT1P.Str = Str;
        newT1P.Date = Date;
        //외래키 연결 랜덤하게 
        newT1P.idTest1Blog = idFK;
        db1.Test1Post.Add(newT1P);


        Test2Post newT2P = new Test2Post();
        newT2P.Int = Int;
        newT2P.Str = Str;
        newT2P.Date = Date;
        //외래키 연결 랜덤하게 
        newT2P.idTest2Blog = idFK;
        db1.Test2Post.Add(newT2P);
    }
}