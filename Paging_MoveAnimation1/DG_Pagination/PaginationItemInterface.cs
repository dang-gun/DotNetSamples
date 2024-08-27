using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Pagination;

/// <summary>
/// 페이지 네이션의 아이템 클릭시 전달할 대리자
/// </summary>
/// <param name="sender"></param>
/// <param name="nPageNumber"></param>
public delegate void PageClickDelegate(object sender, int nPageNumber);

/// <summary>
/// 페이지네이션 아이템 사용할 인터페이스
/// </summary>
public interface PaginationItemInterface
{
    /// <summary>
    /// 페이지 네이션의 아이템 클릭시 발생하는 이벤트
    /// </summary>
    public event PageClickDelegate? OnPageClick;

    /// <summary>
    /// 활성화 여부
    /// </summary>
    public bool ActiveIs { get; set; }

    /// <summary>
    /// 이 아이템의 페이지 번호
    /// </summary>
    public int PageNumber { get; set; }
}
