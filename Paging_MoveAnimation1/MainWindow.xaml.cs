using DG_PageMove;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paging_MoveAnimation1;

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
             this.btnNextPage
            , this.btnPreviousPage
            , typeof(PaginationItemUC));

        //페이지네이션에 페이지 세팅
        this.ucPagination
            .PageReSetting(this.ListItem
                                .Select(s => s.PageNumber)
                                .ToArray());

        this.ucPagination.OnPageClick
            += (sender, nPageNumber) =>
            {
                this.PageMove(nPageNumber);
            };


        //첫 페이지 세팅
        //ItemPage pageFirst = this.ListItem[0];
        ItemPage pageFirst = this.ListItem[2];
        this.ucPageMove.WithoutAnimation(pageFirst);
        this.PageNowNumber = pageFirst.PageNumber;
        this.ucPagination.PageNow = this.PageNowNumber;
    }

    private void btnPrevious_Click(object sender, RoutedEventArgs e)
    {

        if (this.PageNowNumber >= this.ListItem.Count - 1)
        {//뒤로 이동불가

            return;
        }

        //여기에서 애니메이션이 확정이라 직접 호출 해도되지만
        //일관성 유지를 위해 PageMove를 호출한다.
        this.PageMove(this.PageNowNumber + 1);        
    }

    private void btnNext_Click(object sender, RoutedEventArgs e)
    {
        if (0 >= this.PageNowNumber)
        {//앞으로 이동불가

            return;
        }

        //여기에서 애니메이션이 확정이라 직접 호출 해도되지만
        //일관성 유지를 위해 PageMove를 호출한다.
        this.PageMove(this.PageNowNumber - 1);
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        ucPageMove.AniMoveWidthSet();
    }

    public void PageMove(int nPageNumber)
    {
        if (this.PageNowNumber == nPageNumber
            || null == this.ListItem.Where(w => w.PageNumber == nPageNumber).FirstOrDefault())
        {//이동할 위치가 같다.
            //이동할 위치에 데이터가 없다.

            //이동안함
        }
        else if (nPageNumber < this.ucPagination.PageNow)
        {//현재 페이지보다 작다

            //앞으로 애니메이션 동작
            if (true == ucPageMove.PageMove_Left(this.ListItem[nPageNumber]))
            {//성공

                //ucPageMove.PageMove_Next(this.ListItem[this.PageNowNumber]);

                //한칸 앞으로 값 저장
                this.PageNowNumber = nPageNumber;
                //페이지네이션에 알림
                this.ucPagination.PageNow = this.PageNowNumber;
            }
        }
        else if (nPageNumber > this.ucPagination.PageNow)
        {
            //뒤로 애니메이션 동작
            if (true == ucPageMove.PageMove_Right(this.ListItem[nPageNumber]))
            {//성공

                //ucPageMove.PageMove_Previous(this.ListItem[this.PageNowNumber]);

                //한칸 뒤로 값 저장
                this.PageNowNumber = nPageNumber;
                //페이지네이션에 알림
                this.ucPagination.PageNow = this.PageNowNumber;
            }
        }
    }//end PageMove
}