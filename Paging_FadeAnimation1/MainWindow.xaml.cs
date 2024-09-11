using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestPage;


namespace Paging_FadeAnimation1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<ItemPage> ListItem = new List<ItemPage>();

    public int PageNowNumber = 0;

    public MainWindow()
    {
        InitializeComponent();


        //테스트 데이터
        this.ListItem.Add(new ItemPage("0", 0));
        this.ListItem.Add(new ItemPage("1", 1));
        this.ListItem.Add(new ItemPage("2", 2));
        this.ListItem.Add(new ItemPage("3", 3));
        this.ListItem.Add(new ItemPage("4", 4));
        this.ListItem.Add(new ItemPage("5", 5));
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //페이지네이션 데이터 세팅
        this.ucPagination.DataSettting(
             this.btnNextPage1
            , this.btnPreviousPage1
            , typeof(PaginationItemUC));

        //페이지네이션에 페이지 세팅
        this.ucPagination
            .PageReSetting(this.ListItem
                                .Select(s => s.PageNumber)
                                .ToArray());

        this.ucPagination.OnPageClick
            += (sender, nPageNumber) =>
            {
                this.PageMove1(nPageNumber);
            };


        //첫 페이지 세팅
        //ItemPage pageFirst = this.ListItem[0];
        ItemPage pageFirst = this.ListItem[2];
        this.ucPageFade.WithoutAnimation(pageFirst);
        this.PageNowNumber = pageFirst.PageNumber;
        this.ucPagination.PageNow = this.PageNowNumber;
    }


    #region 페이지네이션 1
    private void btnPrevious1_Click(object sender, RoutedEventArgs e)
    {
        if (0 >= this.PageNowNumber)
        {//앞으로 이동불가

            return;
        }

        //여기에서 애니메이션이 확정이라 직접 호출 해도되지만
        //일관성 유지를 위해 PageMove를 호출한다.
        this.PageMove1(this.PageNowNumber - 1);
    }

    private void btnNext1_Click(object sender, RoutedEventArgs e)
    {
        if (this.PageNowNumber >= this.ListItem.Count - 1)
        {//뒤로 이동불가

            return;
        }

        //여기에서 애니메이션이 확정이라 직접 호출 해도되지만
        //일관성 유지를 위해 PageMove를 호출한다.
        this.PageMove1(this.PageNowNumber + 1);
    }

    public void PageMove1(int nPageNumber)
    {
        if (this.PageNowNumber == nPageNumber
            || null == this.ListItem.Where(w => w.PageNumber == nPageNumber).FirstOrDefault())
        {//이동할 위치가 같다.
            //이동할 위치에 데이터가 없다.

            //이동안함
        }
        else
        {

            //애니메이션 동작
            if (true == this.ucPageFade.NavigateToPage1(this.ListItem[nPageNumber]))
            {//성공

                //ucPageMove.PageMove_Next(this.ListItem[this.PageNowNumber]);

                //한칸 앞으로 값 저장
                this.PageNowNumber = nPageNumber;
                //페이지네이션에 알림
                this.ucPagination.PageNow = this.PageNowNumber;
            }
        }
    }//end PageMove
    #endregion


    #region 페이지네이션 2
    private void btnPrevious2_Click(object sender, RoutedEventArgs e)
    {
        if (0 >= this.PageNowNumber)
        {//앞으로 이동불가

            return;
        }

        //여기에서 애니메이션이 확정이라 직접 호출 해도되지만
        //일관성 유지를 위해 PageMove를 호출한다.
        this.PageMove2(this.PageNowNumber - 1);
    }

    private void btnNext2_Click(object sender, RoutedEventArgs e)
    {
        if (this.PageNowNumber >= this.ListItem.Count - 1)
        {//뒤로 이동불가

            return;
        }

        //여기에서 애니메이션이 확정이라 직접 호출 해도되지만
        //일관성 유지를 위해 PageMove를 호출한다.
        this.PageMove2(this.PageNowNumber + 1);
    }

    public void PageMove2(int nPageNumber)
    {
        if (this.PageNowNumber == nPageNumber
            || null == this.ListItem.Where(w => w.PageNumber == nPageNumber).FirstOrDefault())
        {//이동할 위치가 같다.
            //이동할 위치에 데이터가 없다.

            //이동안함
        }
        else
        {

            //애니메이션 동작
            if (true == this.ucPageFade.NavigateToPage2(this.ListItem[nPageNumber]))
            {//성공

                //ucPageMove.PageMove_Next(this.ListItem[this.PageNowNumber]);

                //한칸 앞으로 값 저장
                this.PageNowNumber = nPageNumber;
                //페이지네이션에 알림
                this.ucPagination.PageNow = this.PageNowNumber;
            }
        }
    }//end PageMove
    #endregion
}