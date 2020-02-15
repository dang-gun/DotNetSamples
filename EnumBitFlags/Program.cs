using System;

namespace EnumBitFlags
{
    /// <summary>
    /// 권한1 옵션
    /// </summary>
    public enum Auth1Type
    {
        None = 0

        , Opt0 = 1
        , Opt1 = 2
        , Opt2 = 4
        , Opt3 = 8
        , Opt4 = 16
        , Opt5 = 32
        , Opt6 = 64


        , Opt1_2 = 6
        , Opt1_2_3 = 14
        , Opt1_2_3_4 = 30
        , Opt1_5 = 34

        , OptAll = int.MaxValue
    }

    /// <summary>
    /// 권한2 옵션
    /// </summary>
    public enum Auth2Type
    {
        None = 0

        , Opt0 = 1 << 0
        , Opt1 = 1 << 1
        , Opt2 = 1 << 2
        , Opt3 = 1 << 3
        , Opt4 = 1 << 4
        , Opt5 = 1 << 5
        , Opt6 = 1 << 6


        , OptAll = int.MaxValue
        , Opt1_5 = Opt1 | Opt5
    }

    /// <summary>
    /// 권한3 옵션
    /// </summary>
    [Flags]
    public enum Auth3Type
    {
        None = 0

        , Opt0 = 1 << 0
        , Opt1 = 1 << 1
        , Opt2 = 1 << 2
        , Opt3 = 1 << 3
        , Opt4 = 1 << 4
        , Opt5 = 1 << 5
        , Opt6 = 1 << 6

        , OptAll = int.MaxValue
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("----- Auth1Type ----");
            Auth1Type typeAuth1 = Auth1Type.None;

            typeAuth1 = Auth1Type.Opt1 | Auth1Type.Opt5;

            Console.WriteLine("value : " + typeAuth1.GetHashCode());
            Console.WriteLine("string : " + typeAuth1.ToString());
            Console.WriteLine("Auth1Type.Opt1 : " + typeAuth1.HasFlag(Auth1Type.Opt1));
            Console.WriteLine("Auth1Type.Opt2 : " + typeAuth1.HasFlag(Auth1Type.Opt2));
            Console.WriteLine("  ");


            Console.WriteLine("----- Auth2Type ----");
            Auth2Type typeAuth2 = Auth2Type.None;

            typeAuth2 = Auth2Type.Opt1 | Auth2Type.Opt5;

            Console.WriteLine("value : " + typeAuth2.GetHashCode());
            Console.WriteLine("string : " + ((Auth2Type)typeAuth2).ToString());
            Console.WriteLine("Auth2Type.Opt1 : " + typeAuth2.HasFlag(Auth2Type.Opt1));
            Console.WriteLine("Auth2Type.Opt2 : " + typeAuth2.HasFlag(Auth2Type.Opt2));
            Console.WriteLine("  ");


            Console.WriteLine("----- Auth3Type ----");
            Auth3Type typeAuth3 = Auth3Type.None;

            typeAuth3 = Auth3Type.Opt1 | Auth3Type.Opt5;
            //typeAuth3 = Auth3Type.OptAll;

            Console.WriteLine("value : " + typeAuth3.GetHashCode());
            Console.WriteLine("string : " + ((Auth3Type)typeAuth3).ToString());
            Console.WriteLine("Auth3Type.Opt1 : " + typeAuth3.HasFlag(Auth3Type.Opt1));
            Console.WriteLine("Auth3Type.Opt2 : " + typeAuth3.HasFlag(Auth3Type.Opt2));
            Console.WriteLine("  ");




            Console.WriteLine("----- Uses ----");

            Console.WriteLine("//모든 값 빼기");
            typeAuth3 = Auth3Type.None;
            Console.WriteLine("typeAuth3 = Auth3Type.None; ====> : " + typeAuth3);
            Console.WriteLine("typeAuth3.HasFlag(Auth3Type.Opt1) ====> : " + typeAuth3.HasFlag(Auth3Type.Opt1));
            Console.WriteLine("typeAuth3.HasFlag(Auth3Type.Opt2) ====> : " + typeAuth3.HasFlag(Auth3Type.Opt2));
            Console.WriteLine("  ");


            Console.WriteLine("//모든 값 넣기");
            typeAuth3 = Auth3Type.OptAll;
            Console.WriteLine("typeAuth3 = Auth3Type.OptAll; ====> : " + typeAuth3);
            Console.WriteLine("typeAuth3.HasFlag(Auth3Type.Opt1) ====> : " + typeAuth3.HasFlag(Auth3Type.Opt1));
            Console.WriteLine("typeAuth3.HasFlag(Auth3Type.Opt2) ====> : " + typeAuth3.HasFlag(Auth3Type.Opt2));
            Console.WriteLine("  ");


            Console.WriteLine("//값 넣기");
            typeAuth3 = Auth3Type.Opt1 | Auth3Type.Opt3;
            Console.WriteLine("typeAuth3 = Auth3Type.Opt1 | Auth3Type.Opt3; ====> : " + typeAuth3);
            Console.WriteLine("  ");


            Console.WriteLine("//기존 값에 추가하기");
            typeAuth3 |= Auth3Type.Opt5 | Auth3Type.Opt6;
            Console.WriteLine("typeAuth3 |= Auth3Type.Opt5; ====> : " + typeAuth3);
            Console.WriteLine("  ");


            Console.WriteLine("//값 빼기");
            typeAuth3 &= ~Auth3Type.Opt5;
            Console.WriteLine("typeAuth3 &= ~Auth3Type.Opt5; ====> : " + typeAuth3);
            Console.WriteLine("  ");


            Console.WriteLine("//값 반전(있으면 빠지고 없으면 추가됨)");
            typeAuth3 ^= Auth3Type.Opt6;
            Console.WriteLine("typeAuth3 ^= Auth3Type.Opt6; ====> : " + typeAuth3);
            typeAuth3 ^= Auth3Type.Opt6;
            Console.WriteLine("typeAuth3 ^= Auth3Type.Opt6; ====> : " + typeAuth3);
            Console.WriteLine("  ");

            Console.WriteLine("//몇가지 값을 빼고 전체 설정 넣기");
            typeAuth3 = Auth3Type.OptAll ^ Auth3Type.Opt1 ^ Auth3Type.Opt6;
            Console.WriteLine("typeAuth3 = Auth3Type.OptAll ^Auth3Type.Opt1 ^Auth3Type.Opt6; ====> : " + typeAuth3);
            Console.WriteLine("  ");


            Console.WriteLine("//값 특정값이 있는지 확인");
            Console.WriteLine("typeAuth3.HasFlag(Auth3Type.Opt1) ====> : " + typeAuth3.HasFlag(Auth3Type.Opt1));
            Console.WriteLine("typeAuth3.HasFlag(Auth3Type.Opt2) ====> : " + typeAuth3.HasFlag(Auth3Type.Opt2));
            Console.WriteLine("  ");

        }
    }
}
