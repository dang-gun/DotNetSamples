using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.AsontuDynamicOrderBy;

/// <summary>
/// EF의 동적 정렬을 위한 실행 식 인터페이스
/// </summary>
public interface IOrderBy
{
    /// <summary>
    /// 사용할 실행식
    /// </summary>
    dynamic Expression { get; }
}
