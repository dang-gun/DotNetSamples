using DG_Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestPage;

/// <summary>
/// PaginationItemUC.xaml에 대한 상호 작용 논리
/// </summary>
public partial class PaginationItemUC 
    : UserControl, PaginationItemInterface
{
    #region 외부에서 연결할 이벤트

    /// <summary>
    /// 페이지 네이션의 아이템 클릭시 발생하는 이벤트
    /// </summary>
    public event PageClickDelegate? OnPageClick;
    /// <summary>
    /// 페이지 네이션의 아이템 클릭시 발생하는 이벤트 호출
    /// </summary>
    private void OnPageClickCall()
    {
        if (this.OnPageClick != null)
        {
            this.OnPageClick(this, this.PageNumber);
        }
    }
    #endregion

    /// <summary>
    /// 페이지 번호 - 원본
    /// </summary>
    private int PageNumber_ori = 0;

    /// <inheritdoc />
    /// <remarks>
    /// <para>UI에 표시되는 번호는 무조건 +1이 되서 표시된다.</para>
    /// </remarks>
    public int PageNumber
    {
        get
        {
            return this.PageNumber_ori;
        }
        set
        {
            this.PageNumber_ori = value;
            //UI에는 +1 해서 표시한다.
            //this.labText.Content = (this.PageNumber + 1).ToString();
            this.labText.Content = (this.PageNumber).ToString();
        }
    }

    /// <summary>
    /// 활성화 여부(원본)
    /// </summary>
    private bool ActiveIs_ori = false;
    
    public bool ActiveIs
    {
        get
        {
            return this.ActiveIs_ori;
        }
        set
        {
            this.ActiveIs_ori = value;
            //활성/비활성 이미지 교체
            if (true == this.ActiveIs_ori)
            {
                this.labText.FontSize = 42;
                this.labText.FontWeight = FontWeights.Bold;
                this.labText.Foreground = Brushes.Black;
            }
            else
            {
                this.labText.FontSize = 32;
                this.labText.FontWeight = FontWeights.Light;
                this.labText.Foreground = new SolidColorBrush(Color.FromArgb(255, 121, 121, 121));
            }

        }
    }

    public PaginationItemUC()
    {
        InitializeComponent();

        this.ActiveIs = false;
    }

    public PaginationItemUC(int nPageNumber)
    {
        InitializeComponent();

        this.PageNumber = nPageNumber;
        this.ActiveIs = false;
    }

    private void btnPage_Click(object sender, RoutedEventArgs e)
    {
        this.OnPageClickCall();
    }
}
