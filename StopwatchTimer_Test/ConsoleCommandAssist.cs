
namespace Utility;

/// <summary>
/// 콘솔 명령 지원
/// </summary>
public class ConsoleCommandAssist
{
    /// <summary>
    /// 명령어 리스트
    /// </summary>
    private List<ConsoleCommandAssistModel> list 
        = new List<ConsoleCommandAssistModel>();

    /// <summary>
    /// 명령어와 파라메타를 구분하기위한 구분자.
    /// </summary>
    /// <remarks>
    /// 파라메타가 여러개인경우도 이것으로 분리한다.
    /// </remarks>
    public string ParameterSeparator { get; set; } = ":";

    /// <summary>
    /// 명령어 입력 직전에 명령어 리스트를 반복해서 볼지 여부
    /// </summary>
    /// <remarks>
    /// 이 값이 false면 Show를 호출할때만 리스트가 표시된다.
    /// </remarks>
    public bool CommandShowWhile { get; set; }

    /// <summary>
    /// 명령어 입력 반복을 끝낼지 여부
    /// </summary>
    private bool _bExit = false;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bCommandShowWhile">명령어 입력 직전에 명령어 리스트를 반복해서 볼지 여부</param>
    public ConsoleCommandAssist(bool bCommandShowWhile)
    {
        this.CommandShowWhile = bCommandShowWhile;

        this.Add(new ConsoleCommandAssistModel()
        {
            Index = 99
            , Command = "exit"
            , Description = "Exit the app"
            , Action = (arrString) => { this._bExit = true; }
        });
    }

    /// <summary>
    /// 명령줄 무한 읽기를 시작한다.
    /// </summary>
    public void ReadLineWhile()
    {
        //나가기 끄기
        this._bExit = false;

        while(false == this._bExit)
        {
            if(true == this.CommandShowWhile)
            {
                this.Show();
            }

            Console.Write("Please enter the command : ");
            string? sCmdTemp = Console.ReadLine();
            if (null == sCmdTemp)
            {//명령어 없다

                Console.WriteLine("Please enter the command. error=1");
                continue;
            }

            //명령어 분해
            string[] arrCmd = sCmdTemp.Split(":");
            //명령어1
            string sCmd1 = arrCmd[0];
            //파라매타1
            string sCmd2 = string.Empty;
            if (2 <= arrCmd.Length)
            {
                sCmd2 = arrCmd[1];
            }

            //명령어 찾기
            ConsoleCommandAssistModel? findCCA = this.Find(sCmd1);
            if (findCCA == null)
            {
                Console.WriteLine("This is an unknown command.. error=2");
                continue;
            }

            findCCA.Action(new string[] { sCmd2 });


        }
    }

    /// <summary>
    /// 명령어 추가
    /// </summary>
    /// <param name="ccaItem"></param>
    public void Add(ConsoleCommandAssistModel ccaItem)
    {
        this.list.Add(ccaItem);
    }

    /// <summary>
    /// 지정한 명령어나 인덱스로 명령어를 찾는다.
    /// </summary>
    /// <remarks>
    /// 명령어로 찾고 없으면 인덱스로 찾기를 시도한다.<br />
    /// 그래도 없으면 null을 리턴한다.
    /// </remarks>
    /// <param name="sCommand"></param>
    /// <returns></returns>
    public ConsoleCommandAssistModel? Find(string sCommand)
    {
        ConsoleCommandAssistModel? ccaReturn = null;
        ccaReturn = this.list.Where(w => w.Command == sCommand).FirstOrDefault();

        if(null == ccaReturn)
        {
            int nIndex = -1;
            bool bTry = Int32.TryParse(sCommand, out nIndex);
            if (true == bTry)
            {//숫자 형이다.

                //인덱스로 다시 검색
                ccaReturn = this.list.Where(w => w.Index == nIndex).FirstOrDefault();
            }

        }


        return ccaReturn;
    }

    /// <summary>
    /// 가지고 있는 명령어를 나열한다.(인덱스 순으로 정렬)
    /// </summary>
    public void Show()
    {
        this.Show(true);
    }

    /// <summary>
    /// 가지고 있는 명령어를 나열한다.
    /// </summary>
    /// <param name="bOrderByIndex">인덱스 순으로 정렬할지 여부</param>
    public void Show(bool bOrderByIndex)
    {
        Console.WriteLine("------ Command list ------");

        if(true == bOrderByIndex)
        {
            this.list = this.list.OrderBy(w => w.Index).ToList();
        }
        

        foreach (ConsoleCommandAssistModel item in this.list)
        {
            Console.WriteLine($"{item.Index}. {item.Command} : {item.Description}");
        }

        Console.WriteLine("------ ------------ ------");
    }
}

public class ConsoleCommandAssistModel
{
    /// <summary>
    /// 이 명령어에 할당된 인덱스
    /// </summary>
    public int Index { get; set; } = -1;

    /// <summary>
    /// 사용할 명령어
    /// </summary>
    public string Command { get; set; } = string.Empty;

    /// <summary>
    /// 명령어 설명에 표시될 문자열
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 명령어가 들어왔을때 할 동작
    /// </summary>
    /// <remarks>
    /// string[] arr : 전달된 매개변수 배열
    /// </remarks>
    public Action<string[]> Action { get; set; } = (arr) => { };
}