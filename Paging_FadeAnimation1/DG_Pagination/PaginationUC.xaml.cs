using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace DG_Pagination;

/// <summary>
/// PaginationUC.xaml에 대한 상호 작용 논리
/// </summary>
public partial class PaginationUC : UserControl
{
    #region 외부에서 연결할 이벤트
    
    /// <summary>
    /// 페이지 네이션의 아이템 클릭시 발생하는 이벤트
    /// </summary>
    public event PageClickDelegate? OnPageClick;
    /// <summary>
    /// 페이지 네이션의 아이템 클릭시 발생하는 이벤트 호출
    /// </summary>
    private void OnPageClickCall(object sender, int nPageNumber)
    {
        if (this.OnPageClick != null)
        {
            this.OnPageClick(sender, nPageNumber);
        }
    }
    #endregion

    /// <summary>
    /// 복사할 개체
    /// <para>PaginationItemInterface를 상속받은 유저컨트롤만 사용가능하다.</para>
    /// </summary>
    public Type? PaginationItemUC { get; set; }

    /// <summary>
    /// 이전 버튼
    /// </summary>
    private Button? PreviousPageBtn;
    /// <summary>
    /// 다음 버튼
    /// </summary>
    private Button? NextPageBtn;


    /// <summary>
    /// 소속된 아이템 리스트
    /// </summary>
    public List<PaginationItemInterface> ItemList { get; set; }
        = new List<PaginationItemInterface>();

    /// <summary>
    /// 보고 있는 현재 페이지(원본)
    /// </summary>
    private int PageNow_ori { get; set; }
    /// <summary>
    /// 보고 있는 현재 페이지
    /// <para>UI도 같이 수정됨</para>
    /// </summary>
    /// <remarks>
    /// 외부에서 설정해야 한다.<br />
    /// 내부에서는 이 값을 수정하지 않는다.
    /// </remarks>
    public int PageNow
    {
        get
        {
            return this.PageNow_ori;
        }
        set
        {
            this.PageNow_ori = value;

            //전체 비활성
            this.ItemList.ForEach(item => item.ActiveIs = false);

            //이 페이지를 찾아 활성화
            PaginationItemInterface? findTemp
                = this.ItemList
                        .Where(item => item.PageNumber == this.PageNow_ori)
                        .FirstOrDefault();
            if (null != findTemp)
            {
                findTemp.ActiveIs = true;
            }

            //전 페이지 버튼
            if (null != this.PreviousPageBtn)
            {
                if (0 >= value)
                {//이전은 없다.

                    this.PreviousPageBtn.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.PreviousPageBtn.Visibility = Visibility.Visible;
                }
            }

            //다음 페이지 버튼
            if (null != this.NextPageBtn)
            {
                if (ItemList.Count - 1 <= value)
                {//다음은 없다.

                    this.NextPageBtn.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.NextPageBtn.Visibility = Visibility.Visible;
                }
            }

        }
    }

    public PaginationUC()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="btnPreviousPage">네비게이션 기준으로 왼쪽으로 이동</param>
    /// <param name="btnNextPage">네비게이션 기준으로 오른쪽으로로 이동</param>
    /// <param name="ucPaginationItem"></param>
    public void DataSettting(
        Button btnPreviousPage
        , Button btnNextPage
        , Type ucPaginationItem)
    {
        this.PreviousPageBtn = btnPreviousPage;
        this.NextPageBtn = btnNextPage;

        this.PaginationItemUC = ucPaginationItem;
    }

    public void PageReSetting(int[] arrPageCount)
    {
        //내용물 비우기
        this.panelPagination.Children.Clear();
        this.ItemList.Clear();

        if(null != this.PaginationItemUC)
        {
            for (int i = 0; i < arrPageCount.Length; ++i)
            {

                // 인스턴스를 생성합니다.
                object instance = Activator.CreateInstance(this.PaginationItemUC)!;

                PaginationItemInterface newItem 
                    = (instance as PaginationItemInterface)!;
                newItem.PageNumber = arrPageCount[i];
                newItem.OnPageClick += NewItem_OnPageClick;

                newItem.ActiveIs = false;

                this.panelPagination.Children.Add(instance as UserControl);
                this.ItemList.Add(newItem);
            }
        }

        
    }

    private void NewItem_OnPageClick(object sender, int nPageNumber)
    {
        this.OnPageClickCall(sender, nPageNumber);
    }

}
