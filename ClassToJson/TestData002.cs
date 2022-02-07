using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassToJson
{
    /// <summary>
    /// 테스트1 열거형
    /// </summary>
    public enum Test1Type
    {
        none = 0,

        emum1,
        emum2,
        emum3,
    }

    /// <summary>
    /// 테스트2 열거형
    /// </summary>
    public enum Test2Type
    {
        none = 0,

        emum10 = 10,
        emum20 = 20,
        emum30 = 30,
    }



    /// <summary>
    /// 테스트용 모델2
    /// </summary>
    public class TestData002
    {
        public double DoubleData { get; set; }
        public float FloatData { get; set; }
        public Test1Type TypeTest1 { get; set; }
        public Test2Type TypeTest2 { get; set; }
    }
}
