using System.Diagnostics;
using Utility;

namespace StopwatchTimer_Test
{
    internal class Program
    {
        /// <summary>
        /// 0.1초 동작 타이머
        /// </summary>
        //private static System.Timers.Timer _timer01Sec;
        /// <summary>
        /// 스톱워치 타이머
        /// </summary>
        private static StopwatchTimer.Timer stopwatchTimer
            = new StopwatchTimer.Timer();


        private static int _nStopwatchTimer_Count = 0;
        private static void StopwatchTimer_OnElapsed(object sender)
        {

            ++_nStopwatchTimer_Count;
            //this.labStopwatch.Text = this._nStopwatchTimer_Count.ToString();

            Console.Clear();
            Console.WriteLine(_nStopwatchTimer_Count);

            if(100 < _nStopwatchTimer_Count)
            {
                stopwatchTimer.Stop();
            }
        }

        static void Main(string[] args)
        {
            stopwatchTimer.Interval = 10;
            stopwatchTimer.OnElapsed += StopwatchTimer_OnElapsed;

            ConsoleCommandAssist cca 
                = new ConsoleCommandAssist(false);

            


            cca.Add(new ConsoleCommandAssistModel()
            {
                Index = 1
                , Command = "setInterval"
                , Description = "간격 세팅"
                , Action = (arrString) => 
                {
                    int nInterval = Convert.ToInt32(arrString[0]);

                    stopwatchTimer.Interval = nInterval;
                    Console.WriteLine("간격 세팅 성공");
                }
            });

            cca.Add(new ConsoleCommandAssistModel()
            {
                Index = 2
                , Command = "startSW"
                , Description = "스톱워치 시작"
                , Action = (arrString) => 
                {
                    _nStopwatchTimer_Count = 0;
                    stopwatchTimer.Start();
                }
            });

            cca.Add(new ConsoleCommandAssistModel()
            {
                Index = 3
                , Command = "showTick"
                , Description = "틱 정보"
                , Action = (arrString) => 
                {
                    Console.WriteLine($"초당 틱 수로 나타낸 타이머의 빈도 : {Stopwatch.Frequency}");
                    Console.WriteLine($"빈도 ms : {1000f / Stopwatch.Frequency}");
                }
            });

            



            cca.Show();
            cca.ReadLineWhile();


        }
    }
}