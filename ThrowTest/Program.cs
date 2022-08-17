/// <summary>
/// https://stackoverflow.com/a/776756/6725889
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            ThrowException1();
        }
        catch (Exception x)
        {
            Console.WriteLine("Exception 1:");
            Console.WriteLine(x.StackTrace);
        }
        try
        {
            ThrowException2();
        }
        catch (Exception x)
        {
            Console.WriteLine("Exception 2:");
            Console.WriteLine(x.StackTrace);
        }
    }

    private static void ThrowException1()
    {
        try
        {
            DivByZero();
        }
        catch
        {
            throw; //전달받은 예외가 그대로 전달되므로 라인표시 안됨
        }
    }
    private static void ThrowException2()
    {
        try
        {
            DivByZero();
        }
        catch (Exception ex)
        {
            throw ex; //예외가 새로 생성되므로 라인표시 됨
        }
    }

    private static void DivByZero()
    {
        int x = 0;
        int y = 1 / x; //error
    }
}