using DGU_ConsoleAssist;
using SingletonTest.Singletons;

namespace SingletonTest;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, .NET Samples!");
        Console.WriteLine("☆☆☆ Singleton Test(SingletonTest) ☆☆☆");
        Console.WriteLine(" ");

        ConsoleMenuAssist newCA = new ConsoleMenuAssist();
        newCA.WelcomeMessage = $"Console Assist 테스트 메뉴를 선택해 주세요. {Environment.NewLine}"
                                + $"메뉴 번호나 대괄호([])안의 명령어를 입력하면 동작합니다. {Environment.NewLine}"
                                + $"(index가 같으면 같은 개체입니다.){Environment.NewLine}"
                                + $"(같은 메뉴를 여러번 선택하여 index에 변화가 있는지 확인합니다.){Environment.NewLine}"
                                + $"---------------------------------";


        newCA.MenuList.Add(new MenuModel()
        {
            Index = 1,
            TextFormat = "{0}. 《디자인 패턴》[Gamma95]에서 제시된 싱글톤",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine($" ");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($"Gamma95 index = {Gamma95.Instance.Index}");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($" ");

                //true이면 메뉴를 다시 표시한다.
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel()
        {
            Index = 2,
            TextFormat = "{0}. 정적 초기화",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine($" ");
                Console.WriteLine($" ");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($"Static Initialization index = {StaticInitialization.Instance.Index}");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($" ");

                //true이면 메뉴를 다시 표시한다.
                return true;
            }
        });


        newCA.MenuList.Add(new MenuModel()
        {
            Index = 3,
            TextFormat = "{0}. 멀티스레드 상황에서 사용하는 싱글톤",
            Action = (MenuModel menuThis) =>
            {
                //적절한 셈플이 되려면 멀티스레드에서 강제로 하나의 인스턴스에 접근하는 코드를 구현해야 하는데...
                //.NET의 '공용 언어 런타임'에서는 이런상황이 거의 발생하지 않는다.

                Console.WriteLine($" ");
                Console.WriteLine($" ");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($"Multithreaded Singleton index = {MultithreadedSingleton.Instance.Index}");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($" ");

                //true이면 메뉴를 다시 표시한다.
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel()
        {
            Index = 11,
            TextFormat = "{0}. 싱글톤이 없는 경우",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine($" ");
                Console.WriteLine($" ");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($"No Singleton index = {NoSingleton.Instance.Index}");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($" ");

                //true이면 메뉴를 다시 표시한다.
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel()
        {
            Index = 12,
            TextFormat = "{0}. 일반 정적 클래스(프로그램 시작과 동시에 메모리에 생성됨)",
            Action = (MenuModel menuThis) =>
            {

                Console.WriteLine($" ");
                Console.WriteLine($" ");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($"Static No Singleton index = {GlobalStatic.NoSingleton.Index}");
                Console.WriteLine($"◇◇◇◇◇◇◇◇◇◇");
                Console.WriteLine($" ");

                //true이면 메뉴를 다시 표시한다.
                return true;
            }
        });


        newCA.MenuList.Add(new MenuModel());

        newCA.MenuEnd = new MenuModel()
        {
            Index = 0,
            MatchString = "Exit",
            TextFormat = "{0}. [{1}] 종료",
        };


        //
        newCA.QuestionMessage = $"---------------------------------{Environment.NewLine}" 
                                + "메뉴 번호나 명령을 입력해 주세요. : ";

        //메뉴 표시
        newCA.ShowKeyWait(false);


        (new ConsoleExitAssist("------ '{0}'을 눌러 프로그램 종료 ------"
                                , ConsoleKey.R))
            .ExitWait();
    }
}
